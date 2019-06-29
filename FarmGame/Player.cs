using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmGame
{
    class Player
    {
        // *************** Private Variables **********************
        private char playerChar = '█';
        private ConsoleColor playerColor = ConsoleColor.Cyan;
        private int playAreaWidth = 100;
        private int playAreaHeight = 3;
        private int[] playerPos = new int[2];
        private int cash = 0;
        private int[] inventory = { 1, 1, 3, 6, 0, 0, 0}; //Seed, Soil, Water, Sythe, Hoe, Trees, Saw
        private Random r = new Random();

        // *************** Public Variables **********************
        public char PlayerChar
        {
            get { return playerChar; }
        }

        public ConsoleColor consoleColor
        {
            get { return playerColor; }
            set { playerColor = value; }
        }
               
        public int[] PlayerPos
        {
            get { return playerPos; }
        }

        public int Cash
        {
            get { return cash; }
            set { cash = value; }
        }

        public int Seeds
        {
            get { return inventory[0]; }
            set { inventory[0] = value; }
        }

        public int Soil
        {
            get { return inventory[1]; }
            set { inventory[1] = value; }
        }

        public int Water
        {
            get { return inventory[2]; }
            set { inventory[2] = value; }
        }

        public int SytheHealth
        {
            get { return inventory[3]; }
            set
            {
                if (value <= 6)
                {
                    inventory[3] = value;
                }

                else if (value > 0 && (value + inventory[3]) <= 6)
                {
                    inventory[3] = value;
                }

                else if ((value + inventory[3]) > 6)
                {
                    inventory[3] = 6;
                }
            }
        }

        public int HoeHealth
        {
            get { return inventory[4]; }
            set
            {
                if (value <= 6)
                {
                    inventory[4] = value;
                }

                else if (value > 0 && (value + inventory[4]) <= 6)
                {
                    inventory[4] = value;
                }

                else if ((value + inventory[4]) > 6)
                {
                    inventory[4] = 6;
                }
            }
        }

        public int Trees
        {
            get { return inventory[5]; }
            set { inventory[5] = value; }
        }

        public int SawHealth
        {
            get { return inventory[6]; }
            set
            {
                if (value <= 6)
                {
                    inventory[6] = value;
                }

                else if (value > 0 && (value + inventory[6]) <= 6)
                {
                    inventory[6] = value;
                }

                else if ((value + inventory[6]) > 6)
                {
                    inventory[6] = 6;
                }
            }
        }
        // *************** Public Methods **********************
        public void DrawInitialPlayer()
        {
            playerPos[0] = r.Next(1, playAreaWidth);
            playerPos[1] = r.Next(3, 22);

            Console.SetCursorPosition(playerPos[0], playerPos[1]);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("█");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void MovePlayerUp()
        {
            if(playerPos[1] > playAreaHeight)
            {
                clearPlayer();
                playerPos[1] = playerPos[1] - 1;
                drawPlayer();
            }
        }

        public void MovePlayerDown()
        {
            if (playerPos[1] < 21)
            {
                clearPlayer();
                playerPos[1] = playerPos[1] + 1;
                drawPlayer();
            }
        }

        public void MovePlayerLeft()
        {
            if (playerPos[0] > 1)
            {
                clearPlayer();
                playerPos[0] = playerPos[0] - 1;
                drawPlayer();
            }
        }

        public void MovePlayerRight()
        {
            if (playerPos[0] < playAreaWidth - 2)
            {
                clearPlayer();
                playerPos[0] = playerPos[0] + 1;
                drawPlayer();
            }
        }

        // *************** Private Methods **********************
        private void drawPlayer()
        {
            Console.SetCursorPosition(playerPos[0], playerPos[1]);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("█");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private void clearPlayer()
        {
            Console.SetCursorPosition(playerPos[0], playerPos[1]);
            Console.Write(" ");
        }
    }
}
