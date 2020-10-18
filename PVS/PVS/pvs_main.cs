using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PVS {
    static class pvs_main {
        public static bool finishFlg = false;
        private const string confFileName = ".\\pvs.cfg";

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            pvs_conf cnf = new pvs_conf(confFileName);

            mainForm.fInstance = new mainForm((int)cnf.getPrmInt("Xcells"), (int)cnf.getPrmInt("Ycells"));
            mainForm.fInstance.Size = new System.Drawing.Size((int)cnf.getPrmInt("width"), (int)cnf.getPrmInt("height"));

            //非同期フォーム
            Task.Run(() => {
                Application.Run(mainForm.fInstance); // フォーム
            });

            //マップオブジェクト作成
            pvs_map map = new pvs_map((int)cnf.getPrmInt("Xcells"), (int)cnf.getPrmInt("Ycells"));
            var ret  = map.make();
            mainForm.fInstance.SetMapImg(map.img.bitmap);
            mainForm.fInstance.ActiveForm();

            while (finishFlg == false) {
                Thread.Sleep(100);
            }
        }


    }
}
