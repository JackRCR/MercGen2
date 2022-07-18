using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;

namespace MercGen2.Modules
{
	public class Commands : ModuleBase<SocketCommandContext>
	{
		private static Mercenary reff;

		
		
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
		public async Task Basic()
		{

			//BasicOperation("i");


			await ReplyAsync("NOT IMPLEMENTED");

		}//end of basic THIS NEEDS TO BE REPLACED
		
	}//end of class Commands : Module Base
}//end of namespace
