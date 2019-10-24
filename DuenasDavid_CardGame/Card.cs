using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertedJSON
{
    class Card
    { 
        private string face;
        private string suit;
        private int points;
        private int totalPoints;
      
      

        public Card(string cardFace, string cardSuit, int cardPoints)
        {
            face = cardFace;
            suit = cardSuit;
            points = cardPoints;
         

        }
     
        
        public static void TotalPoints()
        {
  

                




        }

        public override string ToString()
        {
            return face + " of " + suit + " | " + points + " points.";
            
        }

    }
}
