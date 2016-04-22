using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            bool tempBorder = false;
            int tempTimeStep = 1000;
            int tempWidth = 45;
            begin:
            DrawInstructions(tempBorder, tempWidth, tempTimeStep);
            ConsoleKeyInfo seed = Console.ReadKey(true);
            string temp = seed.Key.ToString();
            if (temp == "B")
            {
                if (tempBorder == true)
                {
                    tempBorder = false;
                }
                else
                {
                    tempBorder = true;
                }
                goto begin;
            }
            else if(temp == "Z")
            {
                tempTimeStep = tempTimeStep + 10000;
                if(tempTimeStep > 91000) { tempTimeStep = 1000; }
                goto begin;
            }
            else if(temp == "S")
            {
                Console.WriteLine(" Please enter a value for the World Grid SIZE between 10 - 45");
                int temp2 = Convert.ToInt32(Console.ReadLine());
                if (temp2 > 45  || temp2 < 10)
                {
                    Console.WriteLine("The entered Value is not in the correct range 10 - 45 please press ENTER to try again");
                    Console.ReadKey();
                    Console.Clear();
                    goto begin;
                }
                tempWidth = temp2;
                goto begin;
            }
            else {}
            Stopwatch timer = new Stopwatch();
            World Game = new World(tempWidth);
            if (tempBorder == true)
            {
                Game.border = true;
            }
            else { Game.border = false; }
            Game.timeStep = Game.timeStep + tempTimeStep;
            Game.live = 0;
            Game.dead = 0;
            Game.ClearGrid();
            Game.Seed(seed.Key.ToString());
            Game.time = 0;            
            UpdateConsole(Game, Game.time);
            Console.ReadKey();
            int step = 999;
            timer.Start();
            for (int i = 0; i < 2;)
            {
                if (timer.ElapsedMilliseconds % 100 == 0)
                { 
                    step++;
                    if (step == Game.timeStep)
                    {
                        {
                            if (Game.gameOver != 0) { goto stats; }
                            UpdateConsole(Game, Game.time);
                            Game.Cycle();
                            Game.time++;
                            step = 0;
                            if (Console.KeyAvailable) { break; }
                        }
                    }
                }
            }
            stats:
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("             Thanks for Playing! - Total Time = " + (Game.time - 1) + " Time Units.");
            Console.WriteLine();
            Console.WriteLine("            During this game there were " + Game.live + " Live Cells created.");
            Console.WriteLine();
            Console.WriteLine("                  There were also " + Game.dead + " Cells destroyed.");
            Console.WriteLine();
            Console.WriteLine("         Press any key to play again!    or  'Q'  to Quit the game.");
            ConsoleKeyInfo endGame = Console.ReadKey(true);
            if (endGame.Key.ToString() != "Q")
                { Console.Clear(); goto begin; }
        }

        public static void DrawInstructions(bool tempBorder, int tempWidth, int timeStep)
        {
            Console.Clear();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(" Border = " + tempBorder + "      Interval " + timeStep + "      Grid = " + tempWidth + " X " + tempWidth);
            Console.WriteLine("__________________________________________________________________________________");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine(" This is an implimentation of Conway's Game Of Life");
            Console.WriteLine();
            Console.WriteLine(" It simulates the life cycle of simple cells in a Virtual World Grid");
            Console.WriteLine();
            Console.WriteLine(" Please choose a Pattern with witch to Seed the Game Grid (enter a letter to choose)");
            Console.WriteLine();
            Console.WriteLine(" Just press ENTER at any time to move forward and except the DEFAULT selections.");
            Console.WriteLine();
            Console.WriteLine(" Press B if you would like a BORDER around the World grid");
            Console.WriteLine();
            Console.WriteLine(" Press S to enter a SIZE for the world between 10 and 45");
            Console.WriteLine();
            Console.WriteLine(" Press Z to increase Time Interval to between 1000 and 91000");
            Console.WriteLine();
            Console.WriteLine("     K = Block");
            Console.WriteLine();
            Console.WriteLine("     L = Blinker");
            Console.WriteLine();
            Console.WriteLine("     G = Glider");
            Console.WriteLine();
            Console.WriteLine("     P = Lightweight Spaceship");
            Console.WriteLine();
            Console.WriteLine("     R = Random Fill");
            Console.WriteLine();
        }

        public static void UpdateConsole(World wld, int t)
        {
            World Game = wld;
            Console.Clear();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(" LIVE = " + Game.live + "    DEAD = " + Game.dead  + "      TIME = " + t + "          " + Game.width + " X " + Game.width + "        Press ENTER to continue.  ");
            Console.WriteLine("___________________________________________________________________________________________");
            Console.ResetColor();
            Console.WriteLine();
            Game.PrintGameGrid();
        }
    }
}
