using System;
using System.Windows.Forms;
using SE2_Game.Game;

namespace SE2_Game
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            World.Instance.Create(picGame.Size, new System.Drawing.Size(9, 9), 10);
        }

        private void picGame_Paint(object sender, PaintEventArgs e)
        {
            // This code smooths the drawing done on the picture box.
            e.Graphics.SmoothingMode =
                System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // The game world is responible for the actual drawing.
            World.Instance.Draw(e.Graphics);
        }

        private void timerAnimation_Tick(object sender, EventArgs e)
        {
            // First update the game world, that trigger a refresh on the
            // picturebox so that the new state will be displayed.
            World.Instance.Update();
            picGame.Refresh();

            if (World.Instance.GameOver)
            {
                timerAnimation.Enabled = false;
                MessageBox.Show("Game Over!");
                this.Close();
            }

            if (World.Instance.GameWon)
            {
                timerAnimation.Enabled = false;
                MessageBox.Show("Game Won!");
                this.Close();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            World.Instance.Player.Interaction(e.KeyCode);
        }
    }
}
