using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PVS {
    static class pvs_main {
        public static bool finishFlg = false;

        private const string confFileName = ".\\pvs.cfg";
        public static mainForm mainForm { get; private set; }

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            pvs_conf cnf = new pvs_conf(confFileName);

            mainForm = new mainForm((int)cnf.getPrmInt("Xcells"), (int)cnf.getPrmInt("Ycells"));
            mainForm.fInstance = mainForm;
            mainForm.Size = new System.Drawing.Size((int)cnf.getPrmInt("width"), (int)cnf.getPrmInt("height"));

            progressForm prgForm = new progressForm((int)cnf.getPrmInt("Ycells"));
            progressForm.fInstance = prgForm;

            //非同期フォーム
            Task.Run(() => {
                Application.Run(mainForm); // フォーム
            });

            //非同期フォーム
            Task.Run(() => {
                Application.Run(prgForm); // フォーム
                if (progressForm.fInstance.cancel == true) Application.Exit();
            });


            //マップオブジェクト作成
            pvs_map map = new pvs_map((int)cnf.getPrmInt("Xcells"), (int)cnf.getPrmInt("Ycells"));
            var ret  = map.make(progressForm.fInstance.SetProgVal);
            mainForm.fInstance.SetMapImg(map.img.bitmap);
            mainForm.fInstance.ActiveForm();
            progressForm.fInstance.CloseProg();

            while (finishFlg == false) {
                Thread.Sleep(100);
            }
        }


    }
}
