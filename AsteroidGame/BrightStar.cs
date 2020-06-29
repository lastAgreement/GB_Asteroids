using System;
using System.Drawing;

namespace AsteroidGame
{
    enum StarBStatus
    {
        GROWTH,
        RECESSION
    }
    class BrightStar : Star
    {
        StarBStatus status;
        public BrightStar() : base()
        {
            image = Image.FromFile("Images/Bright.png");
        }
        public BrightStar(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            image = Image.FromFile("Images/Bright.jpg");
            if (dir.X < 0) status = StarBStatus.RECESSION;
            else status = StarBStatus.GROWTH;
            Dir.X = Math.Abs(dir.X);
        }
        public override void Update()
        {
            Pos.X--;
            if (Pos.X < 0) Pos.X = Game.Width + Size.Width + GlobalRandom.Next(50, 100);

            if (status == StarBStatus.GROWTH)
            {
                if (Size.Width < 50)
                {
                    Size.Width += Dir.X;
                    Size.Height += Dir.X;
                }
                else
                {
                    Size.Width -= Dir.X;
                    Size.Height -= Dir.X;
                    status = StarBStatus.RECESSION;
                }
            }
            else
            {
                if (Size.Width > 20)
                {
                    Size.Width -= Dir.X;
                    Size.Height -= Dir.X;
                }
                else
                {
                    Size.Width += Dir.X;
                    Size.Height += Dir.X;
                    status = StarBStatus.GROWTH;
                }
            }
        }
        protected override void GetRandomValues()
        {
            int size = GlobalRandom.Next(20, 50);
            Pos = new Point(GlobalRandom.Next(0, Game.Width), GlobalRandom.Next(0, Game.Height/20)*20);
            Dir = new Point(GlobalRandom.Next(-3, 3), 0);
            Size = new Size(size, size);

            if (Dir.X < 0) status = StarBStatus.RECESSION;
            else status = StarBStatus.GROWTH;
            Dir.X = Math.Abs(Dir.X);
        }
    }
}
