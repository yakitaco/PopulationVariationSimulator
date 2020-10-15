using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PVS {
    static class pvs_main {

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
            mainForm.Size = new System.Drawing.Size((int)cnf.getPrmInt("width"), (int)cnf.getPrmInt("height"));

            //非同期フォーム
            Task.Run(() => {
                Application.Run(mainForm); // フォーム
            });

            Thread.Sleep(100000);
            //Application.Run(mainForm);
        }
    }
}
