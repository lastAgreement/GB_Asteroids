using System;
using System.Collections.Generic;
using System.Drawing;

namespace AsteroidGame
{
    class Star : BaseObject
    {
        protected Dictionary<int, RotateFlipType> rotateRandomizer = new Dictionary<int, RotateFlipType>();
        public Star() : base()
        {
            image = Image.FromFile("Images/star.png");
        }
        public Star(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            image = Image.FromFile("Images/star.png");
            Size.Width = dir.X;
            Size.Height = dir.X;
            InitRotateRandomizer();
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(image, Pos.X-Size.Width/2, Pos.Y-Size.Height / 2, Size.Width, Size.Height);
            //Game.Buffer.Graphics.DrawString(Pos.X + "; " + Pos.Y, new Font("Arial", 6), new SolidBrush(Color.White), Pos.X + 6, Pos.Y + 6);
        }
        public override void Update()
        {
            image.RotateFlip(rotateRandomizer[GlobalRandom.Next(1,4)]);
            Pos.X = Pos.X - Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
        }
        protected override void GetRandomValues()
        {
            int speed = GlobalRandom.Next(1, 15);
            Pos = new Point(GlobalRandom.Next(0, Game.Width), GlobalRandom.Next(0, Game.Height));
            Dir = new Point(speed, 0);
            Size = new Size(speed, speed);
            InitRotateRandomizer();
        }
        //TO DO
        //можно более красиво, я уверена
        void InitRotateRandomizer()
        {
            rotateRandomizer.Add(1, RotateFlipType.Rotate90FlipNone);
            rotateRandomizer.Add(2, RotateFlipType.Rotate180FlipNone);
            rotateRandomizer.Add(3, RotateFlipType.Rotate270FlipNone);
            rotateRandomizer.Add(4, RotateFlipType.RotateNoneFlipNone);
        }
    }
    
}
