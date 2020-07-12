using System;
using System.Drawing;
using System.Windows.Forms;
using AsteroidGame.UtilityClasses;

namespace AsteroidGame
{
    class Ship : BaseObject
    {
        int maxSpeed = 10;
        int deltaSpeed = 5;
        int energy = 100;
        public int Energy => energy;
        public event EventHandler ShipDied;
        public event GameEventHandler<GameObjectEventArgs> ShipDamaged;
        public Ship() : base()
        {
            image = Image.FromFile("Images/ship1.png");
            Size = new Size(image.Width, image.Height);
        }
        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            image = Image.FromFile("Images/ship1.png");
            Size = new Size(image.Width, image.Height);
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(image, Pos.X - Size.Width / 2, Pos.Y - Size.Height / 2, Size.Width, Size.Height);
        }
        public override void Update()
        {
            if (Energy <= 0) ShipDied?.Invoke(this, new EventArgs());
            if (Pos.X + Dir.X > 0 && Pos.X + Dir.X < Game.Width) Pos.X += Dir.X;
            if (Pos.Y + Dir.Y > 0 && Pos.Y + Dir.Y < Game.Height) Pos.Y += Dir.Y;
        }
        protected override void GetRandomValues()
        {
            int speed = GlobalRandom.Next(3, 5);
            Pos = new Point(50, Game.Height/2);
            Dir = new Point(0, 0);
        }
        public void ChangeVelocity(Keys keyCode)
        {
            switch (keyCode)
            {
                case Keys.W:
                case Keys.Up:
                    if (Dir.Y - deltaSpeed >= -maxSpeed)
                        Dir.Y -= deltaSpeed;
                    break;
                case Keys.A:
                case Keys.Left:
                    if (Dir.X - deltaSpeed >= -maxSpeed)
                        Dir.X -= deltaSpeed;
                    break;
                case Keys.S:
                case Keys.Down:
                    if (Dir.Y + deltaSpeed <= maxSpeed)
                        Dir.Y += deltaSpeed;
                    break;
                case Keys.D:
                case Keys.Right:
                    if (Dir.X + deltaSpeed <= maxSpeed)
                        Dir.X += deltaSpeed;
                    break;
            }
        }
        public Bullet Fire()
        {
            Bullet bullet = new Bullet(Pos, new Point(15), new Size(0,0));
            return bullet;
        }
        public override bool HaveCollision(ICollidable obj)
        {
            bool haveCollision = base.HaveCollision(obj);
            if (haveCollision && obj is Asteroid)
            {
                Asteroid asteroid = (Asteroid)obj;
                EnergyLow(asteroid.Damage);
                ShipDamaged?.Invoke(this, new GameObjectEventArgs(GameObjectEventArgsType.SHIP_COLLIEDED_WITH_ASTEROID));
            }
            return haveCollision;
        }
        public void Battery_BatterySpent(object sender, GameObjectEventArgs e)
        {
            if (e.EventType == GameObjectEventArgsType.SHIP_COLLIEDED_WITH_BATTERY)
            {
                Battery battery = (Battery)sender;
                EnergyUp(battery.Energy);
            }
        }
        void EnergyUp(int energy)
        {
            this.energy += energy;
        }
        void EnergyLow(int energy)
        {
            this.energy -= energy;
        }
    }
}
