using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SE2_Game.Game.Map;

namespace Unit_Test_SE2_Game.Game.Map
{
    [TestClass]
    public class GridTest
    {
        private Grid grid;

        [TestInitialize]
        public void TestInitialize()
        {
            this.grid = new Grid(new Size(100, 100), new Size(10, 10), 0);
        }

        [TestMethod]
        public void TestConstructor()
        {
            Assert.AreEqual(new Size(100, 100), this.grid.GridSize);
            Assert.AreEqual(new Size(10, 10), this.grid.CellCount);
            Assert.AreEqual(new Size(10, 10), this.grid.CellSize);
            
            try
            {
                new Grid(new Size(), new Size(), 0);
                Assert.Fail("A cell size of zero should cause an exception");
            }
            catch (DivideByZeroException)
            { }
        }

        [TestMethod]
        public void TestCellTypeAndGoalPosition()
        {
            Assert.AreEqual(Cell.CellType.Normal,
                this.grid.CellTypeAtPosition(new Point()),
                "The player starting position should be normal by default");
            Assert.AreEqual(Cell.CellType.Goal,
                this.grid.CellTypeAtPosition(new Point(90, 90)),
                "The last cell should be the goal cell by default");
            Assert.AreEqual(new Point(90, 90),
                this.grid.GoalPosition,
                "The last cell should be the goal cell by default");

            // Create a grid with only walls
            Grid wallGrid = new Grid(new Size(100, 100), new Size(10, 10), 100);
            Assert.AreEqual(Cell.CellType.Normal,
                wallGrid.CellTypeAtPosition(new Point()),
                "The player starting position should be normal by default");
            Assert.AreEqual(Cell.CellType.Goal,
                wallGrid.CellTypeAtPosition(new Point(90, 90)),
                "The last cell should be the goal cell by default");
            Assert.AreEqual(Cell.CellType.Wall,
                wallGrid.CellTypeAtPosition(new Point(10, 10)),
                "Any not start or goal cell should be a wall");
        }

        [TestMethod]
        public void TestFreePosition()
        {
            // TODO: Implement this when interfaces have been explained.
            // We don't yet test this method because it is coded to return
            // randomized results. There is a way to account for this, but the
            // solution will use interfaces: a concept that is not yet
            // discussed in class. To be implemented.
            Assert.Inconclusive("Implement this when interfaces have been explained");
        }
    }
}
