using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
A class that acts as one flashcard. It stores 
 strings for two sides of the card. 

*/
namespace Flashcards
{
    class Card
    {
        public string id, side1, side2;
        public bool viewed = false;





        //populates a side of a card with a string
        public void writeToSide(int side, string content)
        {
            if (side == 1)
            {
                this.side1 = content;
            }
            else
            {
                this.side2 = content;
            }

        }

        //set the 'viewed' variable to true 
        //so that it cannot be read twice in the same
        //session.
        public void setToViewed()
        {
            this.viewed = true;
        }
    }


}
