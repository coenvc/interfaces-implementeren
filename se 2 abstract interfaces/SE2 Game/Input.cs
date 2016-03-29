using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SE2_Game.Game;

namespace SE2_Game
{
    public partial class Input : Form
    {
        public int aantal { get; private set; }
        public Input()
        {
            this.CenterToScreen();
            InitializeComponent(); 
        }

        private void btnOke_Click(object sender, EventArgs e)
        {
            aantal = Convert.ToInt16(tbAantal.Text);
            this.Close();
        }
    }
}