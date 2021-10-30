using System;
using System.Collections.Generic;
using System.Text;

namespace JavaToCS
{
    class Player
    {
        private readonly char marker;
        private readonly string name;

        public Player(string name, char marker)
        {
            this.marker = marker;
            this.name = name;
        }

        public char getMarker()
        {
            return marker;
        }
        public string getName()
        {
            return name;
        }

    }
}
