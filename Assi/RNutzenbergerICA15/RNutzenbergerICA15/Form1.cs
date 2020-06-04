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
using RNutzenbergerDrawers;
using System.Threading;

namespace RNutzenbergerICA15
{
    public partial class Form1 : Form
    {
        PicDrawer _pCanvas = null;
        Keys input;
        List<Block> _LBlocks = new List<Block>();


        public Form1()
        {
            InitializeComponent();

            _pCanvas = new PicDrawer(Properties.Resources.owen_wilson);
            
            _pCanvas.ContinuousUpdate = false;
            _pCanvas.KeyboardEvent += _pCanvas_KeyboardEvent;
            KeyDown += Form1_KeyDown;
            Load += Form1_Load;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _pCanvas.AlignToForm(this);

            Thread _threadMove = new Thread(MoveThread);
            _threadMove.IsBackground = true;
            _threadMove.Start();

            Thread _threadShow = new Thread(RenderThread);
            _threadShow.IsBackground = true;
            _threadShow.Start();

            Thread _threadInput = new Thread(InputThread);
            _threadInput.IsBackground = true;
            _threadInput.Start();
        }

        //thread calls move
        private void MoveThread()
        {
            while (true)
            {
                lock (_LBlocks)
                {
                    _LBlocks.ForEach((b) => b.Move(_LBlocks));
                }
                Thread.Sleep(100);
            }
        }
        
        //thread calls the SHowBlock
        private void RenderThread()
        {
            while (true)
            {
                _pCanvas.Clear();
                lock(_LBlocks)
                {
                    _LBlocks.ForEach((b) => b.ShowBlock(_pCanvas));
                }
                _pCanvas.Render();
                Thread.Sleep(50);
            }
        }

        //thread to control our input
        private void InputThread()
        {
            

            while (true)
            {
                
                
                if (input != Keys.None)
                {
                    _pCanvas.GetLastMousePosition(out Point p);

                    if(input == Keys.F)
                    {
                        lock (_LBlocks)
                        {
                            _LBlocks.Add(new FallingBlock(p));
                        }
                    }

                    if(input == Keys.D)
                    {
                        lock (_LBlocks)
                        {
                            _LBlocks.Add(new DrunkBlock(p));
                        }
                    }

                    if(input == Keys.C)
                    {
                        lock (_LBlocks)
                        {
                            _LBlocks.Add(new ColourBlock(p));
                        }
                    }

                    if(input == Keys.Escape)
                    {
                        lock (_LBlocks)
                        {
                            _LBlocks.RemoveAll((b) => b.Outside);
                        }
                    }

                    if(input == Keys.F1)
                    {
                        lock (_LBlocks)
                        {
                            _LBlocks.Clear();
                        }
                    }
                    input = Keys.None;

                }

                Thread.Sleep(50);
            }
        }

        private void _pCanvas_KeyboardEvent(bool bIsDown, Keys keyCode, CDrawer dr)
        {
            if (bIsDown)
            {
                input = keyCode;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            input = e.KeyCode;
        }

        
    }

    
}
