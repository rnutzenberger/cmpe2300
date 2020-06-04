using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;
using RNutzenbergerDrawers;

namespace RNutzenbergerICA15
{
    class Block
    {
        protected RectangleF _rect;
        protected static Random _RND = new Random();

        public bool Outside { get; private set; }


        public Block(PointF point)
        {
            _rect.Location = point;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Block arg)) return false;
            if (ReferenceEquals(this, arg)) return false;

            return _rect.IntersectsWith(arg._rect);
        }
        public override int GetHashCode()
        {
            return 1;
        }

        public virtual void Move(List<Block> _lBlocks) 
        {

        }

        public virtual void ShowBlock(CDrawer canvas)
        {
           
            
            RectangleF temp = _rect;
            temp.Inflate(3, 3);

            canvas.AddRectangle((int)temp.X, (int)temp.Y, (int)temp.Width, (int)temp.Height, Color.Black);
            if (_rect.X + _rect.Width/2 > canvas.ScaledWidth || _rect.Y + _rect .Height/2 > canvas.ScaledHeight)
            {
                Outside = true;
                return;
            }
        }


    }

    class FallingBlock : Block
    {
        const float _fVel = 6;

        public FallingBlock(PointF point) : base(point)
        {
            _rect.Width = 50;
            _rect.Height = 50;
        }

        public override void Move(List<Block> _lBlocks)
        {

            if (!Outside)
            {
                if(!_lBlocks.Where((b)=> !ReferenceEquals(b,this)).Contains(this))
                {
                    _rect.Y += _fVel;
                }
            }
        }

        public override void ShowBlock(CDrawer canvas)
        {
            base.ShowBlock(canvas);
            canvas.AddRectangle((int)_rect.X, (int)_rect.Y, (int)_rect.Width, (int)_rect.Height, Color.White);
        }
    }

    class DrunkBlock : Block
    {
        const float _fVel = 3;
        float _fLatVel = 0;

        public DrunkBlock(PointF point) : base(point)
        {
            _rect.Width = 30;
            _rect.Height = 60;
        }

        public override void Move(List<Block> _lBlocks)
        {
            if (!Outside)
            {
                
                if (!_lBlocks.Where((b) => !ReferenceEquals(b, this)).Contains(this))
                {
                    _rect.Y += _fVel;

                    _fLatVel = (float)_RND.NextDouble() * 4 - 2;
                    _rect.X += _fLatVel;
                }
            }
        }

        public override void ShowBlock(CDrawer canvas)
        {
            base.ShowBlock(canvas);
            canvas.AddRectangle((int)_rect.X, (int)_rect.Y, (int)_rect.Width, (int)_rect.Height, Color.Pink);
        }
    }

    class ColourBlock : FallingBlock
    {
        const float _fVel = 3;
        private Color _col = RandColor.GetColor();

        public ColourBlock(PointF point) : base(point)
        {
            _rect.Width = 60;
            _rect.Height = 30;
        }

        public override void Move(List<Block> _lBlocks)
        {
            base.Move(_lBlocks);
            if ((_col.A - _fVel) >= 0)
            {
                _col = Color.FromArgb(_col.A - (int)_fVel, _col);
            }

        }

        public override void ShowBlock(CDrawer canvas)
        {
            base.ShowBlock(canvas);
            
            canvas.AddRectangle((int)_rect.X, (int)_rect.Y, (int)_rect.Width, (int)_rect.Height, _col);

        }
    }

}
