using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Editovanje_bitpame
{
    public static class Konverzije
    {
        public static Bitmap Resize( Bitmap image, float width = 84, float height = 48)
        {
            var brush = new SolidBrush(Color.White);

            float scale = Math.Min(width / image.Width, height / image.Height);

            var bmp = new Bitmap((int)width, (int)height);
            var graph = Graphics.FromImage(bmp);

            // uncomment for higher quality output
            graph.InterpolationMode = InterpolationMode.High;
            graph.CompositingQuality = CompositingQuality.HighQuality;
            graph.SmoothingMode = SmoothingMode.AntiAlias;

            var scaleWidth = (int)(image.Width * scale);
            var scaleHeight = (int)(image.Height * scale);

            graph.FillRectangle(brush, new RectangleF(0, 0, width, height));
            graph.DrawImage(image, new Rectangle(((int)width - scaleWidth) / 2, ((int)height - scaleHeight) / 2, scaleWidth, scaleHeight));

            return bmp;
        }
        

        public static byte[][] ConvertToByteArray(Bitmap slika)
        {
            byte[][] niz = new byte[84][];
            for(int i = 0; i < 84; i++)
            {
                niz[i] = new byte[6];
            }

            for (int i = 0; i < slika.Width; i++)
            {
                for (int j = 0; j < slika.Height; j++)
                {
                    var pixel = slika.GetPixel(i, j);

                    int byteIndex = j / 8;
                    int bitInByteIndex = j % 8;
                    byte mask = (byte)(1 << bitInByteIndex);

                    niz[i][byteIndex] = (byte)(pixel.R == 0 ? (niz[i][byteIndex] | mask) : (niz[i][byteIndex] & ~mask));

                }
            }

            return niz;
        }

        public static Bitmap ConvertToBitmap(byte [][] niz)
        {
            Bitmap slika = new Bitmap(84, 48);

            for(int i = 0; i < 84; i++)
            {
                for(int j = 0; j < 48; j++)
                {
                    var bajt = j / 8;
                    var bitNumber = j % 8;
                    var bit = (niz[i][bajt] >> bitNumber) & 1;

                    Color boja = bit == 1 ? Color.Black : Color.White;
                    slika.SetPixel(i, j, boja);
                }
            }

            return slika;
        }
    }
}
