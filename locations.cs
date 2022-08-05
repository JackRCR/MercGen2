namespace MercGen2
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	public class Locations
	{
		private string locationName;
		private int channel;
		private int serverID;
		private int popnum;
		private DateTime datetime;
		private int[] mercenaries = new int[9];
		
		public Locations(string unparsedRecall, DateTime datetime, int channel, int serverID)
		{
			this.locationName = unparsedRecall;//this is not what I want this to be.
			this.datetime = datetime;

			this.channel = channel;
			this.serverID = serverID;
			popnum = 0;
			datetime = new DateTime();

			for (int x = 0; x < this.mercenaries.Length; x++)
			{
				this.mercenaries[x] = 0;
			}//end of foreach
		}//end of constructor UNPAREDRECALL

		public int DeriveClass()
		{
			if (this.popnum >= 20000)
				return 1;
			else if (this.popnum >= 5000)
				return 2;
			else if (this.popnum >= 2500)
				return 3;
			else if (this.popnum >= 625)
				return 4;
			else if (this.popnum >= 250)
				return 5;
			else if (this.popnum >= 1)
				return 6;
			else
				return -1;//if there is nobody, it should fail to generate on account of everyone being dead!
		}//end of deriveClass
	}//end of class
}//end of namespace
