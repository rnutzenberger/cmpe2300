using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;

namespace RNutzenbergerICA13
{
    class PicDrawer : CDrawer
    {
        public PicDrawer() : base(Properties.Resources.owen_wilson.Width, Properties.Resources.owen_wilson.Height)
        {
            Bitmap bm = new Bitmap(Properties.Resources.owen_wilson);
            for(int y = 0; y < ScaledHeight; y++)
            {
                for(int x = 0; x < ScaledWidth; x++)
                {
                    Color c = bm.GetPixel(x, y);
                    int avg = (c.R+ c.G+ c.B) / 3;
                    SetBBPixel(x, y, Color.FromArgb(avg, avg, avg));
                }
            }
        }
    }
}
