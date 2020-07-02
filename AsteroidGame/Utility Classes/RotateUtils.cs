using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace AsteroidGame
{
    static class RotateUtils
    {
        static Dictionary<int, RotateFlipType> rotateRandomizer = new Dictionary<int, RotateFlipType>()
        {
            {1, RotateFlipType.Rotate90FlipNone},
            {2, RotateFlipType.Rotate180FlipNone},
            {3, RotateFlipType.Rotate270FlipNone},
            {4, RotateFlipType.RotateNoneFlipNone}
        };
        static RotateFlipType GetRandomRotateFlipType()
        {
            return rotateRandomizer[GlobalRandom.Next(1, 4)];
        }
        static public void RandomRotateFlipImage(Image image)
        {
            image.RotateFlip(GetRandomRotateFlipType());
        }
        static public Image RotateImage(Image image, float angle)
        {
            Bitmap bitmap = new Bitmap(image.Width, image.Height);
            bitmap.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            Graphics g = Graphics.FromImage(bitmap);
            g.TranslateTransform(image.Width/2, image.Height/2);
            g.RotateTransform(angle);
            g.TranslateTransform(-image.Width / 2, -image.Height / 2);
            g.DrawImage(image,0,0);
            return bitmap;
        }
        static public Image RandomRotateImage(Image image)
        {
            return RotateImage(image, GlobalRandom.Next(0, 360));
        }
    }
}
