
namespace MercGen2.Database.Contexts
{
	using Microsoft.EntityFrameworkCore; // The magic.
	using MercGen2.Database.Models; // For accessing our table models.
	using Microsoft.Data.Sqlite; // For connecting to our sqlite DB.

	// The context class for Items.db database, containing references to
	// the DbSets of our tables.
	public partial class MercenaryContext : DbContext
	{
		// The DbSet for the shops table in the Items.db database.
		public virtual DbSet<ItemModel> Item { get; set; }
		public virtual DbSet<LocationModel> Location { get; set; }
		public virtual DbSet<ServerModel> Server { get; set; }
		
		protected override void OnConfiguring(
		DbContextOptionsBuilder optionsBuilder)
		{
			// Construct our connection string so we can talk to the database.
			var connectionStringBuilder = new SqliteConnectionStringBuilder
			{
				DataSource = ".\\Database\\mercenaries.db",
				Mode = SqliteOpenMode.ReadWrite,
			};
			// Build our connection string.
			var connectionString = connectionStringBuilder.ToString();
			// Configure our connection.
			var connection = new SqliteConnection(connectionString);
			// Send our connection string to the options builder.
			optionsBuilder.UseSqlite(connection);
		}//end  of optionsBuilder
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// For every table we have that has a combination primary key,
			// we let the program know what its primary key is composed of.
			modelBuilder.Entity<ItemModel>().HasKey(table => new {
				table.ItemName,
				table.ChannelID,
			});
		}//end of OnModelCreating

	}//end of class
}
