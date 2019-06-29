using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmGame
{
    class UI
    {
        // *************** Private Variables **********************
        private int playAreaWidth;
        private int playAreaHeight;
        private int menuPos = 0;
        private List<Item> menuItems = new List<Item>();        

        // *************** Public Variables **********************
        public int PlayAreaWidth
        {
            get { return playAreaWidth; }
        }

        public int PlayAreaHeight
        {
            get { return playAreaHeight; }
            set { playAreaHeight = value; }
        }

        // *************** Public Methods **********************
        public void DrawLayout(int option)
        {
            switch (option)
            {
                case 1:
                    DrawLayout1();
                    break;

                default:
                    break;
            }
        }

        public void DrawMenuPointer(Player player)
        {
            int pos = menuPos + 4;

            if (player.Cash >= menuItems[menuPos].Cost)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.SetCursorPosition(102, pos);
                Console.Write(">");
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(102, pos);
                Console.Write(">");
                Console.ForegroundColor = ConsoleColor.Gray;
            }


        }

        public void MenuPointerDown(Player player)
        {
            if (menuPos < menuItems.Count - 1)
            {
                ClearMenuPointer();
                menuPos++;
                DrawMenuPointer(player);
            }

            else
            {
                ClearMenuPointer();
                menuPos = 0;
                DrawMenuPointer(player);
            }
        }

        public void MenuPointerUp(Player player)
        {
            if (menuPos > 0)
            {
                ClearMenuPointer();
                menuPos--;
                DrawMenuPointer(player);
            }

            else
            {
                ClearMenuPointer();
                menuPos = menuItems.Count - 1;
                DrawMenuPointer(player);
            }
        }

        public void PrintPlayerCash(Player player)
        {
            Console.SetCursorPosition(2, 1);
            Console.Write("              ");
            Console.SetCursorPosition(2, 1);
            Console.Write("CASH: ");

            if (player.Cash == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            Console.Write(string.Format("{0}GP", player.Cash.ToString()));
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void BuyItem(Player player)
        {
            if (player.Cash >= menuItems[menuPos].Cost)
            {
                switch (menuItems[menuPos].Name)
                {
                    case "Weat":
                        AddSeed(player);
                        break;
                    case "Soil":
                        AddSoil(player);
                        break;
                    case "Water":
                        AddWater(player);
                        break;
                    case "Sythe":
                        repairSythe(player);
                        break;
                    case "Hoe":
                        repairHoe(player);
                        break;
                    case "Tree":
                        AddTree(player);
                        break;
                    case "Saw":
                        repairSaw(player);
                        break;
                }
            }
            
            
        }

        public void AddStoreItem(string name, int cost)
        {
            Item newItem = new Item(name, cost);

            menuItems.Add(newItem);
        }

        public void PrintInventory(Player player)
        {
            ClearInventory();

            Console.SetCursorPosition(2, 23);
            Console.Write("INVENTORY");

            Console.SetCursorPosition(4, 24);
            Console.Write("Weat   ");
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < player.Seeds; i++)
            {
                Console.Write("■ ");
            }
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.SetCursorPosition(4, 25);
            Console.Write("Soil   ");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            for (int i = 0; i < player.Soil; i++)
            {
                Console.Write("■ ");
            }
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.SetCursorPosition(4, 26);
            Console.Write("Water  ");
            Console.ForegroundColor = ConsoleColor.Blue;
            for (int i = 0; i < player.Water; i++)
            {
                Console.Write("■ ");
            }
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.SetCursorPosition(4, 27);
            Console.Write("Trees  ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            for (int i = 0; i < player.Trees; i++)
            {
                Console.Write("■ ");
            }
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.SetCursorPosition(26, 23);
            Console.Write("TOOLS");

            Console.SetCursorPosition(28, 24);
            Console.Write("Sythe  ");
            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < player.SytheHealth; i++)
            {
                Console.Write("■");
            }
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.SetCursorPosition(28, 25);
            Console.Write("Hoe    ");
            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < player.HoeHealth; i++)
            {
                Console.Write("■");
            }
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.SetCursorPosition(28, 26);
            Console.Write("Saw    ");
            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < player.SawHealth; i++)
            {
                Console.Write("■");
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        // *************** Private Methods **********************
        private void DrawLayout1()
        {
            DrawBorder();
            DrawVerticalLine(100);
            DrawHorizonalLine(2, 100);
            DrawHorizonalLine(22, 100);
            int[] startPos = { 24, 22 };
            DrawVerticalLine(startPos, 8);
            startPos[0] = 42;
            startPos[1] = 22;
            DrawVerticalLine(startPos, 8);
            PrintMenu();

            playAreaWidth = 100;
            PlayAreaHeight = 2;
        }

        private void DrawBorder()
        {
            DrawTopBorder();

            DrawLeftBorder();

            DrawRightBorder();

            DrawBottomBorder();

            Console.SetCursorPosition(0, 0);
        }

        private void DrawTopBorder()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.Write("╔");

            for (int i = 0; i < Console.WindowWidth - 2; i++)
            {
                Console.Write("═");
            }

            Console.Write("╗");

            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private void DrawLeftBorder()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            for (int i = 1; i < Console.WindowHeight - 1; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("║");
            }

            Console.SetCursorPosition(0, Console.WindowHeight - 1);
            Console.Write("╚");

            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private void DrawRightBorder()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            int width = Console.WindowWidth - 1;
            for (int i = 1; i < Console.WindowHeight - 1; i++)
            {
                Console.SetCursorPosition(width, i);
                Console.Write("║");
            }

            Console.SetCursorPosition(width, Console.WindowHeight - 1);
            Console.Write("╝");

            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private void DrawBottomBorder()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.SetCursorPosition(1, Console.WindowHeight - 1);
            for (int i = 0; i < Console.WindowWidth - 2; i++)
            {
                Console.Write("═");
            }

            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private void DrawVerticalLine(int leftPos)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            int left = leftPos - 1;

            Console.SetCursorPosition(left, 0);
            Console.Write("╦");

            for (int i = 1; i < Console.WindowHeight-1; i++)
            {
                Console.SetCursorPosition(left, i);
                Console.Write("║");
            }

            Console.SetCursorPosition(left, Console.WindowHeight - 1);
            Console.Write("╩");

            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private void DrawVerticalLine(int[] startPos, int height)
        {
            Console.SetCursorPosition(startPos[0], startPos[1]);

            Console.ForegroundColor = ConsoleColor.Green;

            Console.Write("╤");

            int startLine = startPos[1] + 1;

            for (int i = startLine; i < startLine + height - 2; i++)
            {
                Console.SetCursorPosition(startPos[0], i);
                Console.Write("│");
            }

            Console.SetCursorPosition(startPos[0], Console.WindowHeight - 1);
            Console.Write("╧");

            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private void DrawHorizonalLine(int topPos, int width)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.SetCursorPosition(0, topPos);
            Console.Write("╠");

            for (int i = 0; i < width-2; i++)
            {
                Console.Write("═");
            }

            Console.SetCursorPosition(width-1, topPos);
            Console.Write("╣");

            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private void PrintMenu()
        {
            menuPos = 0;

            Console.SetCursorPosition(108, 1);
            Console.Write("STORE");
            Console.SetCursorPosition(108, 2);
            Console.Write("*****");

            Console.SetCursorPosition(101, 3);
            Console.Write("BUY");

            int startLine = 4;

            for (int i = 0; i < menuItems.Count; i++)
            {
                Item item = menuItems[i];

                Console.SetCursorPosition(104, startLine + i);
                Console.Write(string.Format("{0}\t{1}GP", item.Name, item.Cost));
            }

            //DrawMenuPointer();
        }

        private void ClearMenuPointer()
        {
            int pos = menuPos + 4;

            Console.SetCursorPosition(102, pos);
            Console.Write(" ");
        }        

        private void ClearInventory()
        {
            for (int i = 23; i < 29; i++)
            {
                Console.SetCursorPosition(4, i);
                Console.Write("                   ");

                Console.SetCursorPosition(32, i);
                Console.Write("         ");
            }
        }

        private void AddSeed(Player player)
        {
            if (player.Seeds < 6)
            {
                player.Cash -= menuItems[menuPos].Cost;
                PrintPlayerCash(player);
                player.Seeds++;
            }
        }

        private void AddSoil(Player player)
        {
            if (player.Soil < 6)
            {
                player.Cash -= menuItems[menuPos].Cost;
                PrintPlayerCash(player);
                player.Soil++;
            }
        }

        private void AddWater(Player player)
        {
            if (player.Water < 6)
            {
                player.Cash -= menuItems[menuPos].Cost;
                PrintPlayerCash(player);
                player.Water++;
            }
        }

        private void AddTree(Player player)
        {
            if (player.Trees < 6)
            {
                player.Cash -= menuItems[menuPos].Cost;
                PrintPlayerCash(player);
                player.Trees++;
            }
        }

        private void repairSythe(Player player)
        {
            if (player.SytheHealth < 6)
            {
                player.Cash -= menuItems[menuPos].Cost;
                PrintPlayerCash(player);
                player.SytheHealth += 6;
            }
        }

        private void repairHoe(Player player)
        {
            if (player.HoeHealth < 6)
            {
                player.Cash -= menuItems[menuPos].Cost;
                PrintPlayerCash(player);
                player.HoeHealth += 6;
            }
        }

        private void repairSaw(Player player)
        {
            if (player.SawHealth < 6)
            {
                player.Cash -= menuItems[menuPos].Cost;
                PrintPlayerCash(player);
                player.SawHealth += 6;
            }
        }
    }
}
