using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game.Models
{
    public class Dealer : Player
    {
        public Dealer(string name) : base(name)
        {

        }
        
        /*public void drawUntil17(Deck deck)
        {
            if (this.Points < 17)
            {
                
                
            }
        }*/
        public Card showOneCard() {
            return Hand[0];
        }
        public int pointsOfOneCard()
        {
            return pointSystem[Hand[0].Number];
        }
    }
}
