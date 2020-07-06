using System;
using System.Drawing;
using AsteroidGame.UtilityClasses;

namespace AsteroidGame
{
    class Asteroid : BaseObject
    {
        public int Damage { get; private set; }
        public Asteroid() : base()
        {
            image = Image.FromFile("Images/Asteroid1.png");
            image = RotateUtils.RandomRotateImage(image);
        }
        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            image = Image.FromFile("Images/Asteroid1.png");
            image = RotateUtils.RandomRotateImage(image);
            Damage = 5 * (int)Math.Floor(Math.Sqrt(Math.Pow(Dir.X, 2) + Math.Pow(Dir.Y, 2)));
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
            if (Pos.X < -Size.Width / 2 || Pos.Y < -Size.Height/2 || Pos.Y > Game.Height + Size.Height / 2) ResetPos();
        }
        public override void ResetPos()
        {
            Pos = new Point(Game.Width + GlobalRandom.Next(100, 300), GlobalRandom.Next(0, Game.Height));
        }
        protected override void GetRandomValues()
        {
            ResetPos();
            Dir = new Point(GlobalRandom.Next(3, 7), GlobalRandom.Next(-3, 3));
            int speed = (int)Math.Floor(Math.Sqrt(Math.Pow(Dir.X,2) + Math.Pow(Dir.Y,2)));
            Size = new Size(speed * 20, speed * 20);
            Damage = 5 * speed;
        }
    }
}
