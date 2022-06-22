using System;
/*
namespace Driver {

    class mercenary{
        private Random rnd = new Random();
        public mercenary(){
            
            //shouldn't need anything other than a default to just get this stuff out of the main.
        }//end of default constructor


        public int Dice(int die)
		  {//executes one cast of the dice.
			die++;//ups the passed value
			int x = rnd.Next(1,die);
			return x;
		  }//end of Dice
		public int Chance(int intake)
		{

			int x = rnd.Next(1, 101);
			if (x < intake)
				return 1;
			return 0;

			
		}//end of Chance
        public void selector(){
            //handles the logic of requesting input, and provisioning instructions.
        }//end of selector

        

        public void toString(){//handles the output results, make procedural, instead of brute force.

       }//end of toString
       public void generate(){
            //execute main mercenary process 
            System.out.println("TODO: fix this");
            while (end){
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




       }//end of generate

    }//end of class

    


}//end of namespace*/