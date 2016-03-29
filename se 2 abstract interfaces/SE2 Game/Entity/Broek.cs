using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE2_Game.Entity.Gear
{
    class Broek : Gear, Icarryable
    {
      public Broek(Point Position)
        {
            this.Name = "Broek";
            this.Position = Position;
            this.Weight = 2;
            this.ArmorUp += 2;
        }
    }
}
