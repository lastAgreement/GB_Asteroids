using System;
using System.Drawing;
using AsteroidGame.UtilityClasses;

namespace AsteroidGame
{
    class Bullet: BaseObject
    {
        public event GameEventHandler<GameObjectEventArgs> BulletSpent;
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
            if (Pos.X < 0 || Pos.X > Game.Width || Pos.Y < 0 || Pos.Y > Game.Height) OnBulletSpent(new GameObjectEventArgs(GameObjectEventArgsType.FLEW_AWAY));
        }
        public override bool HaveCollision(ICollidable obj)
        {
            bool haveCollision = base.HaveCollision(obj);
            if (haveCollision && obj is Asteroid) OnBulletSpent(new GameObjectEventArgs(GameObjectEventArgsType.BULLET_COLLIEDED_WITH_ASTEROID));
            return haveCollision;
        }
        protected override void GetRandomValues()
        {
            int speed = GlobalRandom.Next(1, 15);
            Pos = new Point(0, GlobalRandom.Next(0, Game.Height));
            Dir = new Point(speed, 0);
            Size = new Size(10, 4);
        }
        protected virtual void OnBulletSpent(GameObjectEventArgs e)
        {
            BulletSpent?.Invoke(this, e);
        }
    }
}
