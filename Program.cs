using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System.Reflection;

namespace Driver
{

public class CommandHandler
    {
        private static DiscordSocketClient _client;
        private static CommandService _commands;

        // Retrieve client and CommandService instance via ctor
        public CommandHandler(DiscordSocketClient client, CommandService commands)
        {
            _commands = commands;
            _client = client;
        }//end of Constructor
        
        public async Task InstallCommandsAsync() {
            // Hook the MessageReceived event into our command handler
            _client.MessageReceived += HandleCommandAsync;

            // Here we discover all of the command modules in the entry 
            // assembly and load them. Starting from Discord.NET 2.0, a
            // service provider is required to be passed into the
            // module registration method to inject the 
            // required dependencies.
            //
            // If you do not use Dependency Injection, pass null.
            // See Dependency Injection guide for more information.
            await _commands.AddModulesAsync(assembly: Assembly.GetEntryAssembly(), 
                                            services: null);
        }//end of InstallCommandsAsync

        private async Task HandleCommandAsync(SocketMessage messageParam) {
            // Don't process the command if it was a system message
            var message = messageParam as SocketUserMessage;
            if (message == null) return;

            // Create a number to track where the prefix ends and the command begins
            int argPos = 0;

            // Determine if the message is a command based on the prefix and make sure no bots trigger commands
            if (!(message.HasCharPrefix('!', ref argPos) || 
                message.HasMentionPrefix(_client.CurrentUser, ref argPos)) ||
                message.Author.IsBot)
                return;

            // Create a WebSocket-based command context based on the message
            var context = new SocketCommandContext(_client, message);

            // Execute the command with the command context we just
            // created, along with the service provider for precondition checks.
            await _commands.ExecuteAsync(
                context: context, 
                argPos: argPos,
                services: null);
        }//end of HandleCommandAsync
    }//end of class
	class Program
	{
		public static Random rnd = new Random();
		private static DiscordSocketClient _client;
		private static CommandService _commands;

		public static Task Main(string[] args) => new Program().MainAsync();

		public async Task MainAsync(){

			_client = new DiscordSocketClient();
		    var token = "OTg1OTg4Njc2MjU5NTQ1MTM4.Gz9amG.YkMAj316jemdKVVMZKJkcg7XP8L3nbv5l4a84c";
			//Console.WriteLine("Temporary readline");
			//Console.ReadLine();
			await _client.LoginAsync(TokenType.Bot, token);
    		await _client.StartAsync();

			await Task.Delay(-1);

			Console.WriteLine("Finished.");
		}//end of MainAsync

		
	  }//end of class
	  

  }//end of namespace
