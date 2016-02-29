namespace BKlink
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Sub = new System.Windows.Forms.Button();
            this.URLtext = new System.Windows.Forms.TextBox();
            this.WindowInfo = new System.Windows.Forms.Label();
            this.ClassInfo = new System.Windows.Forms.Label();
            this.MethodInfo = new System.Windows.Forms.Label();
            this.play = new System.Windows.Forms.Button();
            this.DanmuInfo = new System.Windows.Forms.Label();
            this.time = new System.Windows.Forms.TextBox();
            this.conttab = new System.Windows.Forms.Panel();
            this.SetInfo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.设置字体ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.弹幕设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parall = new System.Windows.Forms.CheckBox();
            this.ViedoList = new System.Windows.Forms.ListBox();
            this.PlayInfo = new System.Windows.Forms.Label();
            this.pause = new System.Windows.Forms.Button();
            this.PlayBar = new System.Windows.Forms.TrackBar();
            this.titilepanle = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.IconBox = new System.Windows.Forms.PictureBox();
            this.windowlist = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.followwindow = new System.Windows.Forms.CheckBox();
            this.LoadPicture = new System.Windows.Forms.PictureBox();
            this.close = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.conttab.SuspendLayout();
            this.SetInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PlayBar)).BeginInit();
            this.titilepanle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IconBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoadPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // Sub
            // 
            this.Sub.Location = new System.Drawing.Point(113, 13);
            this.Sub.Name = "Sub";
            this.Sub.Size = new System.Drawing.Size(70, 23);
            this.Sub.TabIndex = 0;
            this.Sub.Text = "获取弹幕";
            this.Sub.UseVisualStyleBackColor = true;
            this.Sub.Click += new System.EventHandler(this.Sub_Click);
            // 
            // URLtext
            // 
            this.URLtext.Location = new System.Drawing.Point(0, 14);
            this.URLtext.Name = "URLtext";
            this.URLtext.Size = new System.Drawing.Size(113, 21);
            this.URLtext.TabIndex = 1;
            // 
            // WindowInfo
            // 
            this.WindowInfo.AutoSize = true;
            this.WindowInfo.Location = new System.Drawing.Point(295, 23);
            this.WindowInfo.Name = "WindowInfo";
            this.WindowInfo.Size = new System.Drawing.Size(41, 12);
            this.WindowInfo.TabIndex = 2;
            this.WindowInfo.Text = "label1";
            // 
            // ClassInfo
            // 
            this.ClassInfo.AutoSize = true;
            this.ClassInfo.Location = new System.Drawing.Point(0, 1);
            this.ClassInfo.Name = "ClassInfo";
            this.ClassInfo.Size = new System.Drawing.Size(41, 12);
            this.ClassInfo.TabIndex = 2;
            this.ClassInfo.Text = "label1";
            // 
            // MethodInfo
            // 
            this.MethodInfo.AutoSize = true;
            this.MethodInfo.Location = new System.Drawing.Point(297, 7);
            this.MethodInfo.Name = "MethodInfo";
            this.MethodInfo.Size = new System.Drawing.Size(41, 12);
            this.MethodInfo.TabIndex = 2;
            this.MethodInfo.Text = "label1";
            // 
            // play
            // 
            this.play.Location = new System.Drawing.Point(184, 13);
            this.play.Name = "play";
            this.play.Size = new System.Drawing.Size(58, 23);
            this.play.TabIndex = 0;
            this.play.Text = "播放";
            this.play.UseVisualStyleBackColor = true;
            this.play.Click += new System.EventHandler(this.play_Click);
            // 
            // DanmuInfo
            // 
            this.DanmuInfo.AutoSize = true;
            this.DanmuInfo.Location = new System.Drawing.Point(479, 45);
            this.DanmuInfo.Name = "DanmuInfo";
            this.DanmuInfo.Size = new System.Drawing.Size(0, 12);
            this.DanmuInfo.TabIndex = 2;
            // 
            // time
            // 
            this.time.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.time.Location = new System.Drawing.Point(247, 17);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(44, 14);
            this.time.TabIndex = 1;
            this.time.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.time_KeyPress);
            // 
            // conttab
            // 
            this.conttab.AutoScroll = true;
            this.conttab.BackColor = System.Drawing.Color.WhiteSmoke;
            this.conttab.ContextMenuStrip = this.SetInfo;
            this.conttab.Controls.Add(this.windowlist);
            this.conttab.Controls.Add(this.followwindow);
            this.conttab.Controls.Add(this.parall);
            this.conttab.Controls.Add(this.ViedoList);
            this.conttab.Controls.Add(this.ClassInfo);
            this.conttab.Controls.Add(this.PlayInfo);
            this.conttab.Controls.Add(this.DanmuInfo);
            this.conttab.Controls.Add(this.Sub);
            this.conttab.Controls.Add(this.MethodInfo);
            this.conttab.Controls.Add(this.pause);
            this.conttab.Controls.Add(this.play);
            this.conttab.Controls.Add(this.URLtext);
            this.conttab.Controls.Add(this.label3);
            this.conttab.Controls.Add(this.label2);
            this.conttab.Controls.Add(this.WindowInfo);
            this.conttab.Controls.Add(this.time);
            this.conttab.Controls.Add(this.PlayBar);
            this.conttab.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.conttab.Location = new System.Drawing.Point(0, 331);
            this.conttab.Name = "conttab";
            this.conttab.Size = new System.Drawing.Size(762, 80);
            this.conttab.TabIndex = 3;
            this.conttab.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoveWindow1);
            this.conttab.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoveWindow2);
            this.conttab.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MoveWindow3);
            // 
            // SetInfo
            // 
            this.SetInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置字体ToolStripMenuItem,
            this.弹幕设置ToolStripMenuItem});
            this.SetInfo.Name = "SetInfo";
            this.SetInfo.Size = new System.Drawing.Size(125, 48);
            // 
            // 设置字体ToolStripMenuItem
            // 
            this.设置字体ToolStripMenuItem.Name = "设置字体ToolStripMenuItem";
            this.设置字体ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.设置字体ToolStripMenuItem.Text = "设置字体";
            this.设置字体ToolStripMenuItem.Click += new System.EventHandler(this.设置字体ToolStripMenuItem_Click);
            // 
            // 弹幕设置ToolStripMenuItem
            // 
            this.弹幕设置ToolStripMenuItem.Name = "弹幕设置ToolStripMenuItem";
            this.弹幕设置ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.弹幕设置ToolStripMenuItem.Text = "弹幕设置";
            this.弹幕设置ToolStripMenuItem.Click += new System.EventHandler(this.弹幕设置ToolStripMenuItem_Click);
            // 
            // parall
            // 
            this.parall.AutoSize = true;
            this.parall.Location = new System.Drawing.Point(361, 49);
            this.parall.Name = "parall";
            this.parall.Size = new System.Drawing.Size(84, 16);
            this.parall.TabIndex = 4;
            this.parall.Text = "多线程加速";
            this.parall.UseVisualStyleBackColor = true;
            this.parall.CheckedChanged += new System.EventHandler(this.parall_CheckedChanged);
            // 
            // ViedoList
            // 
            this.ViedoList.FormattingEnabled = true;
            this.ViedoList.ItemHeight = 12;
            this.ViedoList.Location = new System.Drawing.Point(478, 13);
            this.ViedoList.Name = "ViedoList";
            this.ViedoList.Size = new System.Drawing.Size(120, 28);
            this.ViedoList.TabIndex = 3;
            this.ViedoList.DoubleClick += new System.EventHandler(this.ViedoList_DoubleClick);
            // 
            // PlayInfo
            // 
            this.PlayInfo.AutoSize = true;
            this.PlayInfo.Location = new System.Drawing.Point(479, 64);
            this.PlayInfo.Name = "PlayInfo";
            this.PlayInfo.Size = new System.Drawing.Size(0, 12);
            this.PlayInfo.TabIndex = 2;
            // 
            // pause
            // 
            this.pause.BackColor = System.Drawing.Color.Lime;
            this.pause.Enabled = false;
            this.pause.Location = new System.Drawing.Point(297, 45);
            this.pause.Name = "pause";
            this.pause.Size = new System.Drawing.Size(58, 23);
            this.pause.TabIndex = 0;
            this.pause.Text = "播放";
            this.pause.UseVisualStyleBackColor = false;
            this.pause.Visible = false;
            this.pause.Click += new System.EventHandler(this.pause_Click);
            // 
            // PlayBar
            // 
            this.PlayBar.Location = new System.Drawing.Point(9, 33);
            this.PlayBar.Maximum = 100;
            this.PlayBar.Name = "PlayBar";
            this.PlayBar.Size = new System.Drawing.Size(282, 45);
            this.PlayBar.TabIndex = 5;
            this.PlayBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.PlayBar.Scroll += new System.EventHandler(this.PlayBar_Scroll);
            // 
            // titilepanle
            // 
            this.titilepanle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.titilepanle.Controls.Add(this.IconBox);
            this.titilepanle.Controls.Add(this.label1);
            this.titilepanle.Controls.Add(this.close);
            this.titilepanle.Dock = System.Windows.Forms.DockStyle.Top;
            this.titilepanle.ForeColor = System.Drawing.Color.Black;
            this.titilepanle.Location = new System.Drawing.Point(0, 0);
            this.titilepanle.Name = "titilepanle";
            this.titilepanle.Size = new System.Drawing.Size(762, 27);
            this.titilepanle.TabIndex = 4;
            this.titilepanle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoveWindow1);
            this.titilepanle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoveWindow2);
            this.titilepanle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MoveWindow3);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "BKLink";
            // 
            // IconBox
            // 
            this.IconBox.Location = new System.Drawing.Point(2, 2);
            this.IconBox.Name = "IconBox";
            this.IconBox.Size = new System.Drawing.Size(24, 24);
            this.IconBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.IconBox.TabIndex = 1;
            this.IconBox.TabStop = false;
            // 
            // windowlist
            // 
            this.windowlist.FormattingEnabled = true;
            this.windowlist.ItemHeight = 12;
            this.windowlist.Location = new System.Drawing.Point(604, 13);
            this.windowlist.Name = "windowlist";
            this.windowlist.Size = new System.Drawing.Size(155, 64);
            this.windowlist.TabIndex = 6;
            this.windowlist.DoubleClick += new System.EventHandler(this.windowlist_DoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(602, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "绑定窗口";
            // 
            // followwindow
            // 
            this.followwindow.AutoSize = true;
            this.followwindow.Location = new System.Drawing.Point(678, -1);
            this.followwindow.Name = "followwindow";
            this.followwindow.Size = new System.Drawing.Size(72, 16);
            this.followwindow.TabIndex = 4;
            this.followwindow.Text = "跟踪窗口";
            this.followwindow.UseVisualStyleBackColor = true;
            this.followwindow.CheckedChanged += new System.EventHandler(this.parall_CheckedChanged);
            // 
            // LoadPicture
            // 
            this.LoadPicture.Enabled = false;
            this.LoadPicture.Image = global::BKlink.Properties.Resources.a__2_;
            this.LoadPicture.InitialImage = null;
            this.LoadPicture.Location = new System.Drawing.Point(267, 109);
            this.LoadPicture.Name = "LoadPicture";
            this.LoadPicture.Size = new System.Drawing.Size(234, 114);
            this.LoadPicture.TabIndex = 5;
            this.LoadPicture.TabStop = false;
            this.LoadPicture.Visible = false;
            // 
            // close
            // 
            this.close.Location = new System.Drawing.Point(738, 3);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(21, 21);
            this.close.TabIndex = 0;
            this.close.Text = "×";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(477, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "分P列表";
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(762, 411);
            this.ControlBox = false;
            this.Controls.Add(this.LoadPicture);
            this.Controls.Add(this.titilepanle);
            this.Controls.Add(this.conttab);
            this.ForeColor = System.Drawing.Color.DimGray;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.TransparencyKey = System.Drawing.Color.Gray;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.conttab.ResumeLayout(false);
            this.conttab.PerformLayout();
            this.SetInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PlayBar)).EndInit();
            this.titilepanle.ResumeLayout(false);
            this.titilepanle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IconBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoadPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Sub;
        private System.Windows.Forms.TextBox URLtext;
        private System.Windows.Forms.Label WindowInfo;
        private System.Windows.Forms.Label ClassInfo;
        private System.Windows.Forms.Label MethodInfo;
        private System.Windows.Forms.Button play;
        private System.Windows.Forms.Label DanmuInfo;
        private System.Windows.Forms.TextBox time;
        private System.Windows.Forms.Panel conttab;
        private System.Windows.Forms.Button pause;
        private System.Windows.Forms.ListBox ViedoList;
        private System.Windows.Forms.Label PlayInfo;
        private System.Windows.Forms.CheckBox parall;
        private System.Windows.Forms.ContextMenuStrip SetInfo;
        private System.Windows.Forms.ToolStripMenuItem 设置字体ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 弹幕设置ToolStripMenuItem;
        private System.Windows.Forms.TrackBar PlayBar;
        private System.Windows.Forms.Panel titilepanle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox IconBox;
        private System.Windows.Forms.ListBox windowlist;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox followwindow;
        private System.Windows.Forms.PictureBox LoadPicture;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.Label label3;
    }
}

