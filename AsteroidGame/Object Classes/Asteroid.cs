using System;
using System.Drawing;

namespace AsteroidGame
{
    class Asteroid : BaseObject
    {
        public Asteroid() : base()
        {
            image = Image.FromFile("Images/Asteroid1.png");
        }
        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            image = Image.FromFile("Images/Asteroid1.png");
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(image, Pos.X - Size.Width / 2, Pos.Y - Size.Height / 2, Size.Width, Size.Height);
            //Game.Buffer.Graphics.DrawRectangle(new Pen(Color.Orange), ObjectFrame);
        }
        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            Pos.Y = Pos.Y + Dir.Y;
            if (Pos.X < 0) Dir.X = -Dir.X;
            if (Pos.X > Game.Width) Dir.X = -Dir.X;
            if (Pos.Y < 0) Dir.Y = -Dir.Y;
            if (Pos.Y > Game.Height) Dir.Y = -Dir.Y;
        }
        public override void ResetPos()
        {
            Pos = new Point(Game.Width, GlobalRandom.Next(0, Game.Height));
        }
        protected override void GetRandomValues()
        {
            Pos = new Point(Game.Width, GlobalRandom.Next(0, Game.Height));
            Dir = new Point(GlobalRandom.Next(5, 10), GlobalRandom.Next(5, 10));
            int speed = (int)Math.Floor(Math.Sqrt(Math.Pow(Dir.X,2) + Math.Pow(Dir.Y,2)));
            Size = new Size(speed * 10, speed * 10);
        }
    }
}
