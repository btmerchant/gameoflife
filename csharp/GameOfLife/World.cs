﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class World
    {
        private int _width;
        private int _size;
        private int _live;
        private int _dead;
        private bool _border;
        private int[,] _gameGrid;
        private int[,] _limbo;

        public int[,] gameGrid
        {
            get { return _gameGrid; }
            set { _gameGrid = value; }
        }

        public int live
        {
            get { return _live; }
            set { _live = value; }
        }

        public int dead
        {
            get { return _dead; }
            set { _dead = value; }
        }

        public bool border
        {
            get { return _border; }
            set { _border = value; }
        }

        public int[,] limbo
        {
            get { return _limbo; }
            set { _limbo = value; }
        }

        public int size
        {
            get { return _size; }
            set { _size = value; }
        }

        public int width
        {
            get { return _width; }
            set { _width = value; }
        }

        public World()
        {
            border = false;
            width = 45;
            size = width - 1;
            gameGrid = new int[width, width];
            limbo = new int[width, width];
        }

        public World(int sz)
        {
            border = false;
            width = sz;
            size = width - 1;
            gameGrid = new int[width, width];
            limbo = new int[width, width];
        }

        public void PrintGameGrid()
        {
            int col = 0;
            int row = 0;
            for (row = 0; row <= size; row++)
            {
                for (col = 0; col <= size; col++)
                {
                    if(border)
                    { 
                        if (row == 0 || row == size)
                        {
                            Console.Write("* ");
                        }
                        else if(col == 0)
                        {
                            Console.Write("* ");
                        }
                        else if (col == size)
                        {
                            Console.Write("*");
                        } 
                        else if(row == 0 && col == size)
                        {
                            Console.Write(" *");
                        }
                        else
                        {
                            if (gameGrid[row, col] == 0)
                                Console.Write("  ");
                            else
                                Console.Write("O ");
                        }
                    }
                    else
                    { 
                        if (gameGrid[row, col] == 0)
                            Console.Write("  ");
                            else
                                Console.Write("O ");
                    }
                }
                Console.WriteLine();
            }
        }

        public void Cycle()
        {
            int status = 0;
            for (int row = 0; row <= size; row++)
            { 
                for (int col = 0; col <= size; col++)
                {
                    status = gameGrid[row, col];
                    status = Rules(row, col, status);
                    limbo[row, col] = status;
                }
            }
            UpdateGrid();
        }

        public void RandomGrid()
        {
            Random rand = new Random();
            int r = 0;
  
            for (int x = 0; x <= size; x++)
                for (int y = 0; y <= size; y++)
                {
                    r = rand.Next(0,2);
                    if(r == 1)
                        live = live + 1;
                    gameGrid[x, y] = r;
                    Shadow();
                }
        }

        public void UpdateGrid()
        {
            for (int x = 0; x <= size; x++)
                for (int y = 0; y <= size; y++)
                {
                    gameGrid[x, y] = limbo[x, y];
                }
        }

        public void ClearGrid()
        {
            for (int x = 0; x <= size; x++)
                for (int y = 0; y <= size; y++)
                {
                    gameGrid[x, y] = 0;
                }
        }

        public int Rules(int row, int col, int status)
        {
            int Status = status;
            int count = 0;
            count = PerimiterCount(row, col);
            if (Status == 1)
            { 
                while (status == 1)
                {
                    // Rule 1. Any live cell with fewer than two live neighbours dies, as if caused by under-population.
                    if (count < 2)
                    {
                        { status = 0; dead++; }
                        break;
                    }

                    // Rule 2. Any live cell with two or three live neighbours lives on to the next generation.
                    if ((count > 1) && (count < 4))
                        break;

                    // Rule 3. Any live cell with more than three live neighbours dies, as if by overcrowding.
                    if (count > 3)
                    { status = 0; dead++; }
                }
            }
            else
            {
                // Rule 4. Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
                if (count == 3)
                { status = 1; live++; }
            }
            return status;
        }

        public int PerimiterCount(int row, int col) // Returns a count of all live cells int the perimiter of the indexed cell
        {
            bool top = false;
            bool right = false;
            bool bottom = false;
            bool left = false;
            if (row == 0) { top = true; }
            if (col == size) { right = true; }
            if (row == size) { bottom = true; }
            if (col == 0) { left = true; }

            int count = 0;
            if (!top)
            { 
                if (gameGrid[row - 1, col] == 1) // Top Center
                    count++;
            }
            if (!(top || right))
            { 
                if (gameGrid[row - 1, col + 1] == 1) // Top Right
                    count++;
            }
            if (!right)
            { 
                if (gameGrid[row, col + 1] == 1) // Center Right
                    count++;
            }
            if (!(right || bottom))
            { 
                if (gameGrid[row + 1, col + 1] == 1) // Bottom Right
                    count++;
            }
            if (!bottom)
            { 
                if (gameGrid[row + 1, col] == 1) // Bottom Center
                    count++;
            }
            if (!(bottom || left))
            { 
            if (gameGrid[row + 1, col - 1] == 1) // Bottom Left
                count++;
            }
            if (!left)
            { 
                if (gameGrid[row, col - 1] == 1) // Center Left
                    count++;
            }
            if (!(top || left))
            { 
                if (gameGrid[row - 1, col - 1] == 1) // Top Left
                    count++;
            }
            return count;
        }

        public void Shadow() // Mirror the gameGrid to the shadow Limbo array, for pattern init
        {
            for (int x = 0; x <= size; x++)
                for (int y = 0; y <= size; y++)
                {
                    limbo[x, y] = gameGrid[x, y];
                }
        }

        public void Seed(string pattern)
        {
            int s = gameGrid.GetLength(0);
            switch (pattern)                // row, col on indexing
            {
                // Still Lifes
                case "K":  // Block
                    {
                        gameGrid[09, 09] = 1;
                        gameGrid[10, 09] = 1;
                        gameGrid[09, 10] = 1;
                        gameGrid[10, 10] = 1;
                        live = live + 4;
                        break;
                    }

                // Oscilators
                case "L": // Blinker
                    {
                        gameGrid[09, 09] = 1;
                        gameGrid[09, 10] = 1;
                        gameGrid[09, 11] = 1;
                        live = live + 3;
                        break;
                    }

                //Spaceships
                case "G": // Glider
                    {
                        gameGrid[10, 09] = 1;
                        gameGrid[11, 10] = 1;
                        gameGrid[09, 11] = 1;
                        gameGrid[10, 11] = 1;
                        gameGrid[11, 11] = 1;
                        live = live + 5;
                        break;
                    }

                case "P": // Lightweight Spaceship
                    {
                        gameGrid[10, 10] = 1;
                        gameGrid[10, 13] = 1;
                        gameGrid[11, 14] = 1;
                        gameGrid[12, 10] = 1;
                        gameGrid[12, 14] = 1;
                        gameGrid[13, 11] = 1;
                        gameGrid[13, 12] = 1;
                        gameGrid[13, 13] = 1;
                        gameGrid[13, 14] = 1;
                        live = live + 9;
                        break;
                    }

                case "T":
                    {
                        gameGrid[10, 09] = 1;
                        gameGrid[09, 09] = 1;
                        gameGrid[08, 10] = 1;
                        gameGrid[09, 11] = 1;
                        gameGrid[07, 08] = 1;
                        gameGrid[07, 09] = 1;
                        gameGrid[06, 08] = 1;
                        gameGrid[06, 07] = 1;
                        live = live + 8;
                        break;
                    }

                case "R":
                    {
                        RandomGrid();
                        break;
                    }

                default:
                    {
                        RandomGrid();
                        break;
                    }
              
            }
            Shadow();
        }
    }
}
