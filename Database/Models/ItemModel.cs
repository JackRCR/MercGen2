namespace MercGen2.Database.Models
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public partial class ItemModel
	{
		[Key]
		public string ItemName { get; set; }
		[Key][Required]
		public ulong ChannelID { get; set; }
		public int Quantity { get; set; }
	}//end of class
}//end of namespace
