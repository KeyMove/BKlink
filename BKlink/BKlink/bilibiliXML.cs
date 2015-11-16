using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace BKlink
{
    class bilibiliXML
    {

        public enum DanmuType
        {
            move,
            top,
            bottom,
        }

        public class DanmuInfo
        {
            public double time;
            public DanmuType type;
            public Color color;
            public string message;
            public int x, y, w;
        }

        [DllImport("kernel32.dll")]
        public static extern bool QueryPerformanceCounter(ref Int64 count);

        [DllImport("kernel32.dll")]
        public static extern bool QueryPerformanceFrequency(ref Int64 frequency);

        //public class Danmu
        //{
        //    List<DanmuInfo> danmuinfo;
        //}

        //public static string bilibiliURLHead=@"http://www.bilibili.com/video/av{0}/";
        public static string bilibiliURLHead = @"http://www.bilibili.com/video/av{0}/index_{1}.html";
        public static string bilibilixmlHead = @"http://comment.bilibili.com/{0}.xml";

        public static List<DanmuInfo>[] GetbilibiliXML(string avid, List<string> namelist = null)
        {
            int id = GetAVID(avid);
            if (id!=-1)
            {
                return GetbilibiliXML(id,namelist);
            }
            return null;
        }

        public static int GetAVID(string avid)
        {
            int val = 0;
            int count = 0;
            //if (avid.Contains("av")) avid = avid.Substring(avid.IndexOf("av"));
            for (int i = 0; i < avid.Length; i++)
            {
                int c = avid[i];
                if (c <= '9' && c >= '0')
                {
                    count++;
                    val *= 10;
                    val += c - '0';
                }
                else if (count != 0)
                {
                    return val;
                }
            }
            return -1;
        }



        //获取弹幕信息
        public static List<DanmuInfo>[] GetbilibiliXML(int avid,List<string> namelist=null)
        {
            string v = HttpGetPage(string.Format(bilibiliURLHead, avid,1));

            int ppos = v.IndexOf("<option");
            int p = 1;
            int[] id;
            if (ppos != -1)
            {

                string[] fp = v.Substring(ppos,  v.LastIndexOf("</option>")-ppos+10).Split('\n');
                if (namelist != null)
                    namelist.Clear();
                p = 0;
                id = new int[fp.Length];
                for (int i=0;i<fp.Length;i++)
                {
                    int idx = GetAVID(fp[i]);
                    if (idx != -1)
                    {
                        if (namelist != null)
                        {
                            string fv = fp[i];
                            ppos = fv.IndexOf('>');
                            namelist.Add(fv.Substring(ppos + 1, fv.LastIndexOf('<') - ppos-1));
                        }
                        p++;
                    }
                }
                if (p == 0) p = 1;
                for (int i=0;i< p; i++)
                {
                    if(i!=0)
                        v = HttpGetPage(string.Format(bilibiliURLHead, avid, i+1));
                    string vx = v.Substring(v.IndexOf("cid="));
                    int ix = vx.IndexOf('&');
                    vx = vx.Substring(4, ix - 4);
                    id[i] = int.Parse(vx);
                }
            }
            else
            {
                if (namelist != null)
                {
                    namelist.Clear();
                    namelist.Add("1P");
                }
                string vx = v.Substring(v.IndexOf("cid="));
                int ix = vx.IndexOf('&');
                vx = vx.Substring(4, ix - 4);
                id = new int[1];
                id[0] = int.Parse(vx);
            }

            List<DanmuInfo>[] dxlist = new List<DanmuInfo>[p];
            for (int i = 0; i < p; i++)
            {
                List<DanmuInfo> dx = new List<DanmuInfo>();
                string url = string.Format(bilibilixmlHead, id[i]);
                v = HttpGetPage(url);
                XmlDocument danmuxml = new XmlDocument();
                danmuxml.LoadXml(v);
                foreach (XmlNode node in danmuxml.GetElementsByTagName("d"))
                {
                    if (node.FirstChild == null)
                        continue;
                    DanmuInfo dan = new DanmuInfo();
                    string[] info = node.Attributes[0].Value.Split(',');
                    switch (int.Parse(info[1]))
                    {
                        case 0:
                            continue;
                        case 1:
                        case 2:
                        case 3:
                            dan.type = DanmuType.move;
                            break;
                        case 4:
                            dan.type = DanmuType.bottom;
                            break;
                        case 5:
                            dan.type = DanmuType.top;
                            break;
                    }
                    dan.time = double.Parse(info[0]);
                    int color = int.Parse(info[3]);
                    dan.color = Color.FromArgb((color >> 16) & 0xff, (color >> 8) & 0xff, color & 0xff);
                    dan.message = node.FirstChild.Value;
                    dx.Add(dan);
                }
                dx.Sort((DanmuInfo a, DanmuInfo b) => { return a.time > b.time ? 1 : a.time == b.time ? 0 : -1; });
                dxlist[i] = dx;
            }
            return dxlist;
        }

        //获取网页数据
        public static string HttpGetPage(string url,bool gzip=false)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.Timeout = 5000;
                
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                Stream stream = response.GetResponseStream();
                string v=null;
                if (response.ContentEncoding.Contains("gzip")||gzip)
                {
                    StreamReader reader = new StreamReader(new GZipStream(stream, CompressionMode.Decompress));
                    v = reader.ReadToEnd();
                    reader.Close();
                }
                else if (response.ContentEncoding.Contains("deflate"))
                {
                    StreamReader reader = new StreamReader(new DeflateStream(stream, CompressionMode.Decompress));
                    v = reader.ReadToEnd();
                    reader.Close();
                     
                }
                else
                {
                    StreamReader reader = new StreamReader(stream);
                    v = reader.ReadToEnd();
                    reader.Close();
                }
                stream.Close();
                return v;
            }
            catch
            {
                return null;
            }
        }

        static bool playstate = false;
        static List<DanmuInfo> danmudata=null;
        static Bitmap map;
        static Graphics draw;
        static Font drawfont = new Font("宋体", 25);
        static int danmucount;
        static int DW, DH;
        static Color backcolor=Color.Black;
        static List<DanmuInfo> drawinfo=new List<DanmuInfo>();
        static double drawtime;
        static DanmuInfo[] moveLine;
        static DanmuInfo[] centLine;
        static int ysize = 0;
        static List<DanmuInfo> removeinfo = new List<DanmuInfo>();
        //static Font infofont= new Font("宋体", 12);
        static bool clearflag = false;
        static bool pauseflag = false;
        static Timer playtimer;
        static Int64 starttime;
        static Int64 sectick;
        static double offsettime;
        static int updatetick;
        public static void StartPlay(int w, int h, Graphics g,Color back,Font font=null)
        {
            if (!playstate)
            {
                DW = w;
                DH = h;
                if (font != null) drawfont = font;
                map = new Bitmap(w, h);
                draw = Graphics.FromImage(map);
                playstate = true;
                danmucount = 0;
                drawtime = 0;
                drawinfo.Clear();
                ysize = (int)(drawfont.Size * 1.2);
                moveLine = new DanmuInfo[(int)(h / ysize)];
                centLine = new DanmuInfo[(int)(h / ysize)];
                backcolor = back;
                pauseflag = clearflag = false;
                updatetick = 0;
                offsettime = 0;
                QueryPerformanceCounter(ref starttime);
                QueryPerformanceFrequency(ref sectick);
                playtimer = new Timer((object c) => {
                    if (pauseflag) return;
                    drawtime += 0.05;
                    if (++updatetick == 10)
                    {
                        updatetick = 0;
                        Int64 val=0;
                        QueryPerformanceCounter(ref val);
                        val = (val - starttime)/sectick;
                        drawtime = val+offsettime;
                    }
                });
                playtimer.Change(50, 50);
                Task.Run(() => {
                    while (playstate)
                    {
                        if (pauseflag)
                            continue;
                        if (danmudata != null)
                        {
                            if (danmucount < danmudata.Count)
                                while (true)
                                {
                                    if (danmucount >= danmudata.Count) break;
                                    DanmuInfo info = danmudata[danmucount];
                                    if (info.time > drawtime) break;
                                    int i=0;
                                    switch (info.type)
                                    {
                                        case DanmuType.move:
                                            for(i = 0; i < moveLine.Length; i++)
                                            {
                                                if (moveLine[i] == null)
                                                {
                                                    danmucount++;
                                                    info.x = DW;
                                                    info.y = ysize * i;
                                                    info.w = (int)(drawfont.Size * info.message.Length);
                                                    draw.DrawString(info.message, drawfont, new SolidBrush(info.color), info.x, info.y);
                                                    drawinfo.Add(info);
                                                    moveLine[i] = info;
                                                    break;
                                                }
                                                else if((moveLine[i].w+ moveLine[i].x) < DW)
                                                {
                                                    danmucount++;
                                                    info.x = DW;
                                                    info.y = ysize * i;
                                                    info.w = (int)(drawfont.Size * info.message.Length);
                                                    draw.DrawString(info.message, drawfont, new SolidBrush(info.color), info.x, info.y);
                                                    drawinfo.Add(info);
                                                    moveLine[i] = info;
                                                    break;
                                                }
                                            }
                                            break;
                                        case DanmuType.top:
                                            for (i = 0; i < centLine.Length; i++)
                                            {
                                                if (centLine[i] == null)
                                                {
                                                    danmucount++;
                                                    
                                                    info.y = ysize * i;
                                                    info.w = (int)(drawfont.Size * info.message.Length);
                                                    info.x = DW / 2 - info.w / 2;
                                                    info.w = 600;
                                                    draw.DrawString(info.message, drawfont, new SolidBrush(info.color), info.x, info.y);
                                                    drawinfo.Add(info);
                                                    centLine[i] = info;
                                                    break;
                                                }
                                            }
                                            break;
                                        case DanmuType.bottom:
                                            for (i = centLine.Length-1; i >0; i--)
                                            {
                                                if (centLine[i] == null)
                                                {
                                                    danmucount++;
                                                    info.x = DW;
                                                    info.y = ysize * i;
                                                    info.x = DW / 2 - info.w / 2;
                                                    info.w = (int)(drawfont.Size * info.message.Length);
                                                    draw.DrawString(info.message, drawfont, new SolidBrush(info.color), info.x, info.y);
                                                    drawinfo.Add(info);
                                                    centLine[i] = info;
                                                    break;
                                                }
                                            }
                                            if (i < 0) i = centLine.Length;
                                            break;
                                    }
                                    if (i == moveLine.Length)
                                        break;
                                }
                        }
                        draw.Clear(backcolor);
                        removeinfo.Clear();
                        if (clearflag)
                        {
                            clearflag = false;
                            drawinfo.Clear();
                            for (int i = 0; i < centLine.Length; i++)
                                centLine[i] = moveLine[i] = null;
                        }

                        //ParallelOptions opt = new ParallelOptions();
                        try
                        {
                            if (ParallelPlay)
                                Parallel.ForEach(drawinfo, (DanmuInfo info) =>
                                {
                                    switch (info.type)
                                    {
                                        case DanmuType.move:
                                            info.x -= 5;
                                            lock (draw)
                                                draw.DrawString(info.message, drawfont, new SolidBrush(info.color), info.x, info.y);
                                            if (info.x < -info.w)
                                                removeinfo.Add(info);
                                            break;
                                        case DanmuType.top:
                                        case DanmuType.bottom:
                                            info.w -= 5;
                                            lock (draw)
                                                draw.DrawString(info.message, drawfont, new SolidBrush(info.color), info.x, info.y);

                                            if (info.w < -info.w)
                                            {
                                                removeinfo.Add(info);
                                                for (int i = 0; i < centLine.Length; i++)
                                                {
                                                    if (info.Equals(centLine[i]))
                                                    {
                                                        centLine[i] = null;
                                                        break;
                                                    }
                                                }
                                            }
                                            break;
                                    }
                                });

                            else
                                foreach (DanmuInfo info in drawinfo)
                                {
                                    switch (info.type)
                                    {
                                        case DanmuType.move:
                                            info.x -= 5;
                                            draw.DrawString(info.message, drawfont, new SolidBrush(info.color), info.x, info.y);
                                            if (info.x < -info.w)
                                                removeinfo.Add(info);
                                            break;
                                        case DanmuType.top:
                                        case DanmuType.bottom:
                                            info.w -= 5;
                                            draw.DrawString(info.message, drawfont, new SolidBrush(info.color), info.x, info.y);
                                            if (info.w < -info.w)
                                            {
                                                removeinfo.Add(info);
                                                for (int i = 0; i < centLine.Length; i++)
                                                {
                                                    if (info.Equals(centLine[i]))
                                                    {
                                                        centLine[i] = null;
                                                        break;
                                                    }
                                                }
                                            }
                                            break;
                                    }
                                }
                        }
                        catch { continue; }
                        
                        foreach (DanmuInfo info in removeinfo)
                        {
                            drawinfo.Remove(info);
                        }
                        //draw.DrawString((int)(drawtime / 60) + ":" + (int)(drawtime % 60), infofont, Brushes.Blue, 10, DH - 16);
                        if(g!=null)
                            g.DrawImage(map, 0, 0);
                        Thread.Sleep(20);
                    }
                });
            }
        }

        public static bool isPlay
        {
            get { return playstate; }
            private set { }
        }

        public static bool ParallelPlay
        {
            get; set;
        }

        public static bool Pause
        {
            get { return pauseflag; }
            set {

                pauseflag = value;
                if (value == false)
                {
                    offsettime = drawtime;
                    QueryPerformanceCounter(ref starttime);
                }
            }
        }

        public static double Time
        {
            get { return drawtime; }
            set
            {
                drawtime = value;
                clearflag = true;
                for (int i = 0; i < danmudata.Count; i++)
                {
                    if (danmudata[i].time > value)
                    {
                        danmucount = i;
                        break;
                    }
                }
                offsettime = value;
                QueryPerformanceCounter(ref starttime);
            }
        }

        public static void SetTime(double time)
        {
            drawtime = time;
            clearflag = true;
        }



        public static void SetupDanmu(List<DanmuInfo> danmulist)
        {
            danmudata = danmulist;
        }

        public static void StopDanmu()
        {
            playstate = false;
            playtimer.Dispose();
            map.Dispose();
            draw.Dispose();
        }

    }
}
