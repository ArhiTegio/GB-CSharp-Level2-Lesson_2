using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Тест_OpenTK
{
    abstract class BaseObject : ICollision
    {
        protected Bitmap bit;
        protected byte[] bitByte;
        protected PointGrath pos;
        protected Speed dir;
        protected PointGrath size;
        protected Screen screen;

        public BaseObject(PointGrath pos, Speed dir, PointGrath size, Screen screen)
        {
            this.screen = screen;
            this.pos = pos;
            this.dir = dir;
            this.size = size;
        }
        public abstract bool Draw(Random r);
        public abstract bool Update(Random r);

        public bool Collision(ICollision o) => o.Rect.IntersectsWith(this.Rect);

        public Rectangle Rect => new Rectangle((int)pos.X * 1000, (int)pos.Y * 1000, (int)size.X * 1000, (int)size.Y * 1000);
    }
}
