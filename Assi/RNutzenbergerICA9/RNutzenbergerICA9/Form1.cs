using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GDIDrawer;
using System.Threading;
using System.Diagnostics;


namespace RNutzenbergerICA9
{
    public partial class Form1 : Form
    {
        Stack<Sheeple> _sSheeple = new Stack<Sheeple>();
        List<Queue<Sheeple>> _lQueueSheeple = new List<Queue<Sheeple>>();
        CDrawer _canvas = null;
        int iScale = 20;
        int iProcessed;
        int iMaxSleep = 401;
        int iMinSleep = 200;
        Stopwatch _stopWatch = new Stopwatch();
        bool bRunning = false;

        public Form1()
        {
            InitializeComponent();
            _btnSim.Click += _btnSim_Click;
            UI_Timer.Tick += UI_Timer_Tick;
            UI_Timer.Interval = 20;
        }




        private void UI_Timer_Tick(object sender, EventArgs e)
        {
           
            if (_canvas is null)
            {
                return;
            }

            if (_sSheeple.Count > 0)
            {
                foreach (Queue<Sheeple> q in _lQueueSheeple)
                {
                    if (q.Count < 6 && _sSheeple.Count > 0)
                    {
                        q.Enqueue(_sSheeple.Pop());
                        break;
                    }
                }
            }
            _canvas.Clear();
            int yVal = 0;
            //BASE VERSION
            foreach (Queue<Sheeple> q in _lQueueSheeple)
            {
                int xVal = 0;
                
                lock (q)
                {
                    foreach (Sheeple s in q)
                    {
                        s.ShowSheeple(_canvas, xVal, yVal);
                        xVal += s.iTotal;
                    }
                    ++yVal;
                }
                if (_sSheeple.Count > 0)
                {
                    _lblNext.BackColor = _sSheeple.Peek().sheepleColor;
                    _lblNext.Text = _sSheeple.Peek().iTotal.ToString();
                }
                Text = iProcessed.ToString();
            }
            _canvas.Render();

            // IF Anything left ? stop your sw, output elapsed ms, to stop all threads flip running flag
            if (!_lQueueSheeple.Any((q) => q.Count > 0))
            {
                _stopWatch.Stop();
                bRunning = false;
                Text = $"{_stopWatch.ElapsedMilliseconds.ToString()} ms elapsed";
            }

            //BRAVE VERSION
            //if(_lQueueSheeple.Any((q) => q.Sum((s) => s.iTotal + _sSheeple.Peek().iTotal) < _canvas.ScaledWidth))
            //{
            //    _lQueueSheeple.OrderBy((q) => q.First().iCurrentLeft);


                
            //}


        }

        private void _btnSim_Click(object sender, EventArgs e)
        {
            _stopWatch.Restart();
            int iQueue = (int)_nudQueues.Value;
            bRunning = false;

            while(_lQueueSheeple.Any((q) => q.Count > 0))
            {
                Thread.Sleep(10);
            }

            _lQueueSheeple.Clear();
            _sSheeple.Clear();
            iProcessed = 0;

            if(!(_canvas is null))
            {
                _canvas.Close();
            }
       
            _canvas = new CDrawer(800, iQueue * iScale,false);
            _canvas.Position = new Point(Width + Location.X, Location.Y);
            _canvas.Scale = iScale;

            for(int i = 0; i < 200; ++i)
            {
                _sSheeple.Push(new Sheeple());
            }

            bRunning = true;

            for (int i = 0; i < iQueue; ++i)
            {
                _lQueueSheeple.Add(new Queue<Sheeple>());
                Thread thread = new Thread(new ParameterizedThreadStart(ProcessQueue));
                thread.IsBackground = true;
                thread.Start(_lQueueSheeple[i]);
            }
        }

        public void ProcessQueue(object obj)
        {
            if (!(obj is Queue<Sheeple> qQueue))
            {
                return;
            }

           
            int iSleepTime = Sheeple._rnd.Next(20,41)*10;
            while (bRunning)
            {
                Thread.Sleep(iSleepTime);
                lock (qQueue)
                {
                    if (qQueue.Count > 0)
                    {
                        qQueue.Peek().Process();
                        if (qQueue.Peek().Done)
                        {
                            iProcessed += qQueue.Dequeue().iTotal;
                        }
                    }
                }

            }
            lock(qQueue)
                qQueue.Clear();
            Trace.WriteLine($"Thread [{Thread.CurrentThread.ManagedThreadId}] done!");
            


        }
    }

   
}
