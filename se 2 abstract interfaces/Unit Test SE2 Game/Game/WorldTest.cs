using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SE2_Game.Game;

namespace Unit_Test_SE2_Game.Game
{
    [TestClass]
    public class WorldTest
    {
        [TestMethod]
        public void TestCreate()
        {
            // Create a world with two cells: one shall contain the player, one
            // shall contain the goal.
            World.Instance.Create(new Size(20, 10), new Size(2, 1), 0);
            Assert.AreNotEqual(World.Instance.Player.Position,
                World.Instance.Enemy.Position,
                "Enemy should not be positioned on top of player.");
        }

        [TestMethod]
        public void TestGameWon()
        {
            // Create a world with two cells: one shall contain the player, one
            // shall contain the goal.
            World.Instance.Create(new Size(20, 10), new Size(2, 1), 0);
            Assert.IsFalse(World.Instance.GameWon);

            World.Instance.Player.Interaction(Keys.Right);
            World.Instance.Update();
            Assert.IsTrue(World.Instance.GameWon);
        }

        [TestMethod]
        public void TestUpdate()
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
