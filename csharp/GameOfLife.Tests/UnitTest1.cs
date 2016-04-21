using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLife.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void DeadCellPerimiterPattern01()
        {
            World Game = new World();
            Game.gameGrid[09, 10] = 1;
            Game.Shadow();
            Game.Cycle();

            int actual = Game.gameGrid[10, 10];

            int expected = 0; // Dead cell with 1 live neighbor, Cell should Die

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeadCellPerimiterPattern02()
        {
            World Game = new World();
            Game.gameGrid[09, 10] = 1;
            Game.gameGrid[09, 11] = 1;
            Game.Shadow();
            Game.Cycle();

            int actual = Game.gameGrid[10, 10];

            int expected = 0; // Dead cell with 2 live neighbor, Cell should Die

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeadCellPerimiterPattern03()
        {
            World Game = new World();
            Game.gameGrid[09, 10] = 1;
            Game.gameGrid[09, 11] = 1;
            Game.gameGrid[10, 11] = 1;
            Game.Shadow();
            Game.Cycle();

            int actual = Game.gameGrid[10, 10];

            int expected = 1; // Dead cell with 3 live neighbor, Cell should Live

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeadCellPerimiterPattern04()
        {
            World Game = new World();
            Game.gameGrid[09, 10] = 1;
            Game.gameGrid[09, 11] = 1;
            Game.gameGrid[10, 11] = 1;
            Game.gameGrid[11, 11] = 1;
            Game.Shadow();
            Game.Cycle();

            int actual = Game.gameGrid[10, 10];

            int expected = 0; // Dead cell with 4 live neighbor, Cell should Die

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeadCellPerimiterPattern05()
        {
            World Game = new World();
            Game.gameGrid[09, 10] = 1;
            Game.gameGrid[09, 11] = 1;
            Game.gameGrid[10, 11] = 1;
            Game.gameGrid[11, 11] = 1;
            Game.gameGrid[11, 10] = 1;
            Game.Shadow();
            Game.Cycle();

            int actual = Game.gameGrid[10, 10];

            int expected = 0; // Dead cell with 5 live neighbor, Cell should Die

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeadCellPerimiterPattern06()
        {
            World Game = new World();
            Game.gameGrid[09, 10] = 1;
            Game.gameGrid[09, 11] = 1;
            Game.gameGrid[10, 11] = 1;
            Game.gameGrid[11, 11] = 1;
            Game.gameGrid[11, 10] = 1;
            Game.gameGrid[11, 09] = 1;
            Game.Shadow();
            Game.Cycle();

            int actual = Game.gameGrid[10, 10];

            int expected = 0; // Dead cell with 6 live neighbor, Cell should Die

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeadCellPerimiterPattern07()
        {
            World Game = new World();
            Game.gameGrid[09, 10] = 1;
            Game.gameGrid[09, 11] = 1;
            Game.gameGrid[10, 11] = 1;
            Game.gameGrid[11, 11] = 1;
            Game.gameGrid[11, 10] = 1;
            Game.gameGrid[11, 09] = 1;
            Game.gameGrid[10, 09] = 1;
            Game.Shadow();
            Game.Cycle();

            int actual = Game.gameGrid[10, 10];

            int expected = 0; // Dead cell with 7 live neighbor, Cell should Die

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeadCellPerimiterPattern08()
        {
            World Game = new World();
            Game.gameGrid[09, 10] = 1;
            Game.gameGrid[09, 11] = 1;
            Game.gameGrid[10, 11] = 1;
            Game.gameGrid[11, 11] = 1;
            Game.gameGrid[11, 10] = 1;
            Game.gameGrid[11, 09] = 1;
            Game.gameGrid[10, 09] = 1;
            Game.gameGrid[09, 09] = 1;
            Game.Shadow();
            Game.Cycle();

            int actual = Game.gameGrid[10, 10];

            int expected = 0; // Dead cell with 8 live neighbor, Cell should Die

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LiveCellPerimiterPattern09()
        {
            World Game = new World();
            Game.gameGrid[10, 10] = 1;

            Game.gameGrid[09, 10] = 1;
            Game.Shadow();
            Game.Cycle();

            int actual = Game.gameGrid[10, 10];

            int expected = 0; // Live cell with 1 live neighbor, Cell should Die

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LiveCellPerimiterPattern10()
        {
            World Game = new World();
            Game.gameGrid[10, 10] = 1;
            Game.gameGrid[09, 10] = 1;
            Game.gameGrid[09, 11] = 1;
            Game.Shadow();
            Game.Cycle();

            int actual = Game.gameGrid[10, 10];

            int expected = 1; // Live cell with 2 live neighbor, Cell should Live

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LiveCellPerimiterPattern11()
        {
            World Game = new World();
            Game.gameGrid[10, 10] = 1;

            Game.gameGrid[09, 10] = 1;
            Game.gameGrid[09, 11] = 1;
            Game.gameGrid[10, 11] = 1;
            Game.Shadow();
            Game.Cycle();

            int actual = Game.gameGrid[10, 10];

            int expected = 1; // Live cell with 3 live neighbor, Cell should Live

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LiveCellPerimiterPattern12()
        {
            World Game = new World();
            Game.gameGrid[10, 10] = 1;

            Game.gameGrid[09, 10] = 1;
            Game.gameGrid[09, 11] = 1;
            Game.gameGrid[10, 11] = 1;
            Game.gameGrid[11, 11] = 1;
            Game.Shadow();
            Game.Cycle();

            int actual = Game.gameGrid[10, 10];

            int expected = 0; // Live cell with 4 live neighbor, Cell should Die

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LiveCellPerimiterPattern13()
        {
            World Game = new World();
            Game.gameGrid[10, 10] = 1;

            Game.gameGrid[09, 10] = 1;
            Game.gameGrid[09, 11] = 1;
            Game.gameGrid[10, 11] = 1;
            Game.gameGrid[11, 11] = 1;
            Game.gameGrid[11, 10] = 1;
            Game.Shadow();
            Game.Cycle();

            int actual = Game.gameGrid[10, 10];

            int expected = 0; // Live cell with 5 live neighbor, Cell should Die

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LiveCellPerimiterPattern14()
        {
            World Game = new World();
            Game.gameGrid[10, 10] = 1;

            Game.gameGrid[09, 10] = 1;
            Game.gameGrid[09, 11] = 1;
            Game.gameGrid[10, 11] = 1;
            Game.gameGrid[11, 11] = 1;
            Game.gameGrid[11, 10] = 1;
            Game.gameGrid[11, 09] = 1;
            Game.Shadow();
            Game.Cycle();

            int actual = Game.gameGrid[10, 10];

            int expected = 0; // Live cell with 6 live neighbor, Cell should Die

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LiveCellPerimiterPattern15()
        {
            World Game = new World();
            Game.gameGrid[10, 10] = 1;

            Game.gameGrid[09, 10] = 1;
            Game.gameGrid[09, 11] = 1;
            Game.gameGrid[10, 11] = 1;
            Game.gameGrid[11, 11] = 1;
            Game.gameGrid[11, 10] = 1;
            Game.gameGrid[11, 09] = 1;
            Game.gameGrid[10, 09] = 1;
            Game.Shadow();
            Game.Cycle();

            int actual = Game.gameGrid[10, 10];

            int expected = 0; // Live cell with 7 live neighbor, Cell should Die

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LiveCellPerimiterPattern16()
        {
            World Game = new World();
            Game.gameGrid[09, 10] = 1;
            Game.gameGrid[09, 11] = 1;
            Game.gameGrid[10, 11] = 1;
            Game.gameGrid[11, 11] = 1;
            Game.gameGrid[11, 10] = 1;
            Game.gameGrid[11, 09] = 1;
            Game.gameGrid[10, 09] = 1;
            Game.gameGrid[09, 09] = 1;
            Game.Shadow();
            Game.Cycle();

            int actual = Game.gameGrid[10, 10];

            int expected = 0; // Live cell with 8 live neighbor, Cell should Die

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StillLifePattern17()
        {
            int size = 15;
            World Game = new World(size);
            Game.Seed("K"); // Still Life Block
            Game.Cycle(); // Simulate a time tick

            int[,] expected = new int[size, size]; // Fill the test grid with the expected result pattern
            expected[02, 02] = 1;
            expected[03, 02] = 1;
            expected[02, 03] = 1;
            expected[03, 03] = 1;

            for(int x = 0; x < size; x++) // Iterate through the grid and verify against sample pattern
            {
                for(int y = 0; y < size; y++)
                {
                    Assert.AreEqual(expected[x,y], Game.gameGrid[x,y]);
                }
            }                  
        }

        [TestMethod]
        public void OscilatorPattern18()
        {
            int size = 15;
            World Game = new World(size);
            Game.Seed("L"); // Oscilator Block
            Game.Cycle(); // Simulate a time tick

            int[,] expected = new int[size, size]; // Fill the test grid with the expected result pattern
            expected[01, 03] = 1;
            expected[02, 03] = 1;
            expected[03, 03] = 1;


            for (int x = 0; x < size; x++) // Iterate through the grid and verify against sample pattern
            {
                for (int y = 0; y < size; y++)
                {
                    Assert.AreEqual(expected[x, y], Game.gameGrid[x, y]);
                }
            }
        }

        [TestMethod]
        public void SpaceshipPattern19()
        {
            int size = 15;
            World Game = new World(size);
            Game.Seed("G"); // Glider Block
            Game.Cycle(); // Simulate a time tick

            int[,] expected = new int[size, size]; // Fill the test grid with the expected result pattern
            expected[02, 03] = 1;
            expected[04, 03] = 1;
            expected[04, 04] = 1;
            expected[03, 04] = 1;
            expected[03, 05] = 1;


            for (int x = 0; x < size; x++) // Iterate through the grid and verify against sample pattern
            {
                for (int y = 0; y < size; y++)
                {
                    Assert.AreEqual(expected[x, y], Game.gameGrid[x, y]);
                }
            }
        }
    }
}
