using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Home0409_11_7_Watch
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            InitWatch();
            secTimer.Start();
            _watchGraph = watchPanel.CreateGraphics();
            _signGraph = signPanel.CreateGraphics();
        }

        private void watchPanel_Paint(object sender, PaintEventArgs e)
        {
            GetSizes();
            DrawWatchBase();
            GetTime();
            DrawWatchSign();
            DrawWatchTime();
        }

        private Graphics _watchGraph;
        private Graphics _signGraph;

        private SolidBrush _watchBackgroundBrush;
        private SolidBrush _watchBackgroundBrush2;
        private SolidBrush _watchStringBrush;

        private Font _fontWatch;

        private Pen _watchArrHourPen;
        private Pen _watchArrMinPen;
        private Pen _watchArrSecPen;
        private Pen _watchNumbers;

        private Color _watchColor;
        private Color _watchColor2;

        private Rectangle _timeRect;
        private Rectangle _hourRect;
        private Rectangle _minRect;
        private Rectangle _secRect;
        private Rectangle _numbersRect;
        private int _signSize;
        private Rectangle _signRect;

        private int _centerX;
        private int _centerY;
        private int _radius;

        private int _sec;
        private int _min;
        private int _hour;
        private float _s;
        private float _m;
        private float _h;

        private DateTime _dt = DateTime.Now;
        
        private void InitWatch()
        {
            _watchColor = Color.FromArgb(255, 248, 190, 114);
            _watchColor2 = Color.FromArgb(255, 163, 98, 9);
            _watchBackgroundBrush = new SolidBrush(_watchColor);
            _watchBackgroundBrush2 = new SolidBrush(_watchColor2);
            _watchStringBrush = new SolidBrush(Color.Black);

            _watchArrHourPen = new Pen(Brushes.DarkViolet, 8);
            _watchArrMinPen = new Pen(Brushes.DarkMagenta, 4);
            _watchArrSecPen = new Pen(Brushes.Black, 2);

            _fontWatch = new Font("Verbana", 30, FontStyle.Bold);
            _watchNumbers = new Pen(Brushes.Black, 8);
        }

        private void GetSizes()
        {
            _centerX = watchPanel.Width / 2;
            _centerY = watchPanel.Height / 2;
            _radius = _centerX - 35;

            _numbersRect = new Rectangle(15, 15, watchPanel.Width - 30, watchPanel.Height - 30);

            int t = (int)(watchPanel.Width * 0.825);
            _timeRect = new Rectangle((watchPanel.Width - t) / 2, (watchPanel.Width - t) / 2, t, t);

            int h = (int)(watchPanel.Width * 0.5);
            _hourRect = new Rectangle((watchPanel.Width - h) / 2, (watchPanel.Width - h) /2, h,h);

            int m = (int)(watchPanel.Width * 0.7);
            _minRect = new Rectangle((watchPanel.Width - m) / 2, (watchPanel.Width - m) / 2, m, m);

            int s = (int)(watchPanel.Width * 0.8);
            _secRect = new Rectangle((watchPanel.Width - s) / 2, (watchPanel.Width - s) / 2, s, s);

            _signSize = 80;
            _signRect = new Rectangle(_centerX - _signSize / 2, _centerY - _signSize / 2, _signSize, _signSize);
        }
        private void DrawWatchBase()
        {
            
            _watchGraph.FillEllipse(_watchBackgroundBrush2, 
                new Rectangle(0, 0, watchPanel.Width, watchPanel.Height));
            //_watchGraph.FillEllipse(_watchBackgroundBrush2,
                //new Rectangle(20, 20, watchPanel.Width - 40, watchPanel.Height - 40));

            string s12 = "12";
            string s9 = "9";
            string s6 = "6";
            string s3 = "3";

            SizeF size3 = _watchGraph.MeasureString(s3, _fontWatch);
            SizeF size6 = _watchGraph.MeasureString(s6, _fontWatch);
            SizeF size9 = _watchGraph.MeasureString(s9, _fontWatch);
            SizeF size12 = _watchGraph.MeasureString(s12, _fontWatch);

            _watchGraph.DrawString("12", _fontWatch, _watchStringBrush,
                new Point(_centerX - (int)size12.Width/2, 0));
            _watchGraph.DrawString("3", _fontWatch, _watchStringBrush, 
                new Point(watchPanel.Width - (int)(size3.Width), _centerY - (int)size3.Height/2));
            _watchGraph.DrawString("6", _fontWatch, _watchStringBrush,
                new Point(_centerX - (int)size6.Width / 2, watchPanel.Height - (int)(size6.Height * 0.85)));
            _watchGraph.DrawString("9", _fontWatch, _watchStringBrush,
                new Point(0, _centerY - (int)(size9.Height / 2)));

            _watchGraph.DrawArc(_watchNumbers, _numbersRect, 29, 2);
            _watchGraph.DrawArc(_watchNumbers, _numbersRect, 59, 2);
            _watchGraph.DrawArc(_watchNumbers, _numbersRect, 119, 2);
            _watchGraph.DrawArc(_watchNumbers, _numbersRect, 149, 2);
            _watchGraph.DrawArc(_watchNumbers, _numbersRect, 209, 2);
            _watchGraph.DrawArc(_watchNumbers, _numbersRect, 239, 2);
            _watchGraph.DrawArc(_watchNumbers, _numbersRect, 299, 2);
            _watchGraph.DrawArc(_watchNumbers, _numbersRect, 329, 2);
        }

        private void DrawWatchTime()
        {
            _watchGraph.FillEllipse(_watchBackgroundBrush, _timeRect);
            _h = (_hour * 30 + 270 + _min / 2) % 360;
            _m = (_min * 6 + 270) % 360;
            _s = (_sec * 6 + 270) % 360;
            _watchGraph.DrawPie(_watchArrHourPen, _hourRect, _h, 0.1F);
            _watchGraph.DrawPie(_watchArrMinPen, _minRect, _m, 0.1F);
            _watchGraph.DrawPie(_watchArrSecPen, _secRect, _s, 0.1F);

            //_watchGraph.DrawLine(new Pen(Color.Black, 1), _centerX, 0, _centerX, watchPanel.Height);
            //_watchGraph.DrawLine(new Pen(Color.Black, 1), 0, _centerY, watchPanel.Width, _centerY);
        }

        private void DrawWatchSign()
        {
            Bitmap bmp = new Bitmap("sign.png");
            Bitmap bmp2 = new Bitmap(bmp, new Size(80, 80));

           _signGraph.DrawImage(bmp2, new Point(0, 0));
        }

        private void secTimer_Tick(object sender, EventArgs e)
        {
            if (_sec != DateTime.Now.Second)
            {
                GetTime();
                DrawWatchTime();
            }
        }

        private void GetTime()
        {
            _dt = DateTime.Now;
            _hour = _dt.Hour;
            _min = _dt.Minute;
            _sec = _dt.Second;
        }
    }
}

// 163, 98, 9