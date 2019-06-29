using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmGame
{
    class Tree : Plant
    {
        // *************** Private Variables **********************
        private int[] position;
        private int state;
        private int fullGrownState = 6;
        private int harvestValue = 150;
        private readonly bool isHoeable = false;
        private readonly bool isSawable = true;

        // *************** Public Variables **********************
        public override int[] Position
        {
            get { return position; }
            set { position = value; }
        }

        public override int State
        {
            get { return state; }
            set { state = value; }
        }

        public override int FullGrownState
        {
            get { return fullGrownState; }
        }

        public override int HarvestValue
        {
            get { return harvestValue; }
        }

        public override bool IsHoeable
        {
            get { return isHoeable; }
        }

        public override bool IsSawable
        {
            get { return isSawable; }
        }
        // *************** Public Methods **********************
        public override void PrintPlant()
        {
            if (state == 0)
            {
                Console.SetCursorPosition(position[0], position[1]);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write(".");
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            else if (state == 2)
            {
                Console.SetCursorPosition(position[0], position[1]);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("|");
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            else if (state == 4)
            {
                Console.SetCursorPosition(position[0], position[1]);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("V");
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            else if (state == 6)
            {
                Console.SetCursorPosition(position[0], position[1]);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("@");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        public override void GrowPlant()
        {
            if (!IsFullGrown())
            {
                state++;
                PrintPlant();
            }
        }

        public override void HarvestPlant()
        {
            State -= 2;
            PrintPlant();
        }

        public override bool IsDebris()
        {
            bool debris = false;

            if (State >= 2)
            {
                debris = true;
            }

            return debris;
        }
        // *************** Private Methods **********************
    }
}
