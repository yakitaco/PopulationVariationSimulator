namespace PVS {
    partial class mainForm {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.Map_pctBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.p_graph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.simStop_Btn = new System.Windows.Forms.Button();
            this.simSpeed_TRB = new System.Windows.Forms.TrackBar();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.mapSize_TRB = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Map_pctBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.p_graph)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simSpeed_TRB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapSize_TRB)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.Map_pctBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(947, 363);
            this.splitContainer1.SplitterDistance = 600;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 3;
            // 
            // Map_pctBox
            // 
            this.Map_pctBox.Location = new System.Drawing.Point(0, 0);
            this.Map_pctBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Map_pctBox.Name = "Map_pctBox";
            this.Map_pctBox.Size = new System.Drawing.Size(1000, 896);
            this.Map_pctBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Map_pctBox.TabIndex = 1;
            this.Map_pctBox.TabStop = false;
            this.Map_pctBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Map_pctBox_MouseDown);
            this.Map_pctBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Map_pctBox_MouseMove);
            this.Map_pctBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Map_pctBox_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(502, 285);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.p_graph);
            this.splitContainer2.Panel1.Controls.Add(this.simStop_Btn);
            this.splitContainer2.Panel1.Controls.Add(this.simSpeed_TRB);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.textBox1);
            this.splitContainer2.Size = new System.Drawing.Size(345, 363);
            this.splitContainer2.SplitterDistance = 192;
            this.splitContainer2.SplitterWidth = 3;
            this.splitContainer2.TabIndex = 0;
            // 
            // p_graph
            // 
            this.p_graph.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.p_graph.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.p_graph.Legends.Add(legend1);
            this.p_graph.Location = new System.Drawing.Point(13, 8);
            this.p_graph.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.p_graph.Name = "p_graph";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.p_graph.Series.Add(series1);
            this.p_graph.Size = new System.Drawing.Size(325, 131);
            this.p_graph.TabIndex = 2;
            this.p_graph.Text = "chart1";
            // 
            // simStop_Btn
            // 
            this.simStop_Btn.Location = new System.Drawing.Point(278, 143);
            this.simStop_Btn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.simStop_Btn.Name = "simStop_Btn";
            this.simStop_Btn.Size = new System.Drawing.Size(45, 33);
            this.simStop_Btn.TabIndex = 1;
            this.simStop_Btn.Text = "Stop";
            this.simStop_Btn.UseVisualStyleBackColor = true;
            this.simStop_Btn.Click += new System.EventHandler(this.simStop_Btn_Click);
            // 
            // simSpeed_TRB
            // 
            this.simSpeed_TRB.Location = new System.Drawing.Point(13, 143);
            this.simSpeed_TRB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.simSpeed_TRB.Name = "simSpeed_TRB";
            this.simSpeed_TRB.Size = new System.Drawing.Size(261, 69);
            this.simSpeed_TRB.TabIndex = 0;
            this.simSpeed_TRB.Value = 1;
            this.simSpeed_TRB.Scroll += new System.EventHandler(this.simSpeed_TRB_Scroll);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(2, 2);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(324, 168);
            this.textBox1.TabIndex = 0;
            // 
            // mapSize_TRB
            // 
            this.mapSize_TRB.Location = new System.Drawing.Point(0, 0);
            this.mapSize_TRB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.mapSize_TRB.Maximum = 16;
            this.mapSize_TRB.Minimum = 2;
            this.mapSize_TRB.Name = "mapSize_TRB";
            this.mapSize_TRB.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.mapSize_TRB.Size = new System.Drawing.Size(69, 167);
            this.mapSize_TRB.SmallChange = 2;
            this.mapSize_TRB.TabIndex = 4;
            this.mapSize_TRB.Value = 10;
            this.mapSize_TRB.Scroll += new System.EventHandler(this.mapSize_TRB_Scroll);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 363);
            this.Controls.Add(this.mapSize_TRB);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "mainForm";
            this.Text = "PVS";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.mainForm_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Map_pctBox)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.p_graph)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simSpeed_TRB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapSize_TRB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox Map_pctBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button simStop_Btn;
        private System.Windows.Forms.TrackBar simSpeed_TRB;
        private System.Windows.Forms.DataVisualization.Charting.Chart p_graph;
        private System.Windows.Forms.TrackBar mapSize_TRB;
    }
}

