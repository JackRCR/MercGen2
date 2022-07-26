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
				"\n-generate [numeral]");
		}//end of help
		[Command("generate")]
		public async Task Basic(String type)
		{
			
			await ReplyAsync(reff.BasicOperation(type));

		}//end of basic with fed input
		public async Task LocalGeneration()
		{
			//If settings and preconditions are met, 
			//generate new list for a location, in it's intended channel.
			await ReplyAsync("NOT IMPLEMENTED");

		}//end of 
		[Command("buy")]
		public async Task Purchase(string item, int quantity)//not totally sure how the input works.  Let's test it.
		{
			
			int x = (int)Context.Channel.Id;
			//ulong is the default val type.  May still cast to int for simplicity.

			
			if (await SQL.addItem(item, quantity))
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
		[Command("setup")]
		public async Task setup(string user, string password)
		{
			string Guild = Context.Guild.Id.ToString();
			SQL.initializeServer(Guild, user, password);
			await ReplyAsync("Server information added to database.  " +
				"Advanced bot functionalities now available.  " +
				"Certain functionalities will require uesrname and password authorization in the future." +
				"Don't lose it.");

		}//end of setup


	}//end of class Commands : Module Base
}//end of namespace
