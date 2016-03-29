using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SE2_Game.Entity;
using SE2_Game.Game;

namespace Unit_Test_SE2_Game.Entity
{
    [TestClass]
    public class EnemyTest
    {
        private Enemy enemy;

        [TestInitialize]
        public void TestInitialize()
        {
            World.Instance.Create(new Size(100, 100), new Size(10, 10), 0);
            this.enemy = new Enemy(new Point());
        }

        [TestMethod]
        public void TestConstructor()
        {
            Assert.AreEqual(100, this.enemy.HitPoints,
                "Enemy is expected to start with 100 hitpoints");
            Assert.AreEqual(new Point(), this.enemy.Position);

            Enemy otherEnemy = new Enemy(new Point(50, 50));
            Assert.AreEqual(new Point(50, 50), otherEnemy.Position);
        }

        [TestMethod]
        public void TestPositioningValid()
        {
            // TODO: Implement this when interfaces have been explained.
            // We don't yet test the positioning because it is coded to return
            // randomized results. There is a way to account for this, but the
            // solution will use interfaces: a concept that is not yet
            // discussed in class. To be implemented.
            Assert.Inconclusive("Implement this when interfaces have been explained");

        }
    }
}
