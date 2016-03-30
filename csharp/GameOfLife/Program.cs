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
        begin:
            Stopwatch timer = new Stopwatch();
            World Game = new World();
            World.live = 0;
            World.dead = 0;
            Game.ClearGrid();
            Console.WriteLine();
            Console.WriteLine("Please choose a Pattern with witch to Seed the Game Grid (enter a letter to choose)");
            Console.WriteLine();
            Console.WriteLine("b = Block");
            Console.WriteLine();
            Console.WriteLine("l = Blinker");
            Console.WriteLine();
            Console.WriteLine("G = Glider");
            Console.WriteLine();
            Console.WriteLine("r = Random Fill");
            Console.WriteLine();
            ConsoleKeyInfo seed = Console.ReadKey(true);
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
            Console.WriteLine("            During this game there were " + World.live + " Live Cells created.");
            Console.WriteLine();
            Console.WriteLine("                    There were also " + World.dead + " Cells destroyed.");
            Console.WriteLine();
            Console.WriteLine("                       Press any key to play again!");
            Console.ReadKey();
            Console.Clear();
            goto begin;
        }

        public static void UpdateConsole(World wld, int t)
        {
            World World = wld;
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("          LIVE = " + World.live + "    DEAD = " + World.dead  + "      TIME = " + t + "        Press any key to exit.");
            Console.WriteLine();
            World.PrintGameGrid();
        }
    }
}
