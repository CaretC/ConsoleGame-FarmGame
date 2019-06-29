using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmGame
{
    class Farm
    {
        // *************** Private Variables **********************
        private List<int[]> soilPositions = new List<int[]>();
        private List<Plant> plantsList = new List<Plant>();

        // *************** Public Methods **********************
        public void PlowSoil(Player player)
        {
            if (player.Soil > 0)
            {
                if (player.PlayerPos[0] > 1)
                {
                    int[] pos = { player.PlayerPos[0] - 1, player.PlayerPos[1] };

                    if (!IsSoil(pos) && !IsPlant(pos))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.SetCursorPosition(player.PlayerPos[0] - 1, player.PlayerPos[1]);
                        Console.Write("░");
                        player.Soil--;
                        soilPositions.Add(pos);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }                   

                }
            }
        }

        public void PlantSeed(Player player)
        {
            int[] pos = { player.PlayerPos[0] - 1, player.PlayerPos[1] };

            if (IsSoil(pos))
            {
                if (player.Seeds > 0)
                {
                    RemoveSoil(pos);

                    player.Seeds--;

                    Weat newPlant = new Weat();
                    newPlant.Position = pos;
                    newPlant.PrintPlant();

                    plantsList.Add(newPlant);
                }
            }
        }

        public void PlantTree(Player player)
        {
            int[] pos = { player.PlayerPos[0] - 1, player.PlayerPos[1] };

            if (player.PlayerPos[0] > 1)
            {
                if (!IsSoil(pos) && !IsPlant(pos))
                {
                    if (player.Trees > 0)
                    {
                        player.Trees--;

                        Tree newTree = new Tree();
                        newTree.Position = pos;
                        newTree.PrintPlant();

                        plantsList.Add(newTree);
                    }
                }
            }
        }

        public void WaterPlant(Player player)
        {
            int[] pos = { player.PlayerPos[0] - 1, player.PlayerPos[1] };

            if (IsPlant(pos))
            {
                if (player.Water > 0)
                {
                    foreach (var plant in plantsList)
                    {
                        if (plant.Position[0] == pos[0] && plant.Position[1] == pos[1])
                        {
                            if (!plant.IsFullGrown())
                            {
                                plant.GrowPlant();
                                plant.PrintPlant();
                                player.Water--;
                            }
                        }
                    }
                }
            }
        }

        public void HarvestPlant(Player player)
        {
            int[] pos = { player.PlayerPos[0] - 1, player.PlayerPos[1] };

            if (IsPlant(pos))
            {
                if (player.SytheHealth > 0)
                {
                    foreach (var plant in plantsList)
                    {
                        if (plant.Position[0] == pos[0] && plant.Position[1] == pos[1])
                        {
                            if (plant.IsFullGrown())
                            {
                                player.SytheHealth--;
                                player.Cash += plant.HarvestValue;
                                plant.HarvestPlant();
                            }
                        }
                    }
                }
            }
        }

        public void ClearDebis(Player player)
        {
            int[] pos = { player.PlayerPos[0] - 1, player.PlayerPos[1] };

            if (IsPlant(pos))
            {
                int index = 0;

                foreach (var plant in plantsList)
                {
                    if (plant.Position[0] == pos[0] && plant.Position[1] == pos[1])
                    {
                        if (plant.IsDebris() && plant.IsHoeable)
                        {
                            if (player.HoeHealth > 0)
                            {
                                player.HoeHealth--;
                                plantsList.RemoveAt(index);
                                Console.SetCursorPosition(pos[0], pos[1]);
                                Console.Write(" ");
                                break;
                            }
                        }

                        else if (plant.IsDebris() && plant.IsSawable)
                        {
                            if (player.SawHealth > 0)
                            {
                                player.SawHealth -=3;
                                player.Cash += 75;
                                plantsList.RemoveAt(index);
                                Console.SetCursorPosition(pos[0], pos[1]);
                                Console.Write(" ");
                                break;
                            }
                        }
                    }

                    index++;
                }
            }
        }

        public void PrintFarm(Player player)
        {
            int[] playerPos = { player.PlayerPos[0], player.PlayerPos[1] };

            foreach (var position in soilPositions)
            {
                int[] pos = { position[0], position[1] };

                if (pos[0] == playerPos[0] && pos[1] == playerPos[1])
                {

                }

                else
                {
                    if (IsSoil(pos))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.SetCursorPosition(position[0], position[1]);
                        Console.Write("░");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }

                }
            }

            //foreach (var plant in plants)
            //{
            //    int[] pos = { plant.Position[0], plant.Position[1] };

            //    if (pos[0] == playerPos[0] && pos[1] == playerPos[1])
            //    {

            //    }

            //    else
            //    {
            //        if (IsPlant(pos))
            //        {
            //            plant.PrintPlant();
            //        }
            //    }
            //}

            foreach (var plant in plantsList)
            {
                int[] pos = { plant.Position[0], plant.Position[1] };

                if (pos[0] == playerPos[0] && pos[1] == playerPos[1])
                {

                }

                else
                {
                    if (IsPlant(pos))
                    {
                        plant.PrintPlant();
                    }
                }
            }
        }

        // *************** Private Methods **********************
        private bool IsSoil(int[] pos)
        {
            bool soil = false;

            foreach (var position in soilPositions)
            {
                if (position[0] == pos[0] && position[1] == pos[1])
                {
                    soil = true;
                }
            }

            return soil;
        }

        private bool IsPlant(int[] pos)
        {
            bool plant = false;

            //foreach (var position in plantPositions)
            //{
            //    if (position[0] == pos[0] && position[1] == pos[1])
            //    {
            //        plant = true;
            //    }
            //}

            foreach (var plantPos in plantsList)
            {
                if (plantPos.Position[0] == pos[0] && plantPos.Position[1] == pos[1])
                {
                    plant = true;
                }
            }

            return plant;
        }

        private void RemoveSoil(int[] pos)
        {
            for (int i = 0; i < soilPositions.Count; i++)
            {
                if (pos[0] == soilPositions[i][0] && pos[1] == soilPositions[i][1])
                {
                    soilPositions.RemoveAt(i);
                }
            }
        }
    }
}
