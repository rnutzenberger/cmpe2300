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

namespace RNutzenbergerICA13
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            
            Shown += Form1_Shown;

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            derivedGDI canvas = new derivedGDI();
            PicDrawer pic = new PicDrawer();
            pic.AlignToForm(this);
            canvas.AlignToDrawer(pic);
                      
            
            
        }
    }

    public static class AlignDrawer
    {
        public static void AlignToForm(this CDrawer drawer, Form form)
        {
            drawer.Position = new Point(form.Location.X + form.Width, form.Location.Y);

        }

        public static void AlignToDrawer(this CDrawer canvas, CDrawer drawer)
        {
            canvas.Position = new Point(drawer.Position.X + drawer.ScaledWidth, drawer.Position.Y);

        }
    }


}
