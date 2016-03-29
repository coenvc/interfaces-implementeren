using System;
using System.Drawing;

namespace SE2_Game.Game.Map
{
    public class Cell
    {
        /// <summary>
        /// Indicates the type of the current cell. This enumeration is used to
        /// specialize a certain cell.
        /// </summary>
        public enum CellType
        {
            Normal, Goal, Wall
        }

        private static Pen penNormal = new Pen(Color.Gray, 1);
        private static Pen penGoal = new Pen(Color.Black, 2);
        private static Pen penWall = new Pen(Color.Black, 2);
        private static SolidBrush brushNormal = new SolidBrush(Color.FromArgb(255, 255, 255));
        private static SolidBrush brushGoal = new SolidBrush(Color.FromArgb(86, 178, 14));
        private static SolidBrush brushWall = new SolidBrush(Color.FromArgb(0, 0, 0));

        private Size cellSize;

        /// <summary>
        /// The index of this cell, as in the cell count. For example, if
        /// the index if (1, 2), this cell is in the second column and in
        /// the third row.
        /// </summary>
        public Point Index { get; private set; }
        /// <summary>
        /// The position of this cell's top left corner, in pixels.
        /// </summary>
        public Point Position { get; private set; }
        /// <summary>
        /// The type of the current cell.
        /// </summary>
        /// <see cref="CellType"/>
        public CellType Type { get; set; }

        public Cell(Point index, Point position, Size cellSize)
        {
            this.Index = index;
            this.Position = position;
            this.cellSize = cellSize;
            this.Type = CellType.Normal;
        }

        public void Draw(Graphics g)
        {
            Pen pen;
            Brush brush;

            switch (this.Type)
            {
                case CellType.Goal:
                    pen = Cell.penGoal;
                    brush = Cell.brushGoal;
                    break;
                case CellType.Wall:
                    pen = Cell.penWall;
                    brush = Cell.brushWall;
                    break;
                default:
                    pen = Cell.penNormal;
                    brush = Cell.brushNormal;
                    break;
            }

            int borderOffset = Convert.ToInt32(pen.Width / 2);
            Rectangle r = new Rectangle(
                this.cellSize.Width * this.Index.X + borderOffset,
                this.cellSize.Height * this.Index.Y + borderOffset,
                this.cellSize.Width - borderOffset,
                this.cellSize.Height- borderOffset);
            g.FillRectangle(brush, r);
            g.DrawRectangle(pen, r);
        }
    }
}
