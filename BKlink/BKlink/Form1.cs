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
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]

        static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);

        [StructLayout(LayoutKind.Sequential)]

        public struct RECT
        {

            public int Left; //最左坐标

            public int Top; //最上坐标

            public int Right; //最右坐标

            public int Bottom; //最下坐标 
        }

            [DllImport("user32", EntryPoint = "GetWindowThreadProcessId")]
        private static extern int GetWindowThreadProcessId(IntPtr hwnd, out int pid);


        List<bilibiliXML.DanmuInfo>[] list = null;
        bool state = false;
        Graphics g;
        int mx = -1, my = -1;
        int hidetime = 0;
        int pid;
        int contdelay;
        Process selectprocess;
        List<Process> processlist = new List<Process>();
        Color loadcolor = Color.FromArgb(248, 248, 248);
        public Form1()
        {
            InitializeComponent();
            IconBox.Image= this.Icon.ToBitmap();
        }

        void uicontrol(bool enable)
        {
            PlayBar.Enabled = time.Enabled = enable;
            Sub.Enabled = !enable;
        }

        private void Sub_Click(object sender, EventArgs e)
        {
            if (this.BackColor == loadcolor) return;
            Sub.Enabled = false;
            this.BackColor = loadcolor;
            LoadPicture.Enabled = LoadPicture.Visible = true;
            Task.Run(() => {
                try
                {
                    List<string> namelist = new List<string>();
                    list = bilibiliXML.GetbilibiliXML(URLtext.Text, namelist);
                    Invoke(new MethodInvoker(() =>
                    {
                        if (list != null)
                        {
                            ViedoList.Items.Clear();
                            for (int i = 0; i < list.Length; i++)
                                ViedoList.Items.Add(namelist[i]);
                            ViedoList.SelectedIndex = 0;
                            PlayInfo.Text = "已选择 " + ViedoList.SelectedItem;
                            DanmuInfo.Text = "弹幕数量:" + list[0].Count;
                            PlayBar.Maximum = (int)list[0][list[0].Count - 1].time + 1;
                            pid = 0;
                        }
                        else
                        {
                            DanmuInfo.Text = "获取失败";
                        }
                        Sub.Enabled = true;
                        LoadPicture.Enabled = LoadPicture.Visible = false;
                        this.BackColor = Color.Gray;
                    }));
                }
                catch
                {
                    Invoke(new MethodInvoker(() =>
                    {
                        Sub.Enabled = true;
                        DanmuInfo.Text = "获取失败";
                        LoadPicture.Enabled = LoadPicture.Visible = false;
                        this.BackColor = Color.Gray;
                    }));
                }
            });
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
                if (!windowlist.Focused)
                {
                    Process[] ptable = Process.GetProcesses();
                    //if (processlist.Count == 0) processlist.Add(null);
                    foreach(Process p in ptable)
                    {
                        if(!windowlist.Items.Contains(p.ProcessName))
                        {
                            processlist.Clear();
                            windowlist.Items.Clear();
                            processlist.AddRange(ptable);
                            foreach (Process ps in processlist)
                            {
                                windowlist.Items.Add(ps.ProcessName);
                            }
                            break;
                        }
                    }
                }
                if (pause.BackColor == Color.Maroon)
                    if (contdelay != 0)
                    {
                        if (--contdelay == 0)
                            bilibiliXML.Pause = false;
                        return;
                    }
                if (bilibiliXML.isPlay)
                {
                    if (followwindow.Checked)
                    {
                        if (selectprocess != null)
                            if (selectprocess.HasExited)
                            {
                                selectprocess = null;
                            }
                            else
                            {
                                movetowindowpos(selectprocess);
                            }
                    }
                    this.TopMost = true;
                    if (!time.Focused)
                    {
                        double xa = bilibiliXML.Time;
                        time.Text = "" + (int)(xa / 60) + ":" + (int)(xa % 60);
                        PlayBar.Value = (int)bilibiliXML.Time;
                        
                    }

                    if (bilibiliXML.isPlay)
                    {
                        Point p = Cursor.Position;
                        if (p.X == mx && p.Y == my && !time.Focused)
                        {
                            if (hidetime < 9)
                            {
                                if (++hidetime >= 9)
                                {
                                    hidetime = 0;
                                    if (conttab.Visible)
                                        titilepanle.Visible  = conttab.Visible = false;
                                }
                            }
                        }
                        else if(this.ClientRectangle.Contains(this.PointToClient(p)))
                        {
                            if (!conttab.Visible)
                                titilepanle.Visible = conttab.Visible = true;
                        }
                        mx = p.X;
                        my = p.Y;
                    }
                }
                else if (!conttab.Visible)
                    titilepanle.Visible = conttab.Visible = true;
            };
            t.Start();
        }

        private void play_Click(object sender, EventArgs e)
        {
            if (list == null) return;
            if (!state)
            {
                uicontrol(true);
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
                uicontrol(false);
                play.Text = "播放";
                PlayInfo.Text = "已选择" + ViedoList.Items[pid];
                //this.TransparencyKey = Color.AliceBlue;
                g.Dispose();
                state = false;
                titilepanle.Visible = conttab.Visible = true;
                bilibiliXML.StopDanmu();
                pause.Visible = false;
            }

        }

        private void pause_Click(object sender, EventArgs e)
        {
            if (pause.BackColor == Color.Maroon)
            {
                pause.Text = "播放";
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
                PlayBar.Maximum = (int)list[0][list[0].Count - 1].time + 1;
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

        private void MoveWindow1(object sender, MouseEventArgs e)
        {
            Control c = (Control)sender;
            if (e.Button == MouseButtons.Left)
            {
                c.Tag = new Point(this.Left-Cursor.Position.X, this.Top-Cursor.Position.Y);
            }
        }

        private void MoveWindow2(object sender, MouseEventArgs e)
        {
            Control c = (Control)sender;
            if (c.Tag is Point)
            {
                Point p = ((Point)c.Tag);
                this.Left = p.X + Cursor.Position.X;
                this.Top = p.Y + Cursor.Position.Y;
            }
        }

        private void MoveWindow3(object sender, MouseEventArgs e)
        {
            Control c = (Control)sender;
            if (e.Button == MouseButtons.Left)
            {
                c.Tag = null;
            }
        }

        private void PlayBar_Scroll(object sender, EventArgs e)
        {
            if (!bilibiliXML.isPlay) return;
            double xa = bilibiliXML.Time = PlayBar.Value;
            time.Text = "" + (int)(xa / 60) + ":" + (int)(xa % 60);
            contdelay = 2;
            bilibiliXML.Pause = true;
        }


        void movetowindowpos(Process p)
        {
            RECT rect = new RECT();
            bool updatewindow = false;
            selectprocess = p;
            GetWindowRect(p.MainWindowHandle, ref rect);
            int l = rect.Left - 8;
            int t = rect.Top;
            int w = rect.Right - rect.Left+16;
            int h = rect.Bottom - rect.Top + 8;
            if (this.Width != w && w > 100)
            {
                this.Width = w;
                updatewindow = true;
            }
            if (this.Height != h && h > 100)
            {
                this.Height = h;
                updatewindow = true;
            }
            if (this.Left != l)
                this.Left = l;
            if (this.Top != t)
                this.Top = t;
            if (updatewindow)
            {
                bilibiliXML.setWindowSize(this.Width, this.Height);
            }
        }

        private void windowlist_DoubleClick(object sender, EventArgs e)
        {
            if (windowlist.SelectedIndex != -1)
            {
                movetowindowpos(processlist[windowlist.SelectedIndex]);
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void time_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!bilibiliXML.isPlay) return;
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
