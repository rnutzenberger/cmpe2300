using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;

namespace RNutzenbergerICA14
{
    class derivedRand :Random
    {
        private int _max;

        public derivedRand(int max)
        {
            _max = max;
        }

        public Rectangle NextDrawerRect(CDrawer canvas)
        {
            int tempSize = _max;
            if (canvas is null)
            {
                throw new ArgumentException();
            }

            if (tempSize > canvas.ScaledWidth)
            {
                tempSize = canvas.ScaledWidth;
            }

            if (tempSize > canvas.ScaledHeight)
            {
                tempSize = canvas.ScaledHeight;
            }

            Size size = new Size(Next(10, tempSize + 1), Next(10, tempSize + 1));
            Point point = new Point(Next(0, canvas.ScaledWidth - size.Width), Next(0, canvas.ScaledHeight - size.Height));

            return new Rectangle(point, size);


        }
    }
}
