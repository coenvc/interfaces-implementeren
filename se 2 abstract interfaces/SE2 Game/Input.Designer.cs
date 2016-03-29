namespace SE2_Game
{
    partial class Input
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbAantal = new System.Windows.Forms.TextBox();
            this.btnOke = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbAantal
            // 
            this.tbAantal.Location = new System.Drawing.Point(81, 61);
            this.tbAantal.Name = "tbAantal";
            this.tbAantal.Size = new System.Drawing.Size(100, 20);
            this.tbAantal.TabIndex = 0;
            // 
            // btnOke
            // 
            this.btnOke.Location = new System.Drawing.Point(92, 111);
            this.btnOke.Name = "btnOke";
            this.btnOke.Size = new System.Drawing.Size(75, 23);
            this.btnOke.TabIndex = 0;
            this.btnOke.Text = "OK";
            this.btnOke.Click += new System.EventHandler(this.btnOke_Click);
            // 
            // Input
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnOke);
            this.Controls.Add(this.tbAantal);
            this.Name = "Input";
            this.Text = "Input";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbAantal;
        private System.Windows.Forms.Button btnOke;
    }
}