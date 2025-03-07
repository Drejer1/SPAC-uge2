using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game.Models
{
    public class Card
    {

        private Tuple<string, string> values;
        private string color;
        private string number;
        public Card(string _color, string _number)
        {
            values = new Tuple<string, string>(_color, _number);
            color = _color;
            number = _number;
        }
        public Tuple<string, string> Values
        {
            get { return values; }
        }
        public string Color { get { return color; } }
        public string Number { get { return number; } }
    }
}
