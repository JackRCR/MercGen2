namespace MercGen2.Database.Models
{
	using System.ComponentModel.DataAnnotations;
	internal class ItemListModel
	{
		[Key]
		string itemName { get; set; }
		[Key]
		ulong channelID { get; set; }
		int quantity { get; set; }
	}//end of class
}//end of namespace
