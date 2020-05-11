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
        public string belongsTo = "";//the path of the card group that contains this card
        public string sideOne = "";//first side of the card
        public string sideTwo = "";//second side of the card
        public bool viewed = false;//a 'viewed' variable to determine if the card has been viewed





        //populates a side of a card with a string
        public void writeToSide(int side, string content)
        {
            if (side == 1)
            {
                this.sideOne = content;
            }
            else
            {
                this.sideTwo = content;
            }

        }

        //set the 'viewed' variable to true 
        //so that it cannot be read twice in the same
        //session.
        public void setToViewed()
        {
            this.viewed = true;
        }


        /// toString() method to display the card's contents.
        /// Used mainly for testing.
        public string toString()
        {
            return this.sideOne + "\n" + this.sideTwo;
        }
    }


}
