using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Driver
{
	class Program
	{
		public static Random rnd = new Random();
		static void Main(string[] args)=> new Program().MainAsync();

	public async Task MainAsync()
	{
	}
		/*{//killed main shit.
			Console.WriteLine("Beginning Mercenary Generator by Carefulrogue\n\nVersion 1.0");
			
			

			/*saving this, but maiming the code hereforward.
			Console.WriteLine("Market Classification\n"
				+ "Population		Class		Example\n"
				+ "0-250		|	VI	|	\n"
				+ "250-624		|	V 	|	Okwalar\n"
				+ "625-2499 	|	IV	|	Burmstone, Fort Weskfen\n"
				+ "2500-4900	|	III	|	\n"
				+ "5000-19999	|	II	|	Arkala\n"
				+ "20000+		|	I	|	Aearvir");


			Boolean end = true;
			while (end)
			{
				Console.WriteLine("Market Size\t\t\t| I\t| II\t| III\t| IV\t| V\t| VI\t| wage(gp)\n" +
									"Light| Infantry| (pike)\t\t| 4d100\t| 5d20\t| 5d10\t| 3d4\t| 1d6\t| 1d2\t| 1(3)\n" +
									"Slingers\t\t\t| 8d20\t| 4d10\t| 2d10\t| 1d6\t| 1d2\t| (70%)\t| 3\n" +
									"Heavy| Infantry\t\t\t| 2d100\t| 5d10\t| 3d8\t| 1d8\t| 1d3\t| (85%)\t| 2\n" +
									"Crossbowmen\t\t\t| 2d100\t| 5d10\t| 3d8\t| 1d8\t| 1d3\t| (85%)\t| 2\n" +
									"Bowmen\t\t\t\t| 8d20\t| 4d10\t| 2d10\t| 1d10\t| 1d3\t| (33%)\t| 2\n" +
									"Longbowmen\t\t\t| 4d20\t| 2d10\t| 1d10\t| 1d3\t| 1\t| (33%)\t| 4\n" +
									"Light| Cavalry\t\t\t| 4d20\t| 2d10\t| 1d10\t| 1d3\t| 1\t| (33%)\t| 3\n" +
									"Medium| Cavalry\t\t\t| 3d20\t| 3d4\t| 4d4\t| 2d4\t| (70%)\t| (23%)\t| 4\n" +
									"Heavy| Cavalry\t\t\t| 4d10\t| 1d10\t| 1d6\t| 1d2\t| (50%)\t| (15%)\t| 6\n");
				Console.Write("Select Market Size (enter Class numeral): ");
				String input = Console.ReadLine();
				Console.WriteLine();
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
			  //the weird nums could be fixed by jagged array, and detection of lack of values on the one side.
			  /* Just savign this set here incase something explodes.
			    {
				{ {4,100},{8,20},{2,100},{2,100},{8,20},{4,20},{4,20},{3,20},{4,10} },
				{ {5,20},{4,10},{5,10},{5,10},{4,10},{2,10},{2,10},{3,4},{1,10} },
				{ {5,10},{2,10},{3,8},{3,8},{2,10},{1,10},{1,10},{4,4},{1,6} },
				{ {3,4},{1,6},{1,8},{1,8},{1,10},{1,3},{1,3},{2,4},{1,6} },
				{ {1,6},{1,2},{1,3},{1,3},{1,3},{1,1},{1,1},{70,100},{50,100} },
				{ {1,2},{70,100},{85,100},{85,100},{33,100},{33,},{33,100},{23,100},{15,100} }

				}*/


/*killing yet more
				int[] output = new int[9];


				switch (input.ToUpper())
				{
					case "I":
						output = Roller(LoadingDice1[0]);
						Console.WriteLine("Results\n" +
							"Light Infantry\t" + (output[0] + "").PadLeft(3, ' ') + "\n" +
							"Slingers\t" + (output[1] + "").PadLeft(3, ' ') + "\n" +
							"Heavy Infantry\t" + (output[2] + "").PadLeft(3, ' ') + "\n" +
							"Crossbowmen\t" + (output[3] + "").PadLeft(3, ' ') + "\n" +
							"Bowmen\t\t" + (output[4] + "").PadLeft(3, ' ') + "\n" +
							"Longbowmen\t" + (output[5] + "").PadLeft(3, ' ') + "\n" +
							"Light Cavalry\t" + (output[6] + "").PadLeft(3, ' ') + "\n" +
							"Medium Cavalry\t" + (output[7] + "").PadLeft(3, ' ') + "\n" +
							"Heavy Cavalry\t" + (output[8] + "").PadLeft(3, ' ')
						);
						break;

					case "II":
						output = Roller(LoadingDice1[1]);
						Console.WriteLine("Results\n" +
							"Light Infantry\t" + (output[0] + "").PadLeft(3, ' ') + "\n" +
							"Slingers\t" + (output[1] + "").PadLeft(3, ' ') + "\n" +
							"Heavy Infantry\t" + (output[2] + "").PadLeft(3, ' ') + "\n" +
							"Crossbowmen\t" + (output[3] + "").PadLeft(3, ' ') + "\n" +
							"Bowmen\t\t" + (output[4] + "").PadLeft(3, ' ') + "\n" +
							"Longbowmen\t" + (output[5] + "").PadLeft(3, ' ') + "\n" +
							"Light Cavalry\t" + (output[6] + "").PadLeft(3, ' ') + "\n" +
							"Medium Cavalry\t" + (output[7] + "").PadLeft(3, ' ') + "\n" +
							"Heavy Cavalry\t" + (output[8] + "").PadLeft(3, ' ')
						);
						break;
					case "III":
						output = Roller(LoadingDice1[2]);
						Console.WriteLine("Results\n" +
							"Light Infantry\t" + (output[0] + "").PadLeft(3, ' ') + "\n" +
							"Slingers\t" + (output[1] + "").PadLeft(3, ' ') + "\n" +
							"Heavy Infantry\t" + (output[2] + "").PadLeft(3, ' ') + "\n" +
							"Crossbowmen\t" + (output[3] + "").PadLeft(3, ' ') + "\n" +
							"Bowmen\t\t" + (output[4] + "").PadLeft(3, ' ') + "\n" +
							"Longbowmen\t" + (output[5] + "").PadLeft(3, ' ') + "\n" +
							"Light Cavalry\t" + (output[6] + "").PadLeft(3, ' ') + "\n" +
							"Medium Cavalry\t" + (output[7] + "").PadLeft(3, ' ') + "\n" +
							"Heavy Cavalry\t" + (output[8] + "").PadLeft(3, ' ')
						);
						break;
					case "IV":
						output = Roller(LoadingDice1[3]);
						Console.WriteLine("Results\n" +
							"Light Infantry\t" + (output[0] + "").PadLeft(3, ' ') + "\n" +
							"Slingers\t" + (output[1] + "").PadLeft(3, ' ') + "\n" +
							"Heavy Infantry\t" + (output[2] + "").PadLeft(3, ' ') + "\n" +
							"Crossbowmen\t" + (output[3] + "").PadLeft(3, ' ') + "\n" +
							"Bowmen\t\t" + (output[4] + "").PadLeft(3, ' ') + "\n" +
							"Longbowmen\t" + (output[5] + "").PadLeft(3, ' ') + "\n" +
							"Light Cavalry\t" + (output[6] + "").PadLeft(3, ' ') + "\n" +
							"Medium Cavalry\t" + (output[7] + "").PadLeft(3, ' ') + "\n" +
							"Heavy Cavalry\t" + (output[8] + "").PadLeft(3, ' ')
						);
						break;
					case "V":
						output = Roller(LoadingDice1[4]);
						Console.WriteLine("Results\n" +
							"Light Infantry\t" + (output[0] + "").PadLeft(3, ' ') + "\n" +
							"Slingers\t" + (output[1] + "").PadLeft(3, ' ') + "\n" +
							"Heavy Infantry\t" + (output[2] + "").PadLeft(3, ' ') + "\n" +
							"Crossbowmen\t" + (output[3] + "").PadLeft(3, ' ') + "\n" +
							"Bowmen\t\t" + (output[4] + "").PadLeft(3, ' ') + "\n" +
							"Longbowmen\t" + (output[5] + "").PadLeft(3, ' ') + "\n" +
							"Light Cavalry\t" + (output[6] + "").PadLeft(3, ' ') + "\n" +
							"Medium Cavalry\t" + (output[7] + "").PadLeft(3, ' ') + "\n" +
							"Heavy Cavalry\t" + (output[8] + "").PadLeft(3, ' ')
						);
						break;
					case "VI":
						output = Roller(LoadingDice1[5]);
						Console.WriteLine("Results\n" +
							"Light Infantry\t" + (output[0] + "").PadLeft(3, ' ') + "\n" +
							"Slingers\t" + (output[1] + "").PadLeft(3, ' ') + "\n" +
							"Heavy Infantry\t" + (output[2] + "").PadLeft(3, ' ') + "\n" +
							"Crossbowmen\t" + (output[3] + "").PadLeft(3, ' ') + "\n" +
							"Bowmen\t\t" + (output[4] + "").PadLeft(3, ' ') + "\n" +
							"Longbowmen\t" + (output[5] + "").PadLeft(3, ' ') + "\n" +
							"Light Cavalry\t" + (output[6] + "").PadLeft(3, ' ') + "\n" +
							"Medium Cavalry\t" + (output[7] + "").PadLeft(3, ' ') + "\n" +
							"Heavy Cavalry\t" + (output[8] + "").PadLeft(3, ' ')
						);
						break;
					default:
						Console.WriteLine("Error: Entered value ain't accepted. Exiting...");
						end = false;
						break;
				}//end of switch

				Console.WriteLine("\n\n\nWould you like to roll for a different settlement?Y/N");
				String question = Console.ReadLine();
				if (question.ToUpper().Equals("Y"))
					continue;
				else
					break;
				
			}//end of while loop (just keep looking until I get tired of testing...)

			Console.WriteLine("Thanks for using my sick project!");

		  }//end of main


		  public static int[] Roller(int[][] intake)
		  {
			
			int[] mercsAvailable = new int[intake.Length];//should be 9
			
			for (int x = 0; x< mercsAvailable.Length; x++)
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
			int x = rnd.Next(1,die);
			return x;
		  }//end of Dice
		public static int Chance(int intake)
		{

			int x = rnd.Next(1, 101);
			if (x < intake)
				return 1;
			return 0;

			
		}//end of Chance


	  }//end of class

  }//end of namespace
