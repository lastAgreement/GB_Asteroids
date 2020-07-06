using System;
using System.Drawing;
using AsteroidGame.UtilityClasses;

namespace AsteroidGame
{
    class Battery : BaseObject
    {
        public int Energy { get; private set; }

        public event GameEventHandler<GameObjectEventArgs> BatterySpent;
        public Battery() : base()
        {
            image = Image.FromFile("Images/energizer.png");
            Energy = 50;
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(image, Pos.X - Size.Width / 2, Pos.Y - Size.Height / 2, image.Width/2, image.Height/2);
        }
        public override void Update()
        {
            Pos.X+=Dir.X;
            if (Pos.X < 0) OnBatterySpent(new GameObjectEventArgs(GameObjectEventArgsType.FLEW_AWAY));
        }
        protected override void GetRandomValues()
        {
            Pos = new Point(Game.Width + 50, GlobalRandom.Next(0, Game.Height));
            Dir = new Point(-5, 0);
            Size = new Size(0, 0);
        }
        protected virtual void OnBatterySpent(GameObjectEventArgs e)
        {
            BatterySpent?.Invoke(this, e);
        }
        public override bool HaveCollision(ICollidable obj)
        {
            bool haveCollision = base.HaveCollision(obj);
            if (haveCollision && obj is Ship) OnBatterySpent(new GameObjectEventArgs(GameObjectEventArgsType.SHIP_COLLIEDED_WITH_BATTERY));
            return haveCollision;
        }
    }
}
