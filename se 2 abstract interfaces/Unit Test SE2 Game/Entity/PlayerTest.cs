using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SE2_Game.Entity;
using SE2_Game.Game;

namespace Unit_Test_SE2_Game.Entity
{
    [TestClass]
    public class PlayerTest
    {
        private Player player;

        [TestInitialize]
        public void TestInitialize()
        {
            World.Instance.Create(new Size(100, 100), new Size(10, 10), 0);
            this.player = new Player();
        }

        [TestMethod]
        public void TestConstructor()
        {
            Assert.AreEqual(100, this.player.HitPoints,
                "Player is expected to start with 100 hitpoints");
            Assert.AreEqual(new Point(), this.player.Position);
        }

        [TestMethod]
        public void TestPositioningValid()
        {
            // The positioning tests are a bit complex as they need to traverse
            // a couple of methods. For starters, we need a map without any
            // walls to be able to predict the move's results. Next, we make
            // sure the desired interaction is set. Finally we can check if the
            // intended position has been reached.

            // The player starts at (0, 0): moving right should skip one cell,
            // resulting in (10, 0). The same goes for all directions.
            this.player.Interaction(Keys.Right);
            this.player.Update();
            Assert.AreEqual(new Point(10, 0), this.player.Position);
            this.player.Interaction(Keys.Down);
            this.player.Update();
            Assert.AreEqual(new Point(10, 10), this.player.Position);
            this.player.Interaction(Keys.Left);
            this.player.Update();
            Assert.AreEqual(new Point(0, 10), this.player.Position);
            this.player.Interaction(Keys.Up);
            this.player.Update();
            Assert.AreEqual(new Point(0, 0), this.player.Position);

            // Space or other (not WASD-keys) shouldn't change the position
            this.player.Interaction(Keys.Space);
            this.player.Update();
            Assert.AreEqual(new Point(0, 0), this.player.Position);
            this.player.Interaction(Keys.Escape);
            this.player.Update();
            Assert.AreEqual(new Point(0, 0), this.player.Position);
        }

        [TestMethod]
        public void TestPositioningInvalid()
        {
            // We can't move up or left from the starting position
            this.player.Interaction(Keys.Up);
            this.player.Update();
            Assert.AreEqual(new Point(0, 0), this.player.Position);
            this.player.Interaction(Keys.Left);
            this.player.Update();
            Assert.AreEqual(new Point(0, 0), this.player.Position);

            // On each update, the player interaction will be reset. This means
            // that if we want to move right twice, the interaction should be
            // set twice. Failing to do this should not move the player.
            this.player.Interaction(Keys.Right);
            this.player.Update();
            Assert.AreEqual(new Point(10, 0), this.player.Position);
            this.player.Update();
            Assert.AreEqual(new Point(10, 0), this.player.Position);
        }

        [TestMethod]
        public void TestPositioningWalls()
        {
            // A field with only walls should mean we cannot move right
            // or down from the starting position.
            World.Instance.Create(new Size(100, 100), new Size(10, 10), 100);

            this.player.Interaction(Keys.Right);
            this.player.Update();
            Assert.AreEqual(new Point(0, 0), this.player.Position);
            this.player.Interaction(Keys.Down);
            this.player.Update();
            Assert.AreEqual(new Point(0, 0), this.player.Position);
        }
    }
}
