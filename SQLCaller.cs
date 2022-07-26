﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data.Common;

namespace MercGen2
{
	class SQLCaller
	{
		private string connectionString = "Host=localhost;port=5432;Username=postgres;Password=hoststop;Database=postgres;Search Path=Mercenaries";
		private NpgsqlConnection conn;
		//need to sub in the right info.  I have it here somewhere.

		public SQLCaller()
		{
			//setup the basic aspects necessary to operate.
			conn = new NpgsqlConnection(connectionString);

			//does the schema need declaration?

		}//end of constructor

		//Item Tables interactions
		public async Task<bool> addItem(String itemName, int quantity, int channelID)
		{
			//add/remove are very similar, but left apart for purposes of a audit trail.


			//use insert if no entry, use update if modification.
			//purchasing equipment is what's taking place.  May flip flop these for ease of understanding.
			/* Order of Operations
			 * 0. Retrieve absolute value of Quantity
			 * 1. Open connection
			 * 2. Call DB to check item does not already exist.
			 * 3. If: exists update entry adding positive value to existant entry.
			 * 4. Else: create entry.
			 * 5. Close connection
			 */


			//0. Retrieve absolute value of quantity (case a negative is passed.)
			quantity = Math.Abs(quantity);

			//1.  Open connection
			conn.Open();
			bool output = false;

			//2. Call DB to check item does not already exist.
			NpgsqlCommand check = new NpgsqlCommand("SELECT channelID, quantity FROM items where '" +
				itemName + "' AND channelID =" + channelID + ";", conn);
			string retrieved = check.ExecuteReaderAsync().ToString();
			//3. If: exists update entry adding positive value to existant entry.
			/*if (!retrieved.Equals(null))
			{
				
				NpgsqlCommand cmd = new NpgsqlCommand("UPDATE items " +
					"SET quantity = (quantity + " + quantity + ")" +
					"WHERE channelID = '"+quantity+"' AND itemName = '"+itemName+"';");

			}//end of  if

			//4. Else: create entry
			else*/
			{
				try
				{

					NpgsqlCommand cmd = new NpgsqlCommand("insert into items(itemName,quantity,channelID)" +
						"values('" + itemName + "'," + quantity + "," + 10 + ");", conn);
					await cmd.ExecuteNonQueryAsync();
					output = true;
				}//end of try
				catch (Exception err)
				{
					Console.WriteLine(err);
					//I don't care what it is, return false and warn the user to warn me.

				}//end of catch
				finally
				{
					conn.Close();
				}//end of finally
			}//end of else

			return output;
		}//end of addItem
		public string removeItem()
		{
			//use update.  Even if negative or zero in balance, leave on table.  Resources others can pick up on.
			//selling equipment is what's taking place.
			return "-0";
		}//end of removeItem

		public void clearItemTable()
		{
			/* ORDER OF OPERATIONS
			 * 1. 
			 * 
			 */

			//removes all items from the item table.
			//probably just drop and reinitialize the table.
			//only item table needs this treatment.
		}//end of clearItemTable



		//mercenary interactions
		public void generateMercenaries()
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
		}//end of generateMercenaries
		public void purchaseMercenaries()
		{
			//mercenaries hired are subtracted from the pool.
		}//end of purchaseMercenaries
		public void releaseMercenaries()
		{
			//any mercenaries laid off in a area may reenter the arms pool.
		}//end of releaseMercenaries
		public void setMercenaries()
		{
			//take rolled stats and overwrite everything.  For end of month generation
		}//end of setMercenaries
		public void syncMercenaries(string password)
		{
			//give all location entries in a server the same timestamp.  Optional operation.
			//syncs to NOW, when executed
			//admin required operation
			checkAuthorization(password);

		}//end of syncMercenaries


		//Location Tables Interactions (moreso than just mercs)
		public async Task<bool> createLocation(int channelID, String locationName, int popNum, int serverID)
		{
			/*ORDER OF OPERATIONS
			 * 1. Open connection
			 * 2. Build command
			 * 3. Insert into database
			 * 4. Close connection
			 */
			//1. Open connection
			conn.Open();
			bool output=false;

			try
			{
				//2. Build command
				NpgsqlCommand cmd = new NpgsqlCommand(
		"insert into locations (channelID,locationName,popnum,datetime,lightinfantry,slingers," +
		"heavyinfantry,crossbowmen,bowmen,longbowmen,lightcav,mediumcav,heavycav,serverID)" +
		"values("+channelID+",'"+locationName+"',"+popNum+", null, 0, 0, 0, 0, 0, 0, 0, 0, 0, "+serverID+");", conn);
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
		public void updateLocation()
		{//uncertain what logic to use to pass values.  I'm thinking string[], string[].  Messy.  But it'll function.


			//alter the properties of a table.  Requires everything, for compressability and ease.

		}//end of updateLocation


		//Server Table Interactions
		public async Task<bool> initializeServer(int serverID, string user, string password)
		{
			/* Order of Operations
			 * 0. Open connection.
			 * 1. Construct string.
			 * 2. Insert into database.
			 * 3. Close connection.
			 */

			//0. Open connection
			conn.Open();
			bool output = false;

			//1. Construct string.
			Console.WriteLine("Guild: " + serverID + " user: " + user + " password: " + password);
			try
			{

				NpgsqlCommand cmd = new NpgsqlCommand(
					"insert into servers (serverID,administratorusername,adminastratorpassword)" +
					"values(" + serverID + ",'" + user + "','" + password + "');", conn);
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
				conn.Close();

			}//end of finally




			Console.WriteLine("DON'T FORGET ME");
			return output;


			//servers need to be setup with basic parameters, so access controls may be established.
			//The bot will do nothing but basic operations from outside proper server setup.
			//Throw an error out to the user if they try and do something that stupid.
		}//end of initializeServer

















		public Boolean checkAuthorization(string password)
		{
			string passwordFromDB = null;//this needs to call and pull from the database.
			if (password == null)//check that value isn't empty
				return true;
			if (passwordFromDB.Equals(password))
				return true;
			else
				return false;
		}//end of checkAuthorization



	}//end of class SQLCaller
}//end of namespace
