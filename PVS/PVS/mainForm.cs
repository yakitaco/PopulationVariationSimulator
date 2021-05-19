using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PVS {
    public partial class mainForm : Form {
        int Xcells;
        int Ycells;
        Bitmap img;
        pvs_map map;

        bool bDrag = false;
        Point posStart;

        //シミュレーション速度
        Timer SimSpdTimer = new Timer();

        ToolTip ToolTip1;
        Point cp;
        Random rnd = new System.Random();
        bool flga = false;
        int cnt = 0;

        static bool StopFlg = false;

        //mainFormオブジェクトを保持するためのフィールド
        private static mainForm _mainFormInstance;

        //mainFormオブジェクトを取得、設定するためのプロパティ
        public static mainForm fInstance {
            get {
                return _mainFormInstance;
            }
            set {
                _mainFormInstance = value;
            }
        }

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
        }

        //マップイメージ表示用デリゲート
        delegate void delegate1(pvs_map _map);

        public void SetMapData(pvs_map _map) {
            if (this.InvokeRequired) {
                Invoke(new delegate1(_SetMapData), _map);
            } else {
                _SetMapData(_map);
            }
        }
        private void _SetMapData(pvs_map _map) {
            map = _map;
            img = _map.img.bitmap;
            var a = mapSize_TRB.Value;
            //作成した画像を表示する
            //Map_pctBox.Image = _img;
            ShowMapImg();
        }

        //作成した画像を表示する
        private void ShowMapImg() {
            int _Width = img.Width * mapSize_TRB.Value / 10;
            int _Height = img.Height * mapSize_TRB.Value / 10;
            Bitmap bmpResize = new Bitmap(_Width, _Height);
            Graphics g = Graphics.FromImage(bmpResize);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            //g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            g.DrawImage(img, 0, 0, _Width, _Height);
            Map_pctBox.Image = bmpResize;
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

            SimSpdTimer.Interval = 1;
            SimSpdTimer.Enabled = true;


            // フォームをロードするときの処理
            p_graph.Series.Clear();
            p_graph.ChartAreas.Clear();

            // ChartにChartAreaを追加します
            string chart_area1 = "Main";
            p_graph.ChartAreas.Add(new ChartArea(chart_area1));
            // ChartにSeriesを追加します
            string p = "Population";
            p_graph.Series.Add(p);
            // 折れ線グラフ指定
            p_graph.Series[p].ChartType = SeriesChartType.Line;

            SimSpdTimer.Tick += (_s, _e) => {
                cp = this.Map_pctBox.PointToClient(System.Windows.Forms.Cursor.Position);
                int x = cp.X * 10 / mapSize_TRB.Value / 4;
                int y = cp.Y * 10 / mapSize_TRB.Value / 4;
                if ( (x > -1) && (y > -1) && (x < Xcells) && (y < Ycells)) {
                    this.label1.Location = new Point(this.PointToClient(System.Windows.Forms.Cursor.Position).X + 16, this.PointToClient(System.Windows.Forms.Cursor.Position).Y + 16);
                    if (map == null) {
                        label1.Text = cnt.ToString() + "(" + x.ToString() + "," + y.ToString() + ")";
                    } else {
                        label1.Text = "(" + x.ToString() + "," + y.ToString() + ")" + map.mapData[x, y].height + "/" + map.mapData[x, y].temp + "/" + map.mapData[x, y].hume;
                    }
                }
                p_graph.Series[p].Points.AddY(cnt * cnt + rnd.Next(1, 100));
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

        //表示終了用デリゲート
        delegate void delegate2();

        public void ActiveForm() {
            if (this.InvokeRequired) {
                Invoke(new delegate2(_ActiveForm));
            } else {
                _ActiveForm();
            }
        }

        public void _ActiveForm() {
            this.Activate();
        }

        private void mainForm_FormClosed(object sender, FormClosedEventArgs e) {
            pvs_main.finishFlg = true; // メイン終了
        }

        //マップサイズ変更
        private void mapSize_TRB_Scroll(object sender, EventArgs e) {
            ShowMapImg();
        }

        //シミュレーション速度変更
        private void simSpeed_TRB_Scroll(object sender, EventArgs e) {
            SimSpdTimer.Interval = 100 - simSpeed_TRB.Value*10+1;
        }

        //シミュレーション停止ボタン
        private void simStop_Btn_Click(object sender, EventArgs e) {
            if (StopFlg == false) {
                simStop_Btn.Text = "Start";
                StopFlg = true;
                SimSpdTimer.Enabled = false;
            } else {
                simStop_Btn.Text = "Stop";
                StopFlg = false;
                SimSpdTimer.Enabled = true;
            }
        }

        //ログ表示用デリゲート
        delegate void delegate3(string str);

        public void AddLog(string str) {
            if (this.InvokeRequired) {
                Invoke(new delegate3(_AddLog), str);
            } else {
                _AddLog(str);
            }
        }
        private void _AddLog(string str) {
            textBox1.AppendText("[" + DateTime.Now.ToString("yyyyMMdd_HHmmss") +"] "+ str + "\r\n");
        }

    }
}
