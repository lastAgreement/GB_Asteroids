using System;
using System.Drawing;

namespace AsteroidGame
{
    abstract class BaseObject: ICollidable
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;
        protected Image image; // = Image.FromFile("Images/broken_image_M1.jpg");
        public Rectangle ObjectFrame => new Rectangle(Pos.X - Size.Width/2, Pos.Y - Size.Height / 2, Size.Width, Size.Height);
        #region Constructor
        public BaseObject()
        {
            GetRandomValues();
        }
        public BaseObject(Point pos, Point dir, Size size)
        {
            if (pos.X < 0 || pos.Y < 0 || pos.X > 2 * Game.Width || pos.Y > 2 * Game.Height)
                throw new GameObjectException("Object position is out of range.");
            if (Math.Abs(dir.X) > 30 || Math.Abs(dir.Y) > 30)
                throw new GameObjectException("Object speed is too high.");
            if (size.Width < 0 || size.Height < 0)
                throw new GameObjectException("Object size is too small.");

            Pos = pos;
            Dir = dir;
            Size = size;
        }
        #endregion
        #region Public Methods
        public abstract void Draw();
        public abstract void Update();
        public bool HaveCollision(ICollidable obj)
        {
            return this.ObjectFrame.IntersectsWith(obj.ObjectFrame);
        }
        public virtual void ResetPos()
        {
            Pos = new Point(GlobalRandom.Next(0, Game.Width), GlobalRandom.Next(0, Game.Height));
        }
        #endregion
        #region Protected Methods
        protected virtual void GetRandomValues()
        {
            Pos = new Point(GlobalRandom.Next(0, Game.Width), GlobalRandom.Next(0, Game.Height));
            Dir = new Point(GlobalRandom.Next(1, 10), GlobalRandom.Next(1, 10));
            Size = new Size(GlobalRandom.Next(3, 10), GlobalRandom.Next(3, 10));
        }
        #endregion
    }
}
