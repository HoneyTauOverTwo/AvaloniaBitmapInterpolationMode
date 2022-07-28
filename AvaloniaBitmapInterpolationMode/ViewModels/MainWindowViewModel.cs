using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvaloniaBitmapInterpolationMode.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        const int width = 20;
        const int height = 20;
        const int channels = 3;
        public MainWindowViewModel()
        {
            ImageDescription = $"{width}x{height} pixels";
            Random r = new("BitmapInterpolationMode".GetHashCode());
            byte[][,] bytes = new byte[channels][,];

            byte[,] v = new byte[width, height];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    v[i, j] = (byte)r.Next(byte.MaxValue + 1);
                }
            }

            for (int k = 0; k < channels; k++)
            {
                bytes[k] = v;
            }

            RenderTargetBmp = Imaging.ImageFactory.FromByteMatrix(bytes);
            WritableBmp = Imaging.ImageFactory.FromByteMatrixWritableBitmap(bytes);
        }

        public string ImageDescription { get; private set; }

        public RenderTargetBitmap RenderTargetBmp { get; private set; }
        public WriteableBitmap WritableBmp { get; private set; }
    }
}
