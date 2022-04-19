using System;

namespace Driver {

    class mercenary{
        private Random rnd = new Random();
        public mercenary(){

            //shouldn't need anything other than a default to just get this stuff out of the main.
        }//end of default constructor


        public int Dice(int die)
		  {//executes one cast of the dice.
			die++;//ups the passed value
			int x = rnd.Next(1,die);;
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


    }//end of class

    


}//end of namespace