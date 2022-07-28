using Avalonia;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Media.Immutable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaBitmapInterpolationMode.Imaging
{
    public class ImageFactory
    {
        const int DPI = 96;

        public static RenderTargetBitmap FromByteMatrix(byte[][,] bytes)
        {
            int width = bytes[0].GetLength(0);
            int height = bytes[0].GetLength(1);
            RenderTargetBitmap bmp = new(new PixelSize(width, height), new Vector(DPI, DPI));

            using (var dci = bmp.CreateDrawingContext(null))
            using (var dc = new DrawingContext(dci, false))
            //using (dc.PushPostTransform(Matrix.CreateScale(1, 1)))
            {
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        IBrush b = new ImmutableSolidColorBrush(Color.FromArgb(255,
                            bytes[0][i, j],
                            bytes[1][i, j],
                            bytes[2][i, j]));

                        Rect rect = new(i, j, 1, 1);

                        dc.DrawRectangle(b, null, rect);
                    }
                }
            }
            return bmp;
        }

        public static WriteableBitmap FromByteMatrixWritableBitmap(byte[][,] bytes)
        {
            int width = bytes[0].GetLength(0);
            int height = bytes[0].GetLength(1);
            WriteableBitmap bmp = new WriteableBitmap(new PixelSize(width, height), new Vector(DPI, DPI));
            using (bmp.GetBitmapContext())
            {
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        bmp.SetPixel(i, j, Color.FromArgb(255,
                            bytes[0][i, j],
                            bytes[1][i, j],
                            bytes[2][i, j]));
                    }
                }
            }
            return bmp;
        }
    }
}
