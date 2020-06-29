using System;
using System.Drawing;

namespace AsteroidGame
{
    class BaseObject
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;
        protected Image image = Image.FromFile("Images/broken_image_M1.jpg"); 
        public BaseObject()
        {
            GetRandomValues();
        }
        public BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }
        public virtual void Draw()
        {
            Game.Buffer.Graphics.DrawImage(image, Pos.X- image.Width/2, Pos.Y- image.Height/2, image.Width, image.Height);
        }
        public virtual void Update()
        {
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y + Dir.Y;
            if (Pos.X < 0) Dir.X = -Dir.X;
            if (Pos.X > Game.Width) Dir.X = -Dir.X;
            if (Pos.Y < 0) Dir.Y = -Dir.Y;
            if (Pos.Y > Game.Height) Dir.Y = -Dir.Y;
        }
        protected virtual void GetRandomValues()
        {
            Pos = new Point(GlobalRandom.Next(0, Game.Width), GlobalRandom.Next(0, Game.Height));
            Dir = new Point(GlobalRandom.Next(1, 10), GlobalRandom.Next(1, 10));
            Size = new Size(GlobalRandom.Next(3, 10), GlobalRandom.Next(3, 10));
        }

    }
}
