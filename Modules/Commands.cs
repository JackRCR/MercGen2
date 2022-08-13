namespace MercGen2.Modules
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using Discord.Commands;
	using Discord.Interactions;
	using Discord.WebSocket;
	using Discord;

	public class Commands : ModuleBase<SocketCommandContext>
	{
		public static Mercenary reff = new Mercenary();
		private static SQLCaller sql = new SQLCaller();
		
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
				"\n-setup [username] [password]" +
				"\n-foundSettlement");
		}//end of help

		//mercenary generator commands
		[Command("generate")]
		public async Task Basic(int type)
		{
			await ReplyAsync(reff.Operation(type));
		}//end of basic with user input

		public async Task LocalMercenaries()
		{
			//Context.Channel.Id,Context.Guild.Id);


			//If settings and preconditions are met, 
			//generate new list for a location, in it's intended channel.
			await ReplyAsync("NOT IMPLEMENTED");
		}//end of LocationGeneration
		
		//item operations
		[Command("buy")]
		public async Task Purchase(string item, int quantity)//not totally sure how the input works.  Let's test it.
		{
			Console.WriteLine("item: "+item+" quantity: "+quantity+" channel: "+Context.Channel.Id);


			if (await sql.AddItem(item, quantity, Context.Channel.Id))
			{
				await ReplyAsync("Entry added to list");
			}//end of if
			else
			{
				await ReplyAsync("ERROR: UNABLE TO ACCESS DATABASE.  CONTACT BOT ADMINISTRATOR");
			}//end of else
				



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
			Console.WriteLine("Executing LIST");
			await sql.ViewItems(Context.Channel.Id);
			await ReplyAsync("NOT IMPLEMENTED");
		}//end of list
		//end of item operations

		//location operations
		[Command("foundSettlement")]
		public async Task CreateLocation(string locationName, int popNum)
		{
			if (await sql.CreateLocation(Context.Channel.Id, locationName, popNum, Context.Guild.Id))
				await ReplyAsync("Location established.  Mercenaries and equipment can now be hired and tracked here!" +
					"NOTE TO THE PROGRAMMER, DOESN'T VALIDATE FOR NEGATIVE VALUES");
			else
				await ReplyAsync("Error: Unable to enter into DB.  Check you have not already set something up here.");

		}//end of CreateLocation

		
		//Server operations
		[Command("setup")]
		public async Task Setup(string user, string password)
		{
			Console.WriteLine("entering setup...");
			Console.WriteLine("Guild: " + Context.Guild.Id + " user: " + user + " password: " + password);
			
			if (await sql.InitializeServer(Context.Guild.Id, user, password))
				await ReplyAsync("Server information added to database.  " +
					"Advanced bot functionalities now available.  " +
					"Certain functionalities will require uesrname and password authorization in the future." +
					"Don't lose it.");
			else
				await ReplyAsync("Server failed to be registered in database.  " +
					"Contact bot administrator");
		}//end of setup
		 //end of server operations


		[Command("test")]
		public async Task HandleTestCommand()
		{
			/*
			 * Copied from Neihan's work.  
			 * Buttons don't work, but there is promise for some advanced opportunities.
			 * Just need to figure out what those will be.
			 * 
			 */

			var button = new ButtonBuilder()
			{
				Label = "This is a button.",
				CustomId = "testbutton01",
				Style = ButtonStyle.Primary,
			};

			var menu = new SelectMenuBuilder()
			{
				CustomId = "testmenu01",
				Placeholder = "Placeholder",
			};

			menu.AddOption("Option #1", "option_1");
			menu.AddOption("Option #2", "option_2");
			menu.AddOption("Option #3", "option_3");

			var component = new ComponentBuilder();
			component.WithButton(button);
			component.WithSelectMenu(menu);

			await ReplyAsync("This is the interaction test.", components: component.Build());
		}//end of test



	}//end of class Commands : Module Base
}//end of namespace
