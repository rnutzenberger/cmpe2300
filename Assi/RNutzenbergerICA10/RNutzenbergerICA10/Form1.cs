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

namespace RNutzenbergerICA10
{
    public partial class Form1 : Form
    {
        public static Random RND = new Random();
        List<Point> _LPoints = new List<Point>();
        LinkedList<Point> _LinkedLPoints = new LinkedList<Point>();
        CDrawer _canvas = new CDrawer();

        public Form1()
        {
            InitializeComponent();
            _btnLLFilterOrder.Click += _btnLLFilterOrder_Click;
            _btnLLPop.Click += _btnLLPop_Click;
            _btnShuffle.Click += _btnShuffle_Click;
            _btnMakeList.Click += _btnMakeList_Click;
            Shown += Form1_Shown;
            _canvas.ContinuousUpdate = false;
            

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            _canvas.Position = new Point(Width + Location.X, Location.Y);
        }

        private void _btnMakeList_Click(object sender, EventArgs e)
        {
            _LPoints.Clear();
            MakeList(_LPoints);
            DrawPoints(_LPoints, Color.Fuchsia);
            
            _btnMakeList.Text = $"List Contains: {_LPoints.Count} Points";
        }

        private void _btnShuffle_Click(object sender, EventArgs e)
        {
            _LPoints.FYShuffle();
            DrawPoints(_LPoints,Color.Green);
        }

        private void _btnLLPop_Click(object sender, EventArgs e)
        {
            int h = (int)_nudDivisor.Value * _canvas.ScaledHeight;
            _LinkedLPoints.Clear();
            foreach (Point p in _LPoints)
            {

                LinkedListNode<Point> _currentNode = _LinkedLPoints.First;
                while (_currentNode != null && (_currentNode.Value.X * h + _currentNode.Value.Y) > (p.X * h + p.Y))
                {
                    
                    _currentNode = _currentNode.Next;
                }
                //if your current spot is not null, then add before your node, else add after it
                if (_currentNode != null)
                {
                    _LinkedLPoints.AddBefore(_currentNode, p);
                }
                else
                {
                    _LinkedLPoints.AddLast(p);
                }
            }

            DrawLinkedPoints(_LinkedLPoints, Color.Yellow);
            _btnLLPop.Text = $"LinkedList contains: {_LinkedLPoints.Count} Points";


        }

        private void _btnLLFilterOrder_Click(object sender, EventArgs e)
        {
            int iDiv =(int)_nudDivisor.Value;

            //filtering out all points where the sum is not even and then ordering by the distance from the top left corner of the drawer
            LinkedList<Point> _FilteredList = new LinkedList<Point>(_LinkedLPoints.Where((p) => (p.X + p.Y) % 2 != 0)
                .OrderBy((p) => Math.Pow(p.X, 2) + Math.Pow(p.Y, 2)));

            DrawLinkedPoints(_FilteredList, Color.Blue);
            _btnLLFilterOrder.Text = $"Filtered LinkedList contains : {_FilteredList.Count}";
        }
        
        //Makes a list of points
        private void MakeList(List<Point> LPoints)
        {

            _canvas.Scale = (int)_nudDivisor.Value;
            for (int y = 0; y < _canvas.ScaledHeight; ++y)
            {
                for (int x = 0; x < _canvas.ScaledWidth; ++x)
                {
                    LPoints.Add(new Point(x, y));
                }
            }
        }
        //draws the List points on the canvas
        private void DrawPoints(List<Point> LPoints, Color color)
        {
            _canvas.Clear();
            for (int i = 0; i < LPoints.Count - 1; ++i)
            {
                _canvas.AddLine(LPoints[i].X, LPoints[i].Y, LPoints[i + 1].X, LPoints[i + 1].Y, color);
            }
            _canvas.Render();
        }

        //Draws the Linked List Points on the canvas
        private void DrawLinkedPoints(LinkedList<Point> LLPoint, Color color)
        {
            _canvas.Clear();
            for (LinkedListNode<Point> LLNode = LLPoint.First; LLNode != null; LLNode = LLNode.Next)
            {
                if (LLNode.Next != null)
                {
                    _canvas.AddLine(LLNode.Value.X, LLNode.Value.Y, LLNode.Next.Value.X, LLNode.Next.Value.Y, color);
                }
            }
            _canvas.Render();
        }
    }

    public static class MyLibrary
    {
        public static void FYShuffle(this List<Point> _LPoints)
        {
            int i = _LPoints.Count;
            while (i > 1)
            {
                i--;
                int j = Form1.RND.Next(i + 1);
                Point temp = _LPoints[j];
                _LPoints[j] = _LPoints[i];
                _LPoints[i] = temp;
            }
        }
    }
}
