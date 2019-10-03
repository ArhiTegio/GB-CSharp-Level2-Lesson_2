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
    class Bullet : BaseObject
    {
        public int Power { get; set; }

        public Bullet(PointGrath pos, Speed dir, PointGrath size, Screen screen, int power) : base(pos, dir, size, screen)
        {
            Power = power;
        }


        public override bool Draw(Random r)
        {
            GL.Color3(Color.Red);
            Print2D((float)pos.X, (float)pos.Y);
            //return true;
            return Update(r);
            //Game.Buffer.Graphics.FillEllipse(Brushes.White, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        private void Print2D(float x, float y)
        {
            //Построение круга
            GL.Color3(Color.Salmon);
            GL.LineWidth(1);
            GL.Begin(PrimitiveType.LineLoop);
            GL.Vertex2(x , y);
            GL.Vertex2(x - 40, y - 20);
            GL.Vertex2(x - 40, y + 20);
            GL.End();
        }

        public override bool Update(Random r)
        {
            pos.X += (int)(dir.X);
            pos.Y += (int)(dir.Y);

            if (pos.Y > (screen.Height - size.Y / 2) + 2 || (0 - 1) > pos.Y ||
                pos.X > (screen.Width - size.X / 2) + 2 || (0 - 1) > pos.X)
                return false;
            else
                return true;
        }
    }
}
