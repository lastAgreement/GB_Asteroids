using System;
using System.Drawing;

namespace AsteroidGame
{
    class Bullet: BaseObject
    {
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Size = new Size(10, 4);
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.FillRectangle(new SolidBrush(Color.GreenYellow), Pos.X - Size.Width/2, Pos.Y - Size.Height / 2, Size.Width, Size.Height);
            //Game.Buffer.Graphics.DrawRectangle(new Pen(Color.Red), ObjectFrame);
        }
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y + Dir.Y;
            if (Pos.X < 0) Dir.X = -Dir.X;
            if (Pos.X > Game.Width) Dir.X = -Dir.X;
            if (Pos.Y < 0) Dir.Y = -Dir.Y;
            if (Pos.Y > Game.Height) Dir.Y = -Dir.Y;
        }
        public override void ResetPos()
        {
            Pos = new Point(0, GlobalRandom.Next(0, Game.Height));
        }
        protected override void GetRandomValues()
        {
            int speed = GlobalRandom.Next(1, 15);
            Pos = new Point(0, GlobalRandom.Next(0, Game.Height));
            Dir = new Point(speed, 0);
            Size = new Size(10, 4);
        }
    }
}
