using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PVS {
    public partial class progressForm : Form {
        int max = 0;
        int val = 0;
        public bool cancel = false;  //中断フラグ

        //mainFormオブジェクトを保持するためのフィールド
        private static progressForm _progressFormInstance;

        //mainFormオブジェクトを取得、設定するためのプロパティ
        public static progressForm fInstance {
            get {
                return _progressFormInstance;
            }
            set {
                _progressFormInstance = value;
            }
        }
        public progressForm(int _max) {
            InitializeComponent();
            max = _max;
            progressBar1.Maximum= _max;
            label1.Text = val.ToString() + "/" + max.ToString() + " (" + (val * 100 / max).ToString() + "%)";
        }

        //マップイメージ表示用デリゲート
        delegate void delegate1(int val);

        public void SetProgVal(int _val) {
            if (this.InvokeRequired) {
                Invoke(new delegate1(_SetProgVal), _val);
            } else {
                _SetProgVal(_val);
            }
        }

        public void _SetProgVal(int _val) {
            //作成した画像を表示する
            progressBar1.Value = _val;
            val = _val;
            label1.Text = val.ToString() + "/"+ max.ToString() + " ("+ (val*100/max).ToString() +"%)";
        }

        //表示終了用デリゲート
        delegate void delegate2();

        public void CloseProg() {
            if (this.InvokeRequired) {
                Invoke(new delegate2(_CloseProg));
            } else {
                _CloseProg();
            }
        }

        public void _CloseProg() {
            this.Close();
        }

        private void progressForm_FormClosing(object sender, FormClosingEventArgs e) {
        }

        private void button1_Click(object sender, EventArgs e) {
            cancel = true;
            MessageBox.Show("中断しました", "progressForm",
            MessageBoxButtons.OK, MessageBoxIcon.Stop);
            this.Close();
            pvs_main.finishFlg = true; // メイン終了
        }



    }
}
