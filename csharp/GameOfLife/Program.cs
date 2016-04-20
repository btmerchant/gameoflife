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
            int tempWidth = 45;
            begin:
            DrawInstructions(tempBorder, tempWidth);
            
            ConsoleKeyInfo seed = Console.ReadKey(true);
            string temp = seed.Key.ToString();
            if (temp == "B")
            {
                tempBorder = true;
                Console.WriteLine("A BORDER was requested Press Enter to proceed.");
                Console.ReadKey();
                goto begin;
            }
            else if(temp == "S")
            {
                Console.WriteLine(" Please enter a value for the world Grid size 10 - 45");
                int temp2 = Convert.ToInt32(Console.ReadLine());
                if (temp2 > 45)
                {
                    Console.WriteLine("Entered Value is not in correct range 10 - 45 please press enter to try again");
                    Console.ReadKey();
                    Console.Clear();
                    goto begin;
                }
                tempWidth = temp2;
                Console.WriteLine(" The grid size has been set to " + tempWidth + " X " + tempWidth + " Press Enter to proceed.");
                Console.ReadKey();
                goto begin;
            }
            else {}
            Stopwatch timer = new Stopwatch();
            World Game = new World(tempWidth);
            if(tempBorder == true) { Game.border = true; }
            Game.live = 0;
            Game.dead = 0;
            Game.ClearGrid();
            Game.Seed(seed.Key.ToString());
            int seconds = 0;            
            UpdateConsole(Game, seconds);
            Console.ReadKey();
            
            for (int i = 0; i < 2;)
            {
                timer.Start();        
                    if (timer.ElapsedMilliseconds % 100 == 0)
                    {
                        UpdateConsole(Game, seconds);
                        Game.Cycle();
                        seconds++;
                        if (Console.KeyAvailable) { break; }
                    }
                //timer.Stop();
            }
            Console.ReadKey();
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("               Thanks for Playing! - Total Time = " + (seconds / 10) + " seconds.");
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

        public static void  DrawInstructions(bool tempBorder, int tempWidth)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(" Border = " + tempBorder + "      Grid = " + tempWidth + " X " + tempWidth);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(" This is an implimentation of Conway's Game Of Life");
            Console.WriteLine();
            Console.WriteLine(" It simulates the life cycle of simple cells in a Virtual World Grid");
            Console.WriteLine();
            Console.WriteLine(" Please choose a Pattern with witch to Seed the Game Grid (enter a letter to choose)");
            Console.WriteLine();
            Console.WriteLine(" Just press ENTER at any time to move forward and except the Default selections.");
            Console.WriteLine();
            Console.WriteLine(" Press b if you would like a Border around the World grid");
            Console.WriteLine();
            Console.WriteLine(" Press s to enter a size for the world between 10 and 45");
            Console.WriteLine();
            Console.WriteLine("     k = Block");
            Console.WriteLine();
            Console.WriteLine("     l = Blinker");
            Console.WriteLine();
            Console.WriteLine("     G = Glider");
            Console.WriteLine();
            Console.WriteLine("     p = Lightweight Spaceship");
            Console.WriteLine();
            Console.WriteLine("     r = Random Fill");
            Console.WriteLine();
        }

        public static void UpdateConsole(World wld, int t)
        {
            World Game = wld;
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("          LIVE = " + Game.live + "    DEAD = " + Game.dead  + "      TIME = " + t + "        Press ENTER to continue.  " + Game.width + " X " + Game.width);
            Console.WriteLine();
            Game.PrintGameGrid();
        }
    }
}
