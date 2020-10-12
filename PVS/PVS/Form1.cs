using System;
using System.Drawing;
using System.Windows.Forms;

namespace PVS {
    public partial class Form1 : Form {

        Random rnd = new System.Random();

        public Form1() {

            InitializeComponent();

        }

        public void MasulabelClick(object sender, System.Windows.Forms.MouseEventArgs e) {
            //((Label)sender).Text = "A" + ((Label)sender).Name;
            int x = int.Parse(((Label)sender).Name.Substring(1, 2));
            int y = int.Parse(((Label)sender).Name.Substring(4, 2));
            //cn4_main.ReyewView(x, y);
            //this.Close();
        }

        private void Form1_Paint(object sender, PaintEventArgs e) {
            // Graphicsオブジェクトの作成
            Graphics g = this.CreateGraphics();

            Perlin pl = new Perlin();

            double x1_rnd = rnd.NextDouble();
            double y1_rnd = rnd.NextDouble();
            double z1_rnd = rnd.NextDouble();
            double x2_rnd = rnd.NextDouble();
            double y2_rnd = rnd.NextDouble();
            double z2_rnd = rnd.NextDouble();

            for (int i = 0; i < this.Width / 4; i++) {
                for (int j = 0; j < this.Height /4; j++) {
                    var c = pl.OctavePerlin(0.1*i+x1_rnd, 0.1 * j+y1_rnd, z1_rnd, 6, 0.5)/2.0 + pl.OctavePerlin(0.1 * i + x2_rnd, 0.1 * j + y2_rnd, z2_rnd, 3, 0.5) / 2.0;
                    //c = c/1.7+ Math.Cos(((double)i * 50.0/ (double)this.Width))/Math.PI + 0.5;
                    c = c / 0.9 - Math.Cos(((double)i * 50.0/ (double)this.Width))/Math.PI/ 5.0 - Math.Cos(((double)j * 50.0 / (double)this.Height)) / Math.PI / 5.0 -0.05f;
                    Pen p;
                    if (c> 0.5){
                        p = new Pen(Color.FromArgb((int)(255 * c -100), (int)(255 * c), (int)(255 * c-100)), 4);
                    } else {
                        p = new Pen(Color.FromArgb((int)(155 * c), (int)(155 * c), (int)(255 * c)+100), 4);
                    }
                    g.DrawRectangle(p, i*4, j*4, 4, 4);
                    p.Dispose();
                }
            }

            // Graphicsを解放する
            g.Dispose();

        }
    }
}
