using System.Drawing;
using SE2_Game.Game;

namespace SE2_Game.Entity
{
    public class Enemy
    {
        // The lower this value is, the faster the enemy moves
        private int msBetweenMoves = 100;

        private const int borderSize = 2;
        private Pen pen = new Pen(Color.Black, borderSize);
        private SolidBrush brush = new SolidBrush(Color.FromArgb(215, 38, 61));

        private long previousMoveTime;
        public Point Position { get; private set; }

        /// <summary>
        /// The HitPoints for the enemy. If this equals zero, no more enemy.
        /// </summary>
        public int HitPoints
        {
            get
            {
                return this.hitPoints;
            }
            set
            {
                if (value >= 0)
                {
                    this.hitPoints = value;
                }
            }
        }
        private int hitPoints;

        // We need a font and formatter to draw strings. Instead of creating
        // them on each drawing call, we define them once here.
        private Font font = new Font("Arial", 8);
        private StringFormat stringFormat = new StringFormat();

        public Enemy(Point position)
        {
            this.Position = position;
            this.HitPoints = 100;

            // Make drawn string appear centered in the positioning rectangle.
            this.stringFormat.Alignment = StringAlignment.Center;
            this.stringFormat.LineAlignment = StringAlignment.Center;
        }

        /// <summary>
        /// Update the enemy position based on a random direction.
        /// </summary>
        public void Update()
        {
            if (World.Instance.Time - this.previousMoveTime >= this.msBetweenMoves)
            {
                Action[] moves = new Action[5]
                {
                    Action.MoveUp, Action.MoveRight, Action.MoveDown, Action.MoveLeft,
                    Action.NoAction
                };
                Action action = moves[Random.Next(moves.Length)];

                this.Position = this.UpdatePosition(this.Position, action);
                this.previousMoveTime = World.Instance.Time;
            }
        }

        /// <summary>
        /// Draws the player on the screen.
        /// </summary>
        /// <param name="g">The graphics object to draw with.</param>
        public void Draw(Graphics g)
        {
            Rectangle r = new Rectangle(
                this.Position + new Size(borderSize * 2, borderSize * 2),
                World.Instance.Grid.CellSize - new Size(borderSize * 4, borderSize * 4));
            g.FillEllipse(this.brush, r);
            g.DrawEllipse(this.pen, r);
            g.DrawString(System.Convert.ToString(this.HitPoints),
                this.font, Brushes.White, r, this.stringFormat);
        }

        /// <summary>
        /// Given an origin, offsets this given position to the next adjacent cell.
        /// The resulting position is guaranteed to be inside the playing area.
        /// Note that this method depends on the world's map and cell size.
        /// </summary>
        /// <param name="position">The current position.</param>
        /// <param name="direction">The direction to go.</param>
        /// <returns>The new position.</returns>
        private Point UpdatePosition(Point position, Action direction)
        {
            Size ms = World.Instance.Grid.GridSize;
            Size cs = World.Instance.Grid.CellSize;
            Point newPos = position;

            if (direction == Action.MoveUp)
            {
                newPos.Offset(0, cs.Height * -1);
            }
            else if (direction == Action.MoveRight)
            {
                newPos.Offset(cs.Width, 0);
            }
            else if (direction == Action.MoveDown)
            {
                newPos.Offset(0, cs.Height);
            }
            else if (direction == Action.MoveLeft)
            {
                newPos.Offset(cs.Width * -1, 0);
            }

            // Verify that the new position is inside the world limits
            if (newPos.X < 0 || newPos.X > ms.Width - cs.Width ||
                newPos.Y < 0 || newPos.Y > ms.Height - cs.Height)
            {
                return position;
            }

            // Make sure we don't walk into walls
            if (World.Instance.Grid.CellTypeAtPosition(newPos) ==
                Game.Map.Cell.CellType.Wall)
            {
                return position;
            }

            // All is good in the world: return the new position
            return newPos;
        }
    }
}
