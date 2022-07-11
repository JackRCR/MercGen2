using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;
using Discord;

namespace Driver
{
	class Program
	{
		public static Random rnd = new Random();
		private static DiscordSocketClient _client;

		static void Main(string[] args)
        {
            Console.WriteLine("Standby: Program starting...");
            new Program.MainAsync();

        }//end of Main

		public async Task MainAsync(){

		}//end of MainAsync
		
	  }//end of class

  }//end of namespace
