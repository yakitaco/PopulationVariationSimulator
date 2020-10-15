using System;
using System.Collections.Generic;

namespace PVS {

    class pvs_conf {
        Dictionary<string, dynamic> paramList = new Dictionary<string, dynamic>();
        private const string delimiter = "=";

        public pvs_conf(string fileName) {
            paramList.Add("height", "300");
            paramList.Add("width", "1000");
            paramList.Add("player1", "0");
            paramList.Add("player2", "1");
            paramList.Add("Xcells", "1000");
            paramList.Add("Ycells", "1000");
            paramList.Add("saveLog", "0");
            load(fileName);
        }

        //コンフィグロード
        private void load(string fileName) {
            System.IO.StreamReader cfg_sr = null;
            try {
                cfg_sr = new System.IO.StreamReader(@fileName,
                                System.Text.Encoding.GetEncoding("utf-8"));
                int rc;

                /* 内容を一行ずつ読み込む */
                string cfg_str;
                while ((rc = cfg_sr.Peek()) > -1) {
                    cfg_str = cfg_sr.ReadLine();
                    /* コメント行 */
                    if (cfg_str.StartsWith("#")) {
                        /* 何もしない */
                    } else {
                        /* パラメータリストをチェック＆登録 */
                        int position = cfg_str.IndexOf(delimiter);
                        if (position > 0) {
                            string key = cfg_str.Substring(0, position);
                            if (paramList.ContainsKey(key)) {
                                paramList[key] = cfg_str.Substring(position + 1);
                            } else {
                                Console.WriteLine("Key not found :" + key);
                            }
                        } else {
                            Console.WriteLine("Parse error :" + cfg_str);
                        }
                    }
                }
            } catch (System.IO.FileNotFoundException ex) {
                //FileNotFoundExceptionをキャッチした時
            } catch (System.UnauthorizedAccessException ex) {
                //UnauthorizedAccessExceptionをキャッチした時
            } finally {
                if (cfg_sr != null) {
                    cfg_sr.Dispose();
                }
            }
        }

        /* 文字列型パラメータ取得 */
        public string getPrmStr(string prm) {
            if (paramList.ContainsKey(prm)) {
                return paramList[prm].ToString();
            } else {
                return null;
            }
        }

        /* 数値型パラメータ取得 */
        public int? getPrmInt(string prm) {
            if (paramList.ContainsKey(prm)) {
                return int.Parse(paramList[prm]);
            } else {
                return null;
            }
        }

    }
}
