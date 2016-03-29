using System.Drawing;
using System.Windows.Forms;
using SE2_Game.Game;

namespace SE2_Game.Entity
{
    public class Player
    {
        private const int borderSize = 2;
        private Pen pen = new Pen(Color.Black, borderSize);
        private SolidBrush brush = new SolidBrush(Color.FromArgb(61, 123, 160));

        public Point Position { get; private set; }

        /// <summary>
        /// The HitPoints for the player. If this equals zero, no more player.
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

        /// <summary>
        /// This property contains the last user interaction that has taken
        /// place. Reading this value will return this last action once, after
        /// which the value will be reset.
        /// </summary>
        private Action CurrentAction
        {
            get
            {
                Action action = this.currentAction;
                this.currentAction = Action.NoAction;
                return action;
            }
            set
            {
                if (value != Action.NoAction)
                {
                    this.currentAction = value;
                }
            }
        }
        private Action currentAction = Action.NoAction;

        // We need a font and formatter to draw strings. Instead of creating
        // them on each drawing call, we define them once here.
        private Font font = new Font("Arial", 8);
        private StringFormat stringFormat = new StringFormat();

        public Player()
        {
            this.HitPoints = 100;

            // Make drawn string appear centered in the positioning rectangle.
            this.stringFormat.Alignment = StringAlignment.Center;
            this.stringFormat.LineAlignment = StringAlignment.Center;
        }

        /// <summary>
        /// Update the player position based on the current user interaction.
        /// </summary>
        public void Update()
        {
            this.Position = this.UpdatePosition(this.Position, this.CurrentAction);
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
        /// Given a keyboard key, returns a direction based thereon. For now,
        /// this checks the arrow kays and WASD.
        /// </summary>
        /// <returns>The keyboard key converted to a direction.</returns>
        public void Interaction(Keys key)
        {
            if (key == Keys.Up || key == Keys.W)
            {
                this.CurrentAction = Action.MoveUp;
            }
            else if (key == Keys.Right || key == Keys.D)
            {
                this.CurrentAction = Action.MoveRight;
            }
            else if (key == Keys.Down || key == Keys.S)
            {
                this.CurrentAction = Action.MoveDown;
            }
            else if (key == Keys.Left || key == Keys.A)
            {
                this.CurrentAction = Action.MoveLeft;
            }
            else if (key == Keys.Space)
            {
                this.CurrentAction = Action.PerformAction;
            }
            else
            {
                this.CurrentAction = Action.NoAction;
            }
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
