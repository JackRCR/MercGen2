namespace MercGen2.Modules
{
	using Discord.Interactions;
	using MercGen2.Database.Contexts;
	using Microsoft.Extensions.DependencyInjection;
	using System;
	internal class LocationCommands : GeneralCommands
	{
		LocationCommands(IServiceProvider services) : base(services) { }
	}//end of class




}//end of namespace