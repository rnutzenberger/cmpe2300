using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;

namespace RNutzenbergerICA13
{
    class derivedGDI : CDrawer
    {
        derivedRand rand = null;

        public derivedGDI() : base(800,400)
        {
            rand = new derivedRand(ScaledWidth / 5);
            BBColour = Color.White;

            for(int i = 0; i < 100; i++)
            { 
                AddRectangle(rand.NextDrawerRect(this), RandColor.GetKnownColor());
            }
        }


    }
}
