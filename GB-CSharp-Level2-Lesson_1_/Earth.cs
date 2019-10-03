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
    class  Earth : Background
    {
        protected Bitmap bit;
        protected byte[] bitByte;

        public Earth(PointGrath pos, Speed dir, PointGrath size, Screen screen) : base(pos, dir, size, screen)
        {
            bit = (Bitmap)Image.FromFile("Earth.png");
        }

        public override bool Draw(Random r)
        {
            GL.Color3(Color.Blue);
            GL.LineWidth(2);
            GL.Begin(PrimitiveType.TriangleFan);

            for (var i = 0; i <= 50; i++)
            {
                var a = (float)i / 50.0f * 3.1415f * 2.00f;
                GL.Vertex2((pos.X + Math.Cos(a) * size.X), screen.Height - (pos.Y + Math.Sin(a) * size.X));
            }
            GL.End();

            GL.Color3(Color.Gray);
            Print2D((float)pos.X - bit.Width / 2, (float)(screen.Height - (pos.Y - bit.Height / 2)));
            return true;
        }

        /// <summary>
        /// Построение растрового изображения в одном цвете
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void Print2D(float x, float y)
        {
            GL.RasterPos2(x, y);
            if (bitByte == null || bitByte.Length == 0)
                bitByte = GenerateBytesArray(bit);
            GL.PixelStore(PixelStoreParameter.UnpackAlignment, 1);

            GL.Bitmap((int)bit.Width,
                (int)bit.Height,
                bit.Width / 2, bit.Height / 2, 0, 0, bitByte);
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
