using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Driver
{
	class Program
	{
		public static Random rnd = new Random();
		static void Main(string[] args)=> new Program().MainAsync();

	public async Task MainAsync()
	{
		_client = new DiscordSocketClient();

		_client.Log += Log;

		//  You can assign your bot token to a string, and pass that in to connect.
		//  This is, however, insecure, particularly if you plan to have your code hosted in a public repository.
		var token = "OTg1OTg4Njc2MjU5NTQ1MTM4.GCfX7l.UsBIvpr7bVkIipPx2rpuJdptQveIA0epdgmtrY";

		// Some alternative options would be to keep your token in an Environment Variable or a standalone file.
		// var token = Environment.GetEnvironmentVariable("NameOfYourEnvironmentVariable");
		// var token = File.ReadAllText("token.txt");
		// var token = JsonConvert.DeserializeObject<AConfigurationClass>(File.ReadAllText("config.json")).Token;

		await _client.LoginAsync(TokenType.Bot, token);
		await _client.StartAsync();

		// Block this task until the program is closed.
		await Task.Delay(-1);
	}//end of mainasync

	private Task Log(LogMessage msg)
	{
		Console.WriteLine(msg.ToString());
		return Task.CompletedTask;
	}
		
	  }//end of class

  }//end of namespace
