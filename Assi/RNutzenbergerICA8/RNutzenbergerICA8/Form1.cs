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

namespace RNutzenbergerICA8
{
    public partial class Form1 : Form
    {
        List<Ball> _BlueBalls = new List<Ball>();
        List<Ball> _RedBalls = new List<Ball>();
        List<Ball> _GreenBalls = new List<Ball>();
        CDrawer _OGCanvas = null;
        CDrawer _collidedCanvas = null;
        public Form1()
        {
            InitializeComponent();
            _OGCanvas = new CDrawer();
            _collidedCanvas = new CDrawer();
            _OGCanvas.ContinuousUpdate = false;
            _collidedCanvas.ContinuousUpdate = false;
            UI_Timer.Tick += UI_Timer_Tick;
            Shown += Form1_Shown;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            _OGCanvas.Position = new Point(Width + Location.X, Location.Y);
            _collidedCanvas.Position = new Point(Width + Location.X + _OGCanvas.ScaledWidth, Location.Y);
        }

        private void UI_Timer_Tick(object sender, EventArgs e)
        {
            

            if(_OGCanvas.GetLastMouseLeftClick(out Point _greenLoc))
            {
                Ball _greenBall = new Ball(_greenLoc,Color.Green);
                if (!_GreenBalls.Contains(_greenBall))
                {
                    _GreenBalls.Add(_greenBall);
                }
                
            }

            if(_OGCanvas.GetLastMouseRightClick(out Point _blueLoc))
            {

                Ball _blueBall = new Ball(_blueLoc, Color.Blue);
                if (_BlueBalls.IndexOf(_blueBall) == -1)
                {
                    _BlueBalls.Insert(0, _blueBall);
                }
            }
            
            _GreenBalls.ForEach((b) => b.Move(_OGCanvas));
            _BlueBalls.ForEach((b) => b.Move(_OGCanvas));
            _RedBalls.ForEach((b) => b.Move(_collidedCanvas));

            List<Ball> _Collided = _GreenBalls.Intersect(_BlueBalls).ToList();
            foreach(Ball b in _Collided)
            {
                
                while(_GreenBalls.Remove(b));
                while (_BlueBalls.Remove(b)) ;
                b.BallColor = Color.Red;
            }

            _RedBalls = new List<Ball>(_RedBalls.Union(_Collided));
            //for (int i = 1; i < _RedBalls.Count; i++)
            //{
            //    if (_RedBalls[0].Equals(_RedBalls[i]))
            //    {
            //        _RedBalls.RemoveAt(i);
            //    }
            //}

            _OGCanvas.Clear();
            _collidedCanvas.Clear();
            _OGCanvas.AddText($"Blue: {_BlueBalls.Count} Green: {_GreenBalls.Count}", 50, Color.Teal);
            _collidedCanvas.AddText($"{_RedBalls.Count}", 50, Color.Teal);


            for (int i = 0; i < _GreenBalls.Count; ++i)
            {
                _GreenBalls[i].Show(_OGCanvas, i);
            }
            for (int i = 0; i < _BlueBalls.Count; ++i)
            {
                _BlueBalls[i].Show(_OGCanvas, i);
            }
            for (int i = 0; i < _RedBalls.Count; ++i)
            {
                _RedBalls[i].Show(_collidedCanvas, i);
            }
            //_GreenBalls.ForEach((b) => b.Show(_OGCanvas, _GreenBalls.IndexOf(b)));
            //_BlueBalls.ForEach((b) => b.Show(_OGCanvas, _BlueBalls.IndexOf(b)));
            //_RedBalls.ForEach((b) => b.Show(_collidedCanvas, _RedBalls.IndexOf(b)));


            _OGCanvas.Render();
            _collidedCanvas.Render();


        }
    }
}
