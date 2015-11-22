namespace BKlink
{
    partial class DanmuSetting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DanmuSetting));
            this.op = new System.Windows.Forms.TrackBar();
            this.speed = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ok = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.op)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speed)).BeginInit();
            this.SuspendLayout();
            // 
            // op
            // 
            this.op.Location = new System.Drawing.Point(34, 24);
            this.op.Maximum = 90;
            this.op.Name = "op";
            this.op.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.op.Size = new System.Drawing.Size(45, 166);
            this.op.TabIndex = 0;
            this.op.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.op.Value = 90;
            this.op.Scroll += new System.EventHandler(this.op_Scroll);
            // 
            // speed
            // 
            this.speed.Location = new System.Drawing.Point(125, 24);
            this.speed.Name = "speed";
            this.speed.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.speed.Size = new System.Drawing.Size(45, 166);
            this.speed.TabIndex = 0;
            this.speed.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.speed.Value = 5;
            this.speed.Scroll += new System.EventHandler(this.speed_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(34, 201);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "透明度";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Location = new System.Drawing.Point(133, 201);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "速度";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F);
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.Location = new System.Drawing.Point(66, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "弹幕设置";
            // 
            // ok
            // 
            this.ok.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ok.FlatAppearance.BorderSize = 0;
            this.ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ok.Location = new System.Drawing.Point(176, 0);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(23, 21);
            this.ok.TabIndex = 3;
            this.ok.Text = "×";
            this.ok.UseVisualStyleBackColor = false;
            // 
            // DanmuSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(199, 222);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.speed);
            this.Controls.Add(this.op);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DanmuSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DanmuSetting";
            ((System.ComponentModel.ISupportInitialize)(this.op)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TrackBar op;
        public System.Windows.Forms.TrackBar speed;
        private System.Windows.Forms.Button ok;
    }
}