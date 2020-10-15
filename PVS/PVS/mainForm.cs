using System;
using System.Drawing;
using System.Windows.Forms;

namespace PVS {
    public partial class mainForm : Form {
        int Xcells;
        int Ycells;

        bool bDrag = false;
        Point posStart;

        ToolTip ToolTip1;
        Point sp, cp;
        Random rnd = new System.Random();
        bool flga = false;
        int cnt = 0;

        public mainForm(int _X, int _Y) {
            Xcells = _X;
            Ycells = _Y;
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
#if true
            if (flga == false) {
                flga = true;

                //200x100サイズのImageオブジェクトを作成する
                Bitmap img = new Bitmap(Xcells*4, Ycells*4);

                //Graphics g = this.CreateGraphics();
                Graphics g = Graphics.FromImage(img);


                Perlin pl = new Perlin();

                double x1_rnd = rnd.NextDouble();
                double y1_rnd = rnd.NextDouble();
                double z1_rnd = rnd.NextDouble();
                double x2_rnd = rnd.NextDouble();
                double y2_rnd = rnd.NextDouble();
                double z2_rnd = rnd.NextDouble();

                for (int i = 0; i < Xcells; i++) {
                    for (int j = 0; j < Ycells; j++) {
                        var c = pl.OctavePerlin(0.1 * i + x1_rnd, 0.1 * j + y1_rnd, z1_rnd, 6, 0.5) / 2.0 + pl.OctavePerlin(0.1 * i + x2_rnd, 0.1 * j + y2_rnd, z2_rnd, 3, 0.5) / 2.0;
                        //c = c / 0.9 - Math.Cos(((double)i * 50.0 / (double)this.Width)) / Math.PI / 5.0 - Math.Cos(((double)j * 50.0 / (double)this.Height)) / Math.PI / 5.0 - 0.05f;
                        c = Math.Min(Math.Max(c / 0.5 - 0.6 - Math.Cos((double)i / (double)Xcells * Math.PI * 4.0) / 4.0 - Math.Cos((double)j / (double)Ycells * Math.PI * 4.0) / 4.0, 0.0), 1.0);
                        Pen p;
                        if (c > 0.5) {
                            p = new Pen(Color.FromArgb((int)(255 * c - 100 + rnd.NextDouble() * 3), (int)(255 * c - rnd.NextDouble() * 3), (int)(255 * c - 100 + rnd.NextDouble() * 3)), 4);
                        } else {
                            p = new Pen(Color.FromArgb((int)(155 * c + rnd.NextDouble() * 3), (int)(155 * c + rnd.NextDouble() * 3), (int)(255 * c - rnd.NextDouble() * 3) + 100), 4);
                        }
                        g.DrawRectangle(p, i * 4, j * 4, 4, 4);
                        p.Dispose();
                    }
                }

                // Graphicsを解放する
                g.Dispose();

                //作成した画像を表示する
                Map_pctBox.Image = img;
            }
#endif

        }

        private void Form1_Load(object sender, EventArgs e) {
            //ToolTipを作成する
            //ToolTip1 = new ToolTip(this.components);
            //フォームにcomponentsがない場合
            ToolTip1 = new ToolTip();
            //ToolTipの設定を行う
            //ToolTipが表示されるまでの時間
            ToolTip1.InitialDelay = 20;
            //ToolTipが表示されている時に、別のToolTipを表示するまでの時間
            ToolTip1.ReshowDelay = 10;
            //ToolTipを表示する時間
            ToolTip1.AutoPopDelay = 1000;
            //フォームがアクティブでない時でもToolTipを表示する
            ToolTip1.ShowAlways = true;

            //Button1とButton2にToolTipが表示されるようにする
            ToolTip1.SetToolTip(this, "Button1です" + cp.X + "," + cp.Y);
            //ToolTip1.SetToolTip(Button2, "Button2です");



            //this.FormBorderStyle = FormBorderStyle.None;
            //this.Size = new Size(32, 32);
            //this.TopMost = true;
            //this.BackColor = Color.Aqua;

            var timer = new Timer();
            timer.Interval = 1;
            timer.Enabled = true;

            timer.Tick += (_s, _e) => {
                cp = this.Map_pctBox.PointToClient(Cursor.Position);
                this.label1.Location = new Point(this.PointToClient(Cursor.Position).X + 16, this.PointToClient(Cursor.Position).Y + 16);
                label1.Text = cnt.ToString() + "(" + (cp.X / 4).ToString() + "," + (cp.Y / 4).ToString() + ")";
                cnt++;
            };

        }

        private void Map_pctBox_MouseDown(object sender, MouseEventArgs e) {
            // ドラッグ開始
            bDrag = true;
            posStart = e.Location;
        }

        private void Map_pctBox_MouseUp(object sender, MouseEventArgs e) {
            // ドラッグ終了
            bDrag = false;
        }

        private void Map_pctBox_MouseMove(object sender, MouseEventArgs e) {
            // ドラッグ中ならスクロール
            if (bDrag) {
                Point pos = new Point(
                    e.Location.X - posStart.X,
                    e.Location.Y - posStart.Y);

                splitContainer1.Panel1.AutoScrollPosition = new Point(
                    -splitContainer1.Panel1.AutoScrollPosition.X - pos.X,
                    -splitContainer1.Panel1.AutoScrollPosition.Y - pos.Y);
            }
        }

    }
}
