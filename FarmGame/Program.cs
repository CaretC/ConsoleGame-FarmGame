using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Setup();

            bool playGame = true;
            UI game = new UI();
            Player player = new Player();
            Farm farm = new Farm();

            AddStoreItems(game);
            game.DrawLayout(1);
            player.DrawInitialPlayer();
            game.PrintPlayerCash(player);
            game.PrintInventory(player);
            game.DrawMenuPointer(player);

            while (playGame)
            {
                // *************** Game Controls **********************

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Escape:
                        playGame = false;
                        break;
                    case ConsoleKey.W:
                        player.MovePlayerUp();
                        farm.PrintFarm(player);
                        break;
                    case ConsoleKey.S:
                        player.MovePlayerDown();
                        farm.PrintFarm(player);
                        break;
                    case ConsoleKey.A:
                        player.MovePlayerLeft();
                        farm.PrintFarm(player);
                        break;
                    case ConsoleKey.D:
                        player.MovePlayerRight();
                        farm.PrintFarm(player); 
                        break;
                    case ConsoleKey.DownArrow:
                        game.MenuPointerDown(player);
                        break;
                    case ConsoleKey.UpArrow:
                        game.MenuPointerUp(player);
                        break;
                    case ConsoleKey.Enter:
                        game.BuyItem(player);
                        game.PrintInventory(player);
                        game.DrawMenuPointer(player);
                        break;
                    case ConsoleKey.P:
                        farm.PlowSoil(player);
                        game.PrintInventory(player);
                        break;
                    case ConsoleKey.O:
                        farm.PlantSeed(player);
                        game.PrintInventory(player);
                        break;
                    case ConsoleKey.I:
                        farm.WaterPlant(player);
                        game.PrintInventory(player);
                        break;
                    case ConsoleKey.U:
                        farm.HarvestPlant(player);
                        game.PrintInventory(player);
                        game.PrintPlayerCash(player);
                        game.DrawMenuPointer(player);
                        break;
                    case ConsoleKey.K:
                        farm.ClearDebis(player);
                        game.PrintInventory(player);
                        game.PrintPlayerCash(player);
                        farm.PrintFarm(player);
                        break;
                    case ConsoleKey.L:
                        farm.PlantTree(player);
                        game.PrintInventory(player);
                        break;
                }
            }

            Console.Clear();
            Console.WriteLine("Game Over...");
            Console.ReadLine();
        }

        // *************** Game Setup **********************
        static void Setup()
        {
            Console.Title = "Farm Game";
            Console.CursorVisible = false;
        }

        static void AddStoreItems(UI game)
        {
            game.AddStoreItem("Weat", 2);
            game.AddStoreItem("Soil", 4);
            game.AddStoreItem("Water", 20);
            game.AddStoreItem("Sythe", 25);
            game.AddStoreItem("Hoe", 50);
            game.AddStoreItem("Tree", 100);
            game.AddStoreItem("Saw", 100);
        }


    }
}
