using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GameOfLife
{
    public partial class GameView : UserControl
    {

        private static readonly Color background = Color.White;
        private static readonly Color cell = Color.Black;

        private Processor processor;

        public GameView()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.FillRectangle(Brushes.White, this.Bounds);

            if (processor.CurrentWorld != null)
            {
                var cellWidth = Bounds.Width / processor.CurrentWorld.Width;
                var cellHeight = Bounds.Height / processor.CurrentWorld.Height;
                if (cellWidth == 0)
                    cellWidth = 1;
                if (cellHeight == 0)
                    cellHeight = 1;

                Console.WriteLine(cellWidth + " " + cellHeight);
                for (int x = 0; x < processor.CurrentWorld.Width; x++)
                    for (int y = 0; y < processor.CurrentWorld.Height; y++)
                    {
                        if (processor.CurrentWorld.Get(x+processor.CurrentWorld.OffsetX, y+processor.CurrentWorld.OffsetY))
                            e.Graphics.FillRectangle(Brushes.Black, x*cellWidth, y*cellHeight, cellWidth, cellHeight);
                    }

            }

        }

        private void GameView_Click(object sender, EventArgs e)
        {
            if (processor.CurrentWorld != null)
            {
                
                Console.WriteLine("Tick");
                processor.Tick();
                Console.WriteLine("Done");
                Refresh();
            }
        }

        private void GameView_Load(object sender, EventArgs e)
        {
            int startW = 90;
            int startH = 60;
            
            var world1 = new World(startW, startH);
            world1.Random();

            var world2 = new World(startW, startH);

            processor = new Processor(world1, world2);
            ticker.Start();
            Refresh();
        }

        private void ticker_Tick(object sender, EventArgs e)
        {
            processor.Tick();
            Refresh();
        }

   
    }
}
