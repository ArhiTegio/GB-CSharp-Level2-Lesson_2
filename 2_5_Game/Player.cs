﻿using System;
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
    class Player
    {
        protected Bitmap spaceship;
        protected PointGrath pos;
        protected Speed dir;
        protected PointGrath size;
        protected Screen screen;
        protected byte[] spaceshipByte;

        public Player(PointGrath pos, Speed dir, PointGrath size, Screen screen)
        {
            this.screen = screen;
            this.pos = pos;
            this.dir = dir;
            this.size = size;
            spaceship = (Bitmap)Image.FromFile("rocket2.png");
        }
        
        /// <summary>
        /// Построить объект
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public virtual bool Draw(Random r, PointGrath p)
        {
            GL.Color3(Color.Honeydew);
            PrintSpaceShip2D((float)p.X - spaceship.Width / 2, (float)p.Y + spaceship.Height / 2);
            return true;
        }

        /// <summary>
        /// Обновить параметры объекта
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public virtual bool Update(Random r)
        {
            pos.X += (int)(Math.Round(dir.X, 3) + r.NextDouble() * 1);
            pos.Y += (int)(Math.Round(dir.Y, 3) + r.NextDouble() * 1);
            if (pos.X < 0 + (size.X / 2)) dir.X = -dir.X;
            if (pos.X > screen.Width - size.X) dir.X = -dir.X;
            if (pos.Y < 0 + (size.Y / 2)) dir.Y = -dir.Y;
            if (pos.Y > screen.Height - size.Y) dir.Y = -dir.Y;

            if (pos.Y > (screen.Height - size.Y / 2) + 2 || (0 - 1) > pos.Y ||
                pos.X > (screen.Width - size.X / 2) + 2 || (0 - 1) > pos.X)
                return false;
            else
                return true;
        }

        /// <summary>
        /// Построение растрового изображения в одном цвете
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void PrintSpaceShip2D(float x, float y)
        {
           
            GL.RasterPos2(x, y);
            if (spaceshipByte == null || spaceshipByte.Length == 0)
                spaceshipByte = GenerateBytesArray(spaceship);
            //var text = spaceshipByte.Select(n => n.ToString() + ",").Aggregate((n, b) => n + b);
            GL.PixelStore(PixelStoreParameter.UnpackAlignment, 1);

            GL.Bitmap((int)(spaceship.Width),
                (int)(spaceship.Height),
                spaceship.Width / 2, spaceship.Height / 2, 0, 0, spaceshipByte);
        }
        
        /// <summary>
        /// Преобразовать растровое изображение в битовый массив
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private byte[] GenerateBytesArray(Bitmap bmp)
        {
            var binary = new char[bmp.Width];
            var list = new List<byte>();
            for (int y = bmp.Height - 1; y >= 0; --y)
            {
                for (int x = 0; x < bmp.Width; ++x)
                {
                    if (bmp.GetPixel(x, y).R == Color.White.R &&
                        bmp.GetPixel(x, y).G == Color.White.G &&
                        bmp.GetPixel(x, y).B == Color.White.B &&
                        bmp.GetPixel(x, y).A == Color.White.A) binary[x] = '0';
                    else binary[x] = '1';
                }
                var str = new string(binary);
                var number = (int)(str.Length / 8.0);
                if (str.Length % 8.0 != 0) number++;

                byte[] bytes = new byte[number];
                int c = 8;
                for (int i = 0; i < number; ++i)
                {
                    if (str.Length - 8 * i < 8) c = str.Length - 8 * i;
                    list.Add(Convert.ToByte(str.Substring(8 * i, c), 2));
                }
            }
            return list.ToArray();
        }
    }
}
