using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;
using Discord.Interactions;

namespace MercGen2.Modules
{
	public class Commands : ModuleBase<SocketCommandContext>
	{
		private static Mercenary reff=new Mercenary();
		private static SQLCaller SQL=new SQLCaller();
		//I don't likle this instantiation, but it'll do for now...
		
		[Command("ping")]
		public async Task Ping()
		{
			await ReplyAsync("pong");
		}//end of Ping
		[Command("help")]
		public async Task Help()
		{
			await ReplyAsync("Available commands:" +
				"\n-ping" +
				"\n-help"+
				"\n-generate [integer]" +
				"\n-generate" +
				"\n-buy [item] [qty]" +
				"\n-sell [item] [qty]" +
				"\n-list" + 
				"\n-setup [username] [password]");
		}//end of help

		//mercenary generator commands
		[Command("generate")]
		public async Task Basic(int type)
		{
			
			await ReplyAsync(reff.Operation(type));

		}//end of basic with user input
		public async Task LocalMercenaries()
		{
			Context.Channel.Id;
			Context.Guild.Id;
			//If settings and preconditions are met, 
			//generate new list for a location, in it's intended channel.
			await ReplyAsync("NOT IMPLEMENTED");

		}//end of LocationGeneration


		//item operations
		[Command("buy")]
		public async Task Purchase(string item, int quantity)//not totally sure how the input works.  Let's test it.
		{


			//Console.WriteLine("item: "+item+" quantity: "+quantity+" channel: "+(int)Context.Channel.Id);

			
			if (await SQL.addItem(item, quantity,(int)Context.Channel.Id))
				await ReplyAsync("Entry added to list");
			else
				await ReplyAsync("ERROR: UNABLE TO ACCESS DATABASE.  CONTACT BOT ADMINISTRATOR");



		}//end of Purchase
		[Command("sell")]
		public async Task Sell(string input, int count)
		{


			/* order of operation
			 * 1. pass values
			 * 2. Search for match.
			 * 3. add to list if not present.
			 * 4. Remove from count.
			 */
			await ReplyAsync("NOT IMPLEMENTED");
		}//end of Sell
		[Command("list")]
		public async Task RetrieveList()
		{
			//pull list and display in a well formatted manner.
			//all operations will be in method in SQLcaller.
			await ReplyAsync("NOT IMPLEMENTED");
		}//end of list
		//end of item operations

		//location operations
		[Command("found")]
		public async Task CreateLocation(String locationName, int popNum)
		{

			if (await SQL.createLocation((int)Context.Channel.Id, locationName, popNum, (int)Context.Guild.Id))
				await ReplyAsync("Location established.  Mercenaries and equipment can now be hired and tracked here!" +
					"NOTE TO THE PROGRAMMER, DOESN'T VALIDATE FOR NEGATIVE VALUES");
			else
				await ReplyAsync("Error: Unable to enter into DB.  Check you have not already set something up here.");

		}//end of CreateLocation
		
		
		//Server operations
		[Command("setup")]
		public async Task setup(string user, string password)
		{
			Console.WriteLine("entering setup...");
			Console.WriteLine("Guild: "+(int)Context.Guild.Id+" user: "+user+" password: "+password);
			
			if (await SQL.initializeServer((int)Context.Guild.Id, user, password))
				await ReplyAsync("Server information added to database.  " +
					"Advanced bot functionalities now available.  " +
					"Certain functionalities will require uesrname and password authorization in the future." +
					"Don't lose it.");
			else
				await ReplyAsync("Server failed to be registered in database.  " +
					"Contact bot administrator");
		}//end of setup
		//rend of server operation


	}//end of class Commands : Module Base
}//end of namespace
