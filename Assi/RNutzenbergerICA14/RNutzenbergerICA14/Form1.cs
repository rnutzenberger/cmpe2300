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


namespace RNutzenbergerICA14
{
    public partial class Form1 : Form
    {
        List<Ball> _GreenBalls = new List<Ball>();
        List<Ball> _BlueBalls = new List<Ball>();
        List<Ball> _RedBalls = new List<Ball>();
        PicDrawer _RGpicDrawer = null;
        RectDrawer _YrectDrawer = null;
        public Form1()
        {
            InitializeComponent();
            _RGpicDrawer = new PicDrawer(Properties.Resources.owen_wilson);
            _YrectDrawer = new RectDrawer(_RGpicDrawer.ScaledWidth,_RGpicDrawer.ScaledHeight);
            
            UI_Timer.Tick += UI_Timer_Tick;
            Shown += Form1_Shown;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            _RGpicDrawer.AlignToForm(this);
            _YrectDrawer.AlignToDrawer(_RGpicDrawer,AlignDrawer.Placement.Down);
        }

        private void UI_Timer_Tick(object sender, EventArgs e)
        {


            if (_RGpicDrawer.GetLastMouseLeftClick(out Point _greenLoc))
            {
                Ball _greenBall = new Ball(_greenLoc, Color.Green);
                if (!_GreenBalls.Contains(_greenBall))
                {
                    _GreenBalls.Add(_greenBall);
                }

            }

            if (_RGpicDrawer.GetLastMouseRightClick(out Point _BlueLoc))
            {

                Ball _BlueBall = new Ball(_BlueLoc, Color.Blue);
                if (_BlueBalls.IndexOf(_BlueBall) == -1)
                {
                    _BlueBalls.Insert(0, _BlueBall);
                }
            }

            _GreenBalls.ForEach((b) => b.Move(_RGpicDrawer));
            _BlueBalls.ForEach((b) => b.Move(_RGpicDrawer));
            _RedBalls.ForEach((b) => b.Move(_YrectDrawer));

            List<Ball> _Collided = _GreenBalls.Intersect(_BlueBalls).ToList();
            foreach (Ball b in _Collided)
            {

                while (_GreenBalls.Remove(b)) ;
                while (_BlueBalls.Remove(b)) ;
                b.BallColor = Color.Red;
            }

            _RedBalls = new List<Ball>(_RedBalls.Union(_Collided));
         

            _RGpicDrawer.Clear();
            _YrectDrawer.Clear();
            _RGpicDrawer.AddText($"Blue: {_BlueBalls.Count} Green: {_GreenBalls.Count}", 45, Color.Teal);
            _YrectDrawer.AddText($"{_RedBalls.Count}", 50, Color.Red);


            for (int i = 0; i < _GreenBalls.Count; ++i)
            {
                _GreenBalls[i].Show(_RGpicDrawer, i);
            }
            for (int i = 0; i < _BlueBalls.Count; ++i)
            {
                _BlueBalls[i].Show(_RGpicDrawer, i);
            }
            for (int i = 0; i < _RedBalls.Count; ++i)
            {
                _RedBalls[i].Show(_YrectDrawer, i);
            }

            _RGpicDrawer.Render();
            _YrectDrawer.Render();

        }
    }
    public static class AlignDrawer
    {
        public enum Placement { Right, Down };
       
        public static void AlignToForm(this CDrawer drawer, Form form, Placement placement = Placement.Right)
        {
            

            switch (placement)
            {
                case Placement.Right:
                    drawer.Position = new Point(form.Location.X + form.Width, form.Location.Y);
                    break;

                case Placement.Down:
                    drawer.Position = new Point(form.Location.X, form.Height + form.Location.Y);
                    break;

                default:
                    break;

            }
            

        }

        public static void AlignToDrawer(this CDrawer canvas, CDrawer drawer, Placement placement = Placement.Right)
        {
            switch (placement)
            {
                case Placement.Right:
                    canvas.Position = new Point(drawer.Position.X + drawer.ScaledWidth, drawer.Position.Y);
                    break;

                case Placement.Down:
                    canvas.Position = new Point(drawer.Position.X , drawer.Position.Y + drawer.ScaledHeight);
                    break;

                default:
                    break;

            }
            

        }
    }
}
