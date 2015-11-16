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
            this.ViedoList = new System.Windows.Forms.ListBox();
            this.PlayInfo = new System.Windows.Forms.Label();
            this.pause = new System.Windows.Forms.Button();
            this.parall = new System.Windows.Forms.CheckBox();
            this.conttab.SuspendLayout();
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
            this.WindowInfo.Location = new System.Drawing.Point(604, 7);
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
            this.MethodInfo.Location = new System.Drawing.Point(604, 25);
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
            this.DanmuInfo.Location = new System.Drawing.Point(297, 23);
            this.DanmuInfo.Name = "DanmuInfo";
            this.DanmuInfo.Size = new System.Drawing.Size(0, 12);
            this.DanmuInfo.TabIndex = 2;
            // 
            // time
            // 
            this.time.Location = new System.Drawing.Point(247, 14);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(44, 21);
            this.time.TabIndex = 1;
            this.time.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.time_KeyPress);
            // 
            // conttab
            // 
            this.conttab.BackColor = System.Drawing.Color.LightGray;
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
            this.conttab.Controls.Add(this.WindowInfo);
            this.conttab.Controls.Add(this.time);
            this.conttab.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.conttab.Location = new System.Drawing.Point(0, 450);
            this.conttab.Name = "conttab";
            this.conttab.Size = new System.Drawing.Size(794, 38);
            this.conttab.TabIndex = 3;
            // 
            // ViedoList
            // 
            this.ViedoList.FormattingEnabled = true;
            this.ViedoList.ItemHeight = 12;
            this.ViedoList.Location = new System.Drawing.Point(478, 7);
            this.ViedoList.Name = "ViedoList";
            this.ViedoList.Size = new System.Drawing.Size(120, 28);
            this.ViedoList.TabIndex = 3;
            this.ViedoList.DoubleClick += new System.EventHandler(this.ViedoList_DoubleClick);
            // 
            // PlayInfo
            // 
            this.PlayInfo.AutoSize = true;
            this.PlayInfo.Location = new System.Drawing.Point(297, 7);
            this.PlayInfo.Name = "PlayInfo";
            this.PlayInfo.Size = new System.Drawing.Size(0, 12);
            this.PlayInfo.TabIndex = 2;
            // 
            // pause
            // 
            this.pause.BackColor = System.Drawing.Color.Lime;
            this.pause.Location = new System.Drawing.Point(737, 16);
            this.pause.Name = "pause";
            this.pause.Size = new System.Drawing.Size(58, 23);
            this.pause.TabIndex = 0;
            this.pause.Text = "继续";
            this.pause.UseVisualStyleBackColor = false;
            this.pause.Visible = false;
            this.pause.Click += new System.EventHandler(this.pause_Click);
            // 
            // parall
            // 
            this.parall.AutoSize = true;
            this.parall.Location = new System.Drawing.Point(710, 1);
            this.parall.Name = "parall";
            this.parall.Size = new System.Drawing.Size(84, 16);
            this.parall.TabIndex = 4;
            this.parall.Text = "多线程加速";
            this.parall.UseVisualStyleBackColor = true;
            this.parall.CheckedChanged += new System.EventHandler(this.parall_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(794, 488);
            this.Controls.Add(this.conttab);
            this.ForeColor = System.Drawing.Color.DimGray;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "弹幕播放器";
            this.TransparencyKey = System.Drawing.Color.Gray;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.conttab.ResumeLayout(false);
            this.conttab.PerformLayout();
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
    }
}

