using System;
using System.Drawing;

namespace AsteroidGame
{
    class Comet:BaseObject
    {
        public Comet() : base()
        {
            image = Image.FromFile("Images/comet1.png");
        }
        public Comet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            image = Image.FromFile("Images/comet1.png");
            Dir.Y = Dir.X / 2;
            Size = new Size(dir.X * 10, dir.X * 10);
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(image, Pos.X - Size.Width / 2, Pos.Y - Size.Height / 2, Size.Width, Size.Height);
        }
        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            Pos.Y = Pos.Y + Dir.Y;
            if (Pos.X < - Size.Width / 2 || Pos.Y > Game.Height + Size.Height / 2)
            {
                GetRandomValues();
            }
        }
        protected override void GetRandomValues()
        {
            int speed = random.Next(5, 10);
            Pos = new Point(random.Next(Game.Width + 100, Game.Width + 500), random.Next(-500, -50));
            Dir = new Point(speed, speed / 2);
            Size = new Size(speed * 10, speed * 10);
        }
    }
}
