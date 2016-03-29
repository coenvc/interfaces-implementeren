using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SE2_Game.Entity
{
    public interface Icarryable
    { 
       string Name { get; set; }
       int Weight { get; set; } 
       int ArmorUp { get; set; }
       Point Position { get; set; }
       void Draw(Graphics g);      
    }
}
