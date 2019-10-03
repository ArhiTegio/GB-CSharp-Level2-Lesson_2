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
    class Asteroid : BaseObject
    {
        public int Power { get; set; }

        public Asteroid(PointGrath pos, Speed dir, PointGrath size, Screen screen, int power) : base(pos, dir, size, screen)
        {
            Power = power;
        }

        public override bool Draw(Random r)
        {
            GL.Color3(Color.Red);
            Print2D((float)pos.X - bit.Width / 2, (float)pos.Y + bit.Height / 2);
            //return true;
            return Update(r);
            //Game.Buffer.Graphics.FillEllipse(Brushes.White, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        /// <summary>
        /// Построение растрового изображения в одном цвете
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void Print2D(float x, float y)
        {
            //Построение круга
            GL.Color3(Color.Red);
            GL.LineWidth(1);
            GL.Begin(PrimitiveType.LineLoop);
            for (var i = 0; i <= 25; i++)
            {
                var a = (float)i / 25.0f * 3.1415f * 2.00f;
                GL.Vertex2(pos.X + Math.Cos(a) * size.X, pos.Y + Math.Sin(a) * size.Y);
            }
            GL.End();
        }

        /// <summary>
        /// Обновить параметры объекта
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public override bool Update(Random r)
        {
            pos.X += (int)dir.X;
            pos.Y += (int)dir.Y;
            if (pos.X < 0 + (size.X / 2)) dir.X = -dir.X;
            if (pos.X > screen.Width - size.X) dir.X = -dir.X;
            if (pos.Y < 0 + (size.Y / 2)) dir.Y = -dir.Y;
            if (pos.Y > screen.Height - size.Y) dir.Y = -dir.Y;
            return false;
        }

    }
}
