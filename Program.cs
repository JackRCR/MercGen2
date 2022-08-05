namespace MercGen2//refactor in the near future for this class.
{
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

	public class Program
	{
		private DiscordSocketClient client;
		private CommandService commands;
		private IServiceProvider services;
		

		public static Task Main(string[] args) => new Program().MainAsync();

		//the guide has a .GetAwaiter().GetResult() too.  I do not grasp what either method does.
		//don't know how this works, Just following the instructions.

		public async Task MainAsync()
		{
			this.client = new DiscordSocketClient();
			this.commands = new CommandService();

			services = new ServiceCollection()
				.AddSingleton(this.client)
				.AddSingleton(this.commands)
				.BuildServiceProvider();


			var token = Properties.resources.Token;

			this.client.Log += Log;

			

			await this.RegisterCommandsAsync();

			await this.client.LoginAsync(TokenType.Bot, token);

			await this.client.StartAsync();

			await Task.Delay(-1);//keeps the task opn
		}//end of mainAsync
		
		public async Task RegisterCommandsAsync()
		{
			client.MessageReceived += HandleCommandAsync;
			await commands.AddModulesAsync(Assembly.GetEntryAssembly(), services);
			
		}//end of RegisterCommandsAsync

		private async Task HandleCommandAsync(SocketMessage arg)
		{
			var message = arg as SocketUserMessage;
			var context = new SocketCommandContext(client, message);

			if (message.Author.IsBot == true) return;//ignore bots that might accidentally invoke operation.

			int argPos = 0;// Create a number to track where the prefix ends and the command begins

			if (!(message.HasCharPrefix('-', ref argPos) ||
				message.HasMentionPrefix(client.CurrentUser, ref argPos)))
			{
				var result = await commands.ExecuteAsync(context, argPos, this.services);
				if (!result.IsSuccess) Console.WriteLine(result.ErrorReason);
				if (result.Error.Equals(CommandError.UnmetPrecondition))
					await message.Channel.SendMessageAsync(result.ErrorReason);
			}//end of if
			
			await commands.ExecuteAsync(
				context: context,
				argPos: argPos,
				services: null);
		}//end of HandleCommandAsync

		private Task Log(LogMessage msg)
		{
			Console.WriteLine(msg.ToString());
			return Task.CompletedTask;

			//from following the instructions, will substitute something else in later. Maybe

		}//end of Log

	}//end of Class Program

}//end of Namespace
