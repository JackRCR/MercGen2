namespace MercGen2.Database.Models
{
	using System.ComponentModel.DataAnnotations;
	public partial class ServerModel
	{
		[Key]
		public ulong ServerID { get; set; }
		public string? Adminusername { get; set; }
		public string? Adminpassword { get; set; }
		public int? Interval { get; set; }//interval of seconds
	}//end of class
}//end of namespace