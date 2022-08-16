namespace MercGen2.Modules
{
	using Discord.Interactions;
	using MercGen2.Database.Contexts;
	using Microsoft.Extensions.DependencyInjection;
	using System;
	internal class GeneralCommands : InteractionModuleBase<SocketInteractionContext>
	{
		protected Mercenary reff = new Mercenary();
		protected readonly MercenaryContext _mercenaryContext;

		public GeneralCommands(IServiceProvider services)
		{
			_mercenaryContext = services.GetRequiredService<MercenaryContext>();
		}//end of constructor



	}//end of class
}//end of namespace
