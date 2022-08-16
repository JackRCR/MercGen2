

namespace MercGen2.Modules
{
	using MercGen2.Database.Contexts;
	using MercGen2.Database.Models;
	using Microsoft.Extensions.DependencyInjection;
	using System;
	using System.Threading.Tasks;
	using Discord;
	using Discord.Commands;
	using Discord.Interactions;
	using Discord.WebSocket;
	internal class ItemCommands : GeneralCommands
	{
		ItemCommands(IServiceProvider services) : base(services) { }
		[Command("buy")]
		public async Task Purchase(string itemName, int quantity)
		{
			_mercenaryContext.Item.Add(
				new ItemModel
				{
					ChannelID = Context.Channel.Id,
					ItemName = itemName,
					Quantity = quantity
				});
			await ReplyAsync("pong");
		}//end of Purchase
		[Command("sell")]
		public async Task Sell()
		{
			await ReplyAsync("pong");
		}//end of Sell


	}//end of class
}//end of namespace
