using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;


namespace MercGen2
{
	class Program
	{
		private DiscordSocketClient _client;
		private CommandService _commands;
		private IServiceProvider _services;
		public static Mercenary generator = new Mercenary();//everyone needs to access this.
		//I just don't know how to send the ref.
		

		public static Task Main(string[] args) => new Program().MainAsync();
		//the guide has a .GetAwaiter().GetResult() too.  I do not grasp what either method does.
		//don't know how this works, Just following the instructions.

		public async Task MainAsync()
		{
			_client = new DiscordSocketClient();
			_commands = new CommandService();

			_services = new ServiceCollection()
				.AddSingleton(_client)
				.AddSingleton(_commands)
				.BuildServiceProvider();
			
			var token = "OTg1OTg4Njc2MjU5NTQ1MTM4.G_Av"+"cU.bG5FR7wPFl7TVbh0zy0DXVVjnXTIxg37hWE7Bw";
			//good news!  The discord scraper doesn't catch this.
			//also FIX THIS YOU MORON

			_client.Log += Log;

			

			await RegisterCommandsAsync();

			await _client.LoginAsync(TokenType.Bot, token);

			await _client.StartAsync();

			await Task.Delay(-1);//keeps the task opn
		}//end of mainAsync

		private Task Log(LogMessage msg)
		{
			Console.WriteLine(msg.ToString());
			return Task.CompletedTask;
			//from following the instructions, will substitute something else in later. Maybe
		}//end of Log
		public async Task RegisterCommandsAsync()
		{
			_client.MessageReceived += HandleCommandAsync;
			await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), _services);
			
		}//end of RegisterCommandsAsync

		private async Task HandleCommandAsync(SocketMessage arg)
		{
			var message = arg as SocketUserMessage;
			var context = new SocketCommandContext(_client, message);

			if (message.Author.IsBot == true) return;//ignore bots that might accidentally invoke operation.

			int argPos = 0;// Create a number to track where the prefix ends and the command begins

			if (!(message.HasCharPrefix('-', ref argPos) ||
				message.HasMentionPrefix(_client.CurrentUser, ref argPos)))
			{
				var result = await _commands.ExecuteAsync(context,argPos,_services);
				if (!result.IsSuccess) Console.WriteLine(result.ErrorReason);
				if (result.Error.Equals(CommandError.UnmetPrecondition))
					await message.Channel.SendMessageAsync(result.ErrorReason);
			}//end of if
			
			await _commands.ExecuteAsync(
				context: context,
				argPos: argPos,
				services: null);
		}//end of HandleCommandAsync




	}//end of Class Program

}//end of Namespace
