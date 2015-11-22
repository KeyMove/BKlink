using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BKlink
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", EntryPoint = "GetWindowText")]
        public static extern int GetWindowText(
            IntPtr hWnd,
            StringBuilder lpString,
            int nMaxCount
        );

        [DllImport("user32.dll", EntryPoint = "GetClassName")]
        public static extern int GetClassName(
            IntPtr hWnd,
            StringBuilder lpString,
            int nMaxCont
        );

        [DllImport("user32", EntryPoint = "GetWindowThreadProcessId")]
        private static extern int GetWindowThreadProcessId(IntPtr hwnd, out int pid);


        List<bilibiliXML.DanmuInfo>[] list = null;
        bool state = false;
        Graphics g;
        int mx = -1, my = -1;
        int hidetime = 0;
        int pid;
        public Form1()
        {
            InitializeComponent();
        }

        private void Sub_Click(object sender, EventArgs e)
        {
            List<string> namelist = new List<string>();
            list = bilibiliXML.GetbilibiliXML(URLtext.Text, namelist);
            if (list != null)
            {
                ViedoList.Items.Clear();
                for (int i = 0; i < list.Length; i++)
                    ViedoList.Items.Add(namelist[i]);
                ViedoList.SelectedIndex = 0;
                PlayInfo.Text = "已选择 " + ViedoList.SelectedItem;
                DanmuInfo.Text = "弹幕数量:" + list[0].Count;
                pid = 0;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //this.TopMost = true;
            this.FormClosed += (object s, FormClosedEventArgs ex) => {
                GC.Collect();
                System.Environment.Exit(0);
            };
            Timer t = new Timer();
            t.Interval = 300;
            t.Tick += (object s, EventArgs er) =>
            {
                IntPtr handle = GetForegroundWindow();
                StringBuilder sb = new StringBuilder(256);
                GetWindowText(handle, sb, 256);
                WindowInfo.Text = sb.ToString();
                sb = new StringBuilder(256);
                GetClassName(handle, sb, 256);
                ClassInfo.Text = sb.ToString();
                int v = 0;
                int x = GetWindowThreadProcessId(handle, out v);
                MethodInfo.Text = Process.GetProcessById(v).ProcessName;
                if (bilibiliXML.isPlay)
                {
                    this.TopMost = true;
                    if (!time.Focused)
                    {
                        double xa = bilibiliXML.Time;
                        time.Text = "" + (int)(xa / 60) + ":" + (int)(xa % 60);
                    }

                    if (bilibiliXML.isPlay)
                    {
                        Point p = Cursor.Position;
                        if (p.X == mx && p.Y == my && !time.Focused && !conttab.Bounds.Contains(this.PointToClient(p)))
                        {
                            if (hidetime < 9)
                            {
                                if (++hidetime >= 9)
                                {
                                    hidetime = 0;
                                    if (conttab.Visible)
                                        conttab.Visible = false;
                                }
                            }
                        }
                        else
                        {
                            if (!conttab.Visible)
                                conttab.Visible = true;
                        }
                        mx = p.X;
                        my = p.Y;
                    }
                }
            };
            t.Start();
        }

        private void play_Click(object sender, EventArgs e)
        {
            if (list == null) return;
            if (!state)
            {
                play.Text = "停止";
                PlayInfo.Text = "正在播放" + ViedoList.Items[pid];
                this.TransparencyKey = Color.Gray;
                g = this.CreateGraphics();
                state = true;
                bilibiliXML.SetupDanmu(list[pid]);
                bilibiliXML.StartPlay(this.Width, this.Height - 24, g, Color.Gray);
                pause.Enabled = true;
                pause.BackColor = Color.Maroon;
                pause.Text = "暂停";
                pause.Visible = true;
                this.TopMost = false;
            }
            else
            {
                play.Text = "播放";
                PlayInfo.Text = "已选择" + ViedoList.Items[pid];
                //this.TransparencyKey = Color.AliceBlue;
                g.Dispose();
                state = false;
                bilibiliXML.StopDanmu();
                pause.Visible = false;
            }

        }

        private void pause_Click(object sender, EventArgs e)
        {
            if (pause.BackColor == Color.Maroon)
            {
                pause.Text = "继续";
                bilibiliXML.Pause = true;
                pause.BackColor = Color.LimeGreen;
            }
            else
            {
                pause.Text = "暂停";
                bilibiliXML.Pause = false;
                pause.BackColor = Color.Maroon;
            }
        }

        private void ViedoList_DoubleClick(object sender, EventArgs e)
        {
            if (ViedoList.SelectedIndex != pid)
            {
                pid = ViedoList.SelectedIndex;
                if (bilibiliXML.isPlay)
                    PlayInfo.Text = "正在播放" + ViedoList.Items[pid];
                else
                    PlayInfo.Text = "已选择" + ViedoList.Items[pid];
                DanmuInfo.Text = "弹幕数量:" + list[pid].Count;
                bilibiliXML.SetupDanmu(list[pid]);
                bilibiliXML.Time = 0;
            }
        }

        private void parall_CheckedChanged(object sender, EventArgs e)
        {
            bilibiliXML.ParallelPlay = ((CheckBox)sender).Checked;
        }

        FontDialog fd = new FontDialog();
        private void 设置字体ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (fd.ShowDialog() == DialogResult.OK)
            {
                bilibiliXML.DisplayFont = fd.Font;
            }
        }

        DanmuSetting setting;
        private void 弹幕设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

            if (setting == null)
                setting = new DanmuSetting((int op, int speed) =>
                {
                    bilibiliXML.DrawMoveSpeed = speed + 2;
                    this.Opacity = (op + 10) / 100F;
                });
            setting.ShowDialog();
        }

        private void time_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                try
                {
                    double t;
                    if (time.Text.Contains(':'))
                    {
                        string[] ts = time.Text.Split(':');
                        t = double.Parse(ts[0])*60;
                        t += double.Parse(ts[1]);
                        
                    }
                    else
                    {
                        t = double.Parse(time.Text);
                    }
                    bilibiliXML.Time=t;
                }
                catch
                {

                }
            }
        }
    }
}
