using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercGen2
{
	class Mercenary
	{

		private static Random rnd;
		public Mercenary()
		{
			rnd = new Random();//this isn't strictly necessary, but whatever.

		}//end of constructor


		public String Operation(int input)
		{
			int[][][] LoadingDice1 = new int[][][]{
							new int[][] {
								new int[] {4,100},
								new int[] {8,20},
								new int[] {2,100},
								new int[] {2,100},
								new int[] {8,20},
								new int[] {4,20},
								new int[] {4,20},
								new int[] {3,20},
								new int[] {4,10} },
							new int[][] {
								new int[] { 5,20},
								new int[] {4,10},
								new int[] {5,10},
								new int[] {5,10},
								new int[] {4,10},
								new int[] {2,10},
								new int[] {2,10},
								new int[] {3,4},
								new int[] {1,10} },
							new int[][] {
								new int[] {5,10},
								new int[] {2,10},
								new int[] {3,8},
								new int[] {3,8},
								new int[] {2,10},
								new int[] {1,10},
								new int[] {1,10},
								new int[] {4,4},
								new int[] {1,6} },
							new int[][] {
								new int[] {3,4},
								new int[] {1,6},
								new int[] {1,8},
								new int[] {1,8},
								new int[] {1,10},
								new int[] {1,3},
								new int[] {1,3},
								new int[] {2,4},
								new int[] {1,6} },
							new int[][] {
								new int[] {1,6},
								new int[] {1,2},
								new int[] {1,3},
								new int[] {1,3},
								new int[] {1,3},
								new int[] {1,1},
								new int[] {1,1},
								new int[] {70},
								new int[] {50} },
							new int[][] {
								new int[] {1,2},
								new int[] {70},
								new int[] {85},
								new int[] {85},
								new int[] {33},
								new int[] {33},
								new int[] {33},
								new int[] {23},
								new int[] {15} }

			};//must +1 Each number to be max inclusive!
			int[] output = new int[9];
			String returnOut="-1";
			switch (input.ToUpper())
			{
				case "I":
					output = Roller(LoadingDice1[0]);
					returnOut = "```Java\nResults\n" +
						"Light Infantry" + (output[0] + "").PadLeft(30, ' ') + "\n" +
						"Slingers" + (output[1] + "").PadLeft(30, ' ') + "\n" +
						"Heavy Infantry" + (output[2] + "").PadLeft(30, ' ') + "\n" +
						"Crossbowmen" + (output[3] + "").PadLeft(30, ' ') + "\n" +
						"Bowmen" + (output[4] + "").PadLeft(30, ' ') + "\n" +
						"Longbowmen" + (output[5] + "").PadLeft(30, ' ') + "\n" +
						"Light Cavalry" + (output[6] + "").PadLeft(30, ' ') + "\n" +
						"Medium Cavalry" + (output[7] + "").PadLeft(30, ' ') + "\n" +
						"Heavy Cavalry" + (output[8] + "").PadLeft(30, ' ') + "\n```"
					;
					break;

				case "II":
					output = Roller(LoadingDice1[1]);
					returnOut = "```Java\nResults\n" +
						"Light Infantry\t" + (output[0] + "").PadLeft(3, ' ') + "\n" +
						"Slingers\t" + (output[1] + "").PadLeft(3, ' ') + "\n" +
						"Heavy Infantry\t" + (output[2] + "").PadLeft(3, ' ') + "\n" +
						"Crossbowmen\t" + (output[3] + "").PadLeft(3, ' ') + "\n" +
						"Bowmen\t\t" + (output[4] + "").PadLeft(3, ' ') + "\n" +
						"Longbowmen\t" + (output[5] + "").PadLeft(3, ' ') + "\n" +
						"Light Cavalry\t" + (output[6] + "").PadLeft(3, ' ') + "\n" +
						"Medium Cavalry\t" + (output[7] + "").PadLeft(3, ' ') + "\n" +
						"Heavy Cavalry\t" + (output[8] + "").PadLeft(3, ' ') + "\n```"
					;
					break;
				case "III":
					output = Roller(LoadingDice1[2]);
					returnOut = "```Java\nResults\n" +
						"Light Infantry\t" + (output[0] + "").PadLeft(3, ' ') + "\n" +
						"Slingers\t" + (output[1] + "").PadLeft(3, ' ') + "\n" +
						"Heavy Infantry\t" + (output[2] + "").PadLeft(3, ' ') + "\n" +
						"Crossbowmen\t" + (output[3] + "").PadLeft(3, ' ') + "\n" +
						"Bowmen\t\t" + (output[4] + "").PadLeft(3, ' ') + "\n" +
						"Longbowmen\t" + (output[5] + "").PadLeft(3, ' ') + "\n" +
						"Light Cavalry\t" + (output[6] + "").PadLeft(3, ' ') + "\n" +
						"Medium Cavalry\t" + (output[7] + "").PadLeft(3, ' ') + "\n" +
						"Heavy Cavalry\t" + (output[8] + "").PadLeft(3, ' ') + "\n```"
					;
					break;
				case "IV":
					output = Roller(LoadingDice1[3]);
					returnOut = "```Java\nResults\n" +
						"Light Infantry\t" + (output[0] + "").PadLeft(3, ' ') + "\n" +
						"Slingers\t" + (output[1] + "").PadLeft(3, ' ') + "\n" +
						"Heavy Infantry\t" + (output[2] + "").PadLeft(3, ' ') + "\n" +
						"Crossbowmen\t" + (output[3] + "").PadLeft(3, ' ') + "\n" +
						"Bowmen\t\t" + (output[4] + "").PadLeft(3, ' ') + "\n" +
						"Longbowmen\t" + (output[5] + "").PadLeft(3, ' ') + "\n" +
						"Light Cavalry\t" + (output[6] + "").PadLeft(3, ' ') + "\n" +
						"Medium Cavalry\t" + (output[7] + "").PadLeft(3, ' ') + "\n" +
						"Heavy Cavalry\t" + (output[8] + "").PadLeft(3, ' ') + "\n```"
					;
					break;
				case "V":
					output = Roller(LoadingDice1[4]);
					returnOut = "```Java\nResults\n" +
						"Light Infantry\t" + (output[0] + "").PadLeft(3, ' ') + "\n" +
						"Slingers\t" + (output[1] + "").PadLeft(3, ' ') + "\n" +
						"Heavy Infantry\t" + (output[2] + "").PadLeft(3, ' ') + "\n" +
						"Crossbowmen\t" + (output[3] + "").PadLeft(3, ' ') + "\n" +
						"Bowmen\t\t" + (output[4] + "").PadLeft(3, ' ') + "\n" +
						"Longbowmen\t" + (output[5] + "").PadLeft(3, ' ') + "\n" +
						"Light Cavalry\t" + (output[6] + "").PadLeft(3, ' ') + "\n" +
						"Medium Cavalry\t" + (output[7] + "").PadLeft(3, ' ') + "\n" +
						"Heavy Cavalry\t" + (output[8] + "").PadLeft(3, ' ') + "\n```"
					;
					break;
				case "VI":
					output = Roller(LoadingDice1[5]);
					returnOut = "```Java\nResults\n" +
						"Light Infantry\t" + (output[0] + "").PadLeft(3, ' ') + "\n" +
						"Slingers\t" + (output[1] + "").PadLeft(3, ' ') + "\n" +
						"Heavy Infantry\t" + (output[2] + "").PadLeft(3, ' ') + "\n" +
						"Crossbowmen\t" + (output[3] + "").PadLeft(3, ' ') + "\n" +
						"Bowmen\t\t" + (output[4] + "").PadLeft(3, ' ') + "\n" +
						"Longbowmen\t" + (output[5] + "").PadLeft(3, ' ') + "\n" +
						"Light Cavalry\t" + (output[6] + "").PadLeft(3, ' ') + "\n" +
						"Medium Cavalry\t" + (output[7] + "").PadLeft(3, ' ') + "\n" +
						"Heavy Cavalry\t" + (output[8] + "").PadLeft(3, ' ') + "\n```"
					;
					break;
				default:
					returnOut = "Error: Entered value ain't accepted. Exiting...";
					break;
			}//end of switch

			return "Input: "+input+"\n"+returnOut;

		}//end of basic
		public static int[] Roller(int[][] intake)
		{

			int[] mercsAvailable = new int[intake.Length];//should be 9

			for (int x = 0; x < mercsAvailable.Length; x++)
			{
				//Console.WriteLine("intake[x][0]="+ intake[x][0]);
				int subtotal = 0;

				if (intake[x].Length < 2)//checks for the edge case of % of single troop being present.
				{//there's a percentage!
					subtotal = Chance(intake[x][0]);
				}//end of if

				else
				{//There is a number of die value, and a die size.
					for (int y = 0; y < intake[x][0]; y++)
					{
						subtotal += Dice(intake[x][1]);//make rolls, and tally.


					}//end of for loop 2
				}//end of else

				mercsAvailable[x] = subtotal;




				//Console.WriteLine(intake[x][0] + "d" + intake[x][1]);//debugging line, disable
			}//end of for loop



			return mercsAvailable;
		}//end of Roller


		public static int Dice(int die)
		{//executes one cast of the dice.
			die++;//ups the passed value
			int x = rnd.Next(1, die);
			return x;
		}//end of Dice
		public static int Chance(int intake)
		{

			int x = rnd.Next(1, 101);
			if (x < intake)
				return 1;
			return 0;


		}//end of Chance

	}//end of class Mercenary


	


}//end of namespace
