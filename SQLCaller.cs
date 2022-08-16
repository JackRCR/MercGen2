namespace MercGen2
{
	using System;
	using System.Collections.Generic;
	using System.Data.Common;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using Npgsql;

	public class SQLCaller
	{
		private string connectionString = "Host=localhost;port=5432;Username=postgres;Password=hoststop;Database=postgres;Search Path=Mercenaries;Log Parameters=true;Include Error Detail=true;";
		private NpgsqlConnection conn;

		//need to sub in the right info.  I have it here somewhere.
		
		public SQLCaller()
		{
			//setup the basic aspects necessary to operate.
			this.conn = new NpgsqlConnection(connectionString);

			//does the schema need declaration?

		}//end of constructor

		//Item Tables interactions
		public async Task<bool> AddItem(string itemName, int quantity, ulong channelID)
		{
			//add/remove are very similar, but left apart for purposes of a audit trail.

			//use insert if no entry, use update if modification.
			//purchasing equipment is what's taking place.  May flip flop these for ease of understanding.
			/* Order of Operations
			 * 0. Retrieve absolute value of Quantity
			 * 1. Open connection
			 * 2. Call DB to check item does not already exist.
			 *    Cycle connection
			 * 3. If: exists update entry adding positive value to existant entry.
			 * 4. Else: create entry.
			 * 5. Close connection
			 */


			//0. Retrieve absolute value of quantity (case a negative is passed.)
			quantity = Math.Abs(quantity);

			//1.  Open connection
			this.conn.Open();
			bool output = false;

			//2. Call DB to check item does not already exist.
			String temp1 = $"SELECT * FROM items where \"itemname\" = '{itemName}' AND \"channelid\" ={channelID};";
			Console.WriteLine(temp1);
			NpgsqlCommand check = new NpgsqlCommand(temp1, this.conn);
			
			var retrieved = await check.ExecuteReaderAsync();
			
			Console.WriteLine("Retrival check: "+ retrieved.Rows);
			this.conn.Close();
			this.conn.Open();
			
			try
			{
				if (retrieved.Rows == 1)//If there are MULTIPLE rows, thats an issue, for another day.
				{
					//3. If: exists update entry adding positive value to existant entry.
					string test = $"UPDATE items SET quantity = (\"quantity\" + {quantity}) WHERE \"channelID\" = {channelID} AND itemName = '{itemName}';";
					Console.WriteLine(test);
					NpgsqlCommand cmd = new NpgsqlCommand(test);
					await cmd.ExecuteNonQueryAsync();
					Console.WriteLine("Salute 1");
				}//end of  if
				else if (retrieved.Rows > 1)
				{
					output = false;//No way in hell should the code end up here.But if it does... BAD.
					Console.WriteLine("WARNING MULTIPLE ENTRIES RETRIEVED");
				}//end of else if
				//4. Else: create entry
				else
				{
					NpgsqlCommand cmd = new NpgsqlCommand(
						$"insert into items(itemName,quantity,channelID) values('{itemName}',{quantity},{channelID});", 
						this.conn);
					await cmd.ExecuteNonQueryAsync();
					Console.WriteLine("Salute 2");
				}//end of else
				output = true;//flag for successful entry.
			}//end of try
			catch (Exception err)
			{
				Console.WriteLine(err);

				//I don't care what it is, return false and warn the user to warn me.

			}//end of catch
			finally
			{
				//5. Close connection
				this.conn.Close();
			}//end of finally
			

			return output;
		}//end of addItem

		public string RemoveItem()
		{
			//use update.  Even if negative or zero in balance, leave on table.  Resources others can pick up on.
			//selling equipment is what's taking place.
			return "-0";
		}//end of removeItem


		public async Task<String> ViewItems(ulong channelID)
		{
			this.conn.Open();
			NpgsqlCommand check = new NpgsqlCommand($"SELECT * FROM items WHERE channelID = {channelID};",
				this.conn);

			NpgsqlDataReader retrieval = await check.ExecuteReaderAsync();
			Console.WriteLine(retrieval.Rows);
			this.conn.Close();
			return "```nothing```";
		}//end of ViewItems

		public bool ClearItemTable()
		{
			/* ORDER OF OPERATIONS
			 * 1. 
			 * 
			 */
			return false;

			/*
			 * removes all items from the item table.
			 * probably just drop and reinitialize the table.
			 * only item table needs this treatment.
			 */

		}//end of clearItemTable
		//mercenary interactions
		public string GenerateMercenaries()
		{
			/*ORDER OF OPERATIONS
			 * 1. Open connection
			 * 2. CHeck local time against timestamp + interval.  IF local > (timestamp+interval) then proceed.
			 * Edge cases
			 * i:   null timestame: roll, and save time with the created values.
			 * ii:  null interval: roll at will, save anyways.
			 * Check edge cases first, in if/else chain
			 * 3. Determine market class
			 * 4. Roll on table.
			 * 5. Format results.
			 * 6. Close connection
			 * 7. Return results.
			 */

			//locations focus = new locations();

			//1. Open connection
			this.conn.Open();

			//2. Check local 


			this.conn.Close();

			return "";
		}//end of generateMercenaries

		public void PurchaseMercenaries()
		{
			//mercenaries hired are subtracted from the pool.
		}//end of purchaseMercenaries

		public void ReleaseMercenaries()
		{
			//any mercenaries laid off in a area may reenter the arms pool.
		}//end of releaseMercenaries

		public void SetMercenaries()
		{
			//take rolled stats and overwrite everything.  For end of month generation
		}//end of setMercenaries

		public void SyncMercenaries(string password)
		{
			//give all location entries in a server the same timestamp.  Optional operation.
			//syncs to NOW, when executed
			//admin required operation
			CheckAuthorization(password);

		}//end of syncMercenaries


		//Location Tables Interactions (moreso than just mercs)
		public async Task<bool> CreateLocation(ulong channelID, string locationName, int popNum, ulong serverID)
		{
			/*ORDER OF OPERATIONS
			 * 1. Open connection
			 * 2. Build command
			 * 3. Insert into database
			 * 4. Close connection
			 */

			//1. Open connection
			this.conn.Open();
			bool output = false;

			try
			{
				//2. Build command
				NpgsqlCommand cmd = new NpgsqlCommand(
		"insert into locations (channelID,locationName,popnum,datetime,lightinfantry,slingers," +
		"heavyinfantry,crossbowmen,bowmen,longbowmen,lightcav,mediumcav,heavycav,serverID)" +
		"values("+channelID+",'" + locationName + "'," + popNum + ", null, 0, 0, 0, 0, 0, 0, 0, 0, 0, " + 
		serverID + ");", 
		this.conn);

				//3. Insert into database.
				await cmd.ExecuteNonQueryAsync();
				output = true;

			}//end of try
			catch (Exception err)
			{
				Console.WriteLine(err);
				output = false;
			}//end of catch (Exception err)
			finally
			{
				//4. Close connection
				conn.Close();

			}//end of finally
			return output;
		}//end of createLocation

		public void UpdateLocation()
		{//uncertain what logic to use to pass values.  I'm thinking string[], string[].  Messy.  But it'll function.


			//alter the properties of a table.  Requires everything, for compressability and ease.

		}//end of updateLocation


		//Server Table Interactions
		public async Task<bool> InitializeServer(ulong serverID, string user, string password)
		{
			/* Order of Operations
			 * 0. Open connection.
			 * 1. Construct string.
			 * 2. Insert into database.
			 * 3. Close connection.
			 */

			//0. Open connection
			this.conn.Open();
			bool output = false;

			//1. Construct string.
			Console.WriteLine("Guild: " + serverID + " user: " + user + " password: " + password);
			try
			{
				NpgsqlCommand cmd = new NpgsqlCommand(
					"insert into servers (serverID,administratorusername,adminastratorpassword)" +
					"values(" + serverID + ",'" + user + "','" + password + "');", 
					conn);

				//2. Insert into database.
				await cmd.ExecuteNonQueryAsync();
				output = true;
			}//end of try
			catch (Exception err)
			{
				Console.WriteLine(err);
			}//end of catch (Exception err)
			finally
			{
				//3. Close connection
				this.conn.Close();
			}//end of finally




			Console.WriteLine("DON'T FORGET ME");
			return output;


			//servers need to be setup with basic parameters, so access controls may be established.
			//The bot will do nothing but basic operations from outside proper server setup.
			//Throw an error out to the user if they try and do something that stupid.
		}//end of initializeServer

















		public bool CheckAuthorization(string password)
		{
			string passwordFromDB = null;//this needs to call and pull from the database.
			if (password == null)//check that value isn't empty
			{
				return true;
			}//end of if
			if (passwordFromDB.Equals(password))
			{
				return true;
			}//end of if
			else
			{
				return false;
			}//end of else
		}//end of checkAuthorization

	}//end of class SQLCaller
}//end of namespace
