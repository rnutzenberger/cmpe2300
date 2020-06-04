using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;

namespace RNutzenbergerICA9
{
    class Sheeple
    {
        public const int iMin = 2;
        public const int iMax = 8;
        public static Random _rnd = new Random();
        public int iTotal { get; private set; }
        public int iCurrentLeft { get; private set; }
        public Color sheepleColor { get; private set; }
        public bool Done
        {
            get
            {
                return (iCurrentLeft == 0);
            }
        }

        public Sheeple()
        {
            iTotal = _rnd.Next(iMin, iMax);
            iCurrentLeft = iTotal;
            sheepleColor = RandColor.GetColor();
        }



        public void Process()
        {
            iCurrentLeft--;
        }

        public void ShowSheeple(CDrawer _canvas, int _xVal, int _yVal)
        {
            _canvas.AddRectangle(_xVal, _yVal, iTotal, 1, sheepleColor);
            if(_xVal == 0)
            {
                _canvas.AddText(iCurrentLeft.ToString(), 12, _xVal, _yVal, iTotal, 1);
            }
            
        }
    }
}
