namespace MercGen2.Database.Models
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	public partial class LocationModel
	{
		[Key]
		public ulong ChannelID { get; set; }
		[Required]
		public ulong ServerID { get; set; }
		public string LocationName { get; set; }
		public int Popnum { get; set; }
		public string? Datetime { get; set; }
		public int Lightinfantry { get; set; }
		public int Slingers { get; set; }
		public int Heavyinfantry { get; set; }
		public int Crossbowmen	{ get; set; }
		public int Bowmen { get; set; }
		public int Longbowmen { get; set; }
		public int Lightcav { get; set; }
		public int Mediumcav { get; set; }
		public int Heavycav { get; set; }

	}//end of class
}//end of namespace
