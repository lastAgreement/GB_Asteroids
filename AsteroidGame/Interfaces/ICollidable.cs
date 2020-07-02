using System;
using System.Drawing;

namespace AsteroidGame
{
    interface ICollidable
    {
        Rectangle ObjectFrame { get; }
        bool HaveCollision(ICollidable obj);
    }
}
