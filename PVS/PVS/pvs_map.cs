﻿using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PVS {
    //セルの種類
    enum CELLTYPE {
        None,         //なし
        DeepSea,      //深海
        ShallowSea,   //浅海
        SandyBeach,   //砂浜
        Meadow,       //草原
        River,        //河川
        Lake,         //湖
        Forest,       //森林
        Mountain,     //山岳
    }

    class mapCell {
        public int height;     //高さ (0=水面)
        public CELLTYPE type;  //セルの種類
    }

    //マップイメージ画像
    class mapImage {
        Bitmap img;
        public mapImage(int x, int y) {
            img = new Bitmap(x * 4, y * 4);
        }
        public Bitmap bitmap {
            get {
                return img;
            }
            set {
                img = value;
            }
        }

    }

    class pvs_map {
        mapCell[,] mapData;
        public mapImage img;
        int Xcells;
        int Ycells;
        int riverMax = 100;

        public pvs_map(int x, int y) {
            mapData = new mapCell[x, y];
            Xcells = x;
            Ycells = y;
        }

        public bool make() {
            //200x100サイズのImageオブジェクトを作成する
            img = new mapImage(Xcells, Ycells);
            Random rnd = new System.Random();

            //Graphics g = this.CreateGraphics();
            Graphics g = Graphics.FromImage(img.bitmap);

            Perlin pl = new Perlin();

            double x1_rnd = rnd.NextDouble();
            double y1_rnd = rnd.NextDouble();
            double z1_rnd = rnd.NextDouble();
            double x2_rnd = rnd.NextDouble();
            double y2_rnd = rnd.NextDouble();
            double z2_rnd = rnd.NextDouble();

            progressForm.fInstance = new progressForm(Xcells);

            //非同期フォーム
            Task.Run(() => {
                Application.Run(progressForm.fInstance); // フォーム
            });

            
            // 地形の生成
            for (int i = 0; i < Xcells; i++) {
                for (int j = 0; j < Ycells; j++) {
                    mapData[i, j] = new mapCell();
                    var c = pl.OctavePerlin(0.1 * i + x1_rnd, 0.1 * j + y1_rnd, z1_rnd, 6, 0.5) / 2.0 + pl.OctavePerlin(0.1 * i + x2_rnd, 0.1 * j + y2_rnd, z2_rnd, 3, 0.5) / 2.0;
                    
                    //c = c / 0.9 - Math.Cos(((double)i * 50.0 / (double)this.Width)) / Math.PI / 5.0 - Math.Cos(((double)j * 50.0 / (double)this.Height)) / Math.PI / 5.0 - 0.05f;
                    c = Math.Min(Math.Max(c / 0.5 - 0.6 - Math.Cos((double)i / (double)Xcells * Math.PI * 4.0) / 4.0 - Math.Cos((double)j / (double)Ycells * Math.PI * 4.0) / 4.0, 0.0), 1.0);
                    mapData[i, j].height = (int)(c * 100) - 50;
                    Pen p;
                    if (c > 0.5) {
                        p = new Pen(Color.FromArgb((int)(255 * c - 100 + rnd.NextDouble() * 3), (int)(255 * c - rnd.NextDouble() * 3), (int)(255 * c - 100 + rnd.NextDouble() * 3)), 4);
                    } else {
                        p = new Pen(Color.FromArgb((int)(155 * c + rnd.NextDouble() * 3), (int)(155 * c + rnd.NextDouble() * 3), (int)(255 * c - rnd.NextDouble() * 3) + 100), 4);
                    }
                    g.DrawRectangle(p, i * 4, j * 4, 4, 4);
                    p.Dispose();
                }
                if (progressForm.fInstance.cancel == true) {
                    // Graphicsを解放する
                    g.Dispose();
                    return false;
                }
                progressForm.fInstance.SetProgVal(i);
            }

            // 気候の生成

            // 川の生成
            for (int i = 0; i < riverMax; i++) {
                int x = rnd.Next(0, Xcells);
                int y = rnd.Next(0, Ycells);
                if (mapData[x,y].height > 0) {
                    Pen p;
                    p = new Pen(Color.FromArgb((int)(155 + rnd.NextDouble() * 3), (int)(155 + rnd.NextDouble() * 3), (int)(155 - rnd.NextDouble() * 3) + 100), 4);
                    g.DrawRectangle(p, x * 4, y * 4, 4, 4);
                    p.Dispose();
                }
            }

            progressForm.fInstance.CloseProg();

            // Graphicsを解放する
            g.Dispose();
            return true;
        }

    }



}
