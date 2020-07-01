using System;
using System.Drawing;

namespace AsteroidGame
{
    interface ICollision
    {
        Rectangle ObjectFrame { get; }
        bool HaveCollision(ICollision obj);
    }
}
