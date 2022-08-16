
namespace MercGen2.Modules
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using Discord;
	using Discord.Interactions;
	using Discord.WebSocket;
	[Group("mg", "Use validation to interact with the database")]
	internal class ServerCommands : GeneralCommands
	{
		
		ServerCommands(IServiceProvider services) : base(services) { }

		[SlashCommand("setup", "setup server control information.")]
		public async Task ServerSetup([ComplexParameter] ComplexEquipmentParam param)
		{
			await ReplyAsync("testing");
		}//end of ServerSetup

		[SlashCommand("addT", "[Description] [# of coins] [coin type (pp/ep/gp/sp/cp)] [weight in coins]")]
		public async Task HandleAddEquipment([ComplexParameter] ComplexEquipmentParam param)
		{
			
			switch (param.CoinType.ToLower().Trim())
			{
				case "pp":
				case "ep":
				case "gp":
				case "sp":
				case "cp":
					;
					break;
				default:
					;
					break;
			}

			await RespondAsync($"Added item:");
		}


	}//end of class



	public class ComplexEquipmentParam
	{
		public string Description { get; }
		public int AmountOfCoins { get; }
		public string CoinType { get; }
		public int WeightInCoins { get; }

		[ComplexParameterCtor]
		public ComplexEquipmentParam(string description, int amountOfCoins, string coinType, int weightInCoins)
		{
			Description = description;
			AmountOfCoins = amountOfCoins;
			CoinType = coinType;
			WeightInCoins = weightInCoins;
		}//end of ComplexEquipmentparam

		public override string ToString()
		{
			return $"\n**Description:**\t`{Description}`\n**Cost:**\t`{AmountOfCoins} {CoinType}`\n**Weight:**\t`{WeightInCoins}`";
		}//end of ToString

	}//end of ComplexEquipmentParam class

}//end of namespace
