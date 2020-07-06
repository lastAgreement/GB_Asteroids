using System;
using System.Collections.Generic;
using System.Drawing;
using AsteroidGame.UtilityClasses;

namespace AsteroidGame
{
    class Star : BaseObject
    {
        public Star() : base()
        {
            image = Image.FromFile("Images/star.png");
        }
        public Star(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            image = Image.FromFile("Images/star.png");
            Size.Width = dir.X;
            Size.Height = dir.X;
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(image, Pos.X-Size.Width/2, Pos.Y-Size.Height / 2, Size.Width, Size.Height);
            //Game.Buffer.Graphics.DrawString(Pos.X + "; " + Pos.Y, new Font("Arial", 6), new SolidBrush(Color.White), Pos.X + 6, Pos.Y + 6);
        }
        public override void Update()
        {
            RotateUtils.RandomRotateFlipImage(image);
            Pos.X = Pos.X - Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
        }
        protected override void GetRandomValues()
        {
            int speed = GlobalRandom.Next(1, 8);
            Pos = new Point(GlobalRandom.Next(0, Game.Width), GlobalRandom.Next(0, Game.Height));
            Dir = new Point(speed, 0);
            Size = new Size(speed, speed);
        }
    }
    
}
