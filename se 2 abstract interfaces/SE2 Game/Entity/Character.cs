﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using SE2_Game.Game;
namespace SE2_Game.Entity
{
    public class Character 
    {
        protected const int borderSize = 1;
        protected Pen pen = new Pen(Color.Black, borderSize);
        protected SolidBrush brush = new SolidBrush(Color.FromArgb(61, 123, 160));
        protected int hitPoints; 

        public Point Position { get; protected set; }

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

        // We need a font and formatter to draw strings. Instead of creating
        // them on each drawing call, we define them once here.
        private Font font = new Font("Arial", 8);
        private StringFormat stringFormat = new StringFormat();


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
