using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SE2_Game.Game;
using SE2_Game.Entity;

namespace SE2_Game.Entity.Gear
{
    class Gear : Icarryable
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public int ArmorUp { get; set; }
        public Point Position { get; set; }

        public Point Getposition()
        {
            return Position;
        }

        public void Draw(Graphics g)
        {

            Rectangle r = new Rectangle(
            this.Position + new Size(2 * 2, 2 * 2),
            World.Instance.Grid.CellSize - new Size(2 * 4, 2 * 4));
            g.FillEllipse(Brushes.Red, r);
            g.DrawEllipse(Pens.Red, r);
            g.DrawString(Name, new Font("Arial", 8), Brushes.White, r, new StringFormat());
        }
    }
}