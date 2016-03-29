using System;
using System.Diagnostics;
using System.Drawing;
using SE2_Game.Game.Map;
using SE2_Game.Entity;

namespace SE2_Game.Game
{
    public class World
    {
        public Grid Grid { get; private set; }
        public Player Player { get; private set; }
        public Enemy Enemy { get; private set; }

        public bool GameWon
        {
            get
            {
                return this.Player.Position.Equals(this.Grid.GoalPosition);
            }
        }
        public bool GameOver
        {
            get
            {
                return this.Player.HitPoints == 0;
            }
        }


        /// <summary>
        /// The only existing world instance.
        /// </summary>
        public static World Instance
        {
            get
            {
                if (World.instance == null)
                {
                    World.instance = new World();
                }
                return World.instance;
            }
        }
        private static World instance;

        /// <summary>
        /// Get the time since the game is started. Use this value to time
        /// actions based on intervals, such as doing something every n seconds.
        /// </summary>
        public long Time { get { return this.stopwatch.ElapsedMilliseconds; } }
        private Stopwatch stopwatch = new Stopwatch();

        /// <summary>
        /// Private constructor to be able to ensure that only a single
        /// instance of this class is ever created.
        /// </summary>
        private World()
        {
        }

        /// <summary>
        /// Recreate the world with the given map and cell size.
        /// </summary>
        /// <param name="mapSize">The size of the map in pixels.</param>
        /// <param name="cellCount">The number of cells (width and height).</param>
        /// <param name="wallProbability">The chance that a cell will become
        /// a wall cell, expressed in a range from 0 to 100.</param>
        public void Create(Size mapSize, Size cellCount, int wallProbability)
        {
            this.Grid = new Grid(mapSize, cellCount, wallProbability);
            this.Player = new Player();
            this.Enemy = new Enemy(World.Instance.Grid.FreePosition());
            this.stopwatch.Start();
        }

        /// <summary>
        /// Trigger an update of the game world.
        /// </summary>
        public void Update()
        {
            this.Player.Update();
            this.Enemy.Update();

            if (this.Player.Position.Equals(this.Enemy.Position))
            {
                this.Player.HitPoints -= 5;
            }
        }

        /// <summary>
        /// Redraw the game world with the given Graphics object.
        /// </summary>
        /// <param name="g"></param>
        public void Draw(Graphics g)
        {
            this.Grid.Draw(g);
            this.Enemy.Draw(g);
            this.Player.Draw(g);
        }
    }
}
