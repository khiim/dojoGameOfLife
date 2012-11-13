namespace GameOfLife
{
    partial class GameForm
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
            this.gameView = new GameOfLife.GameView();
            this.SuspendLayout();
            // 
            // gameView
            // 
            this.gameView.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gameView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gameView.Location = new System.Drawing.Point(0, 0);
            this.gameView.Name = "gameView";
            this.gameView.Size = new System.Drawing.Size(519, 340);
            this.gameView.TabIndex = 0;
            this.gameView.Resize += new System.EventHandler(this.gameView_Resize);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 340);
            this.Controls.Add(this.gameView);
            this.Name = "GameForm";
            this.Text = "Game of Life";
            this.Load += new System.EventHandler(this.GameForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private GameView gameView;
    }
}

