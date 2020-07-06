using System;

namespace AsteroidGame.UtilityClasses
{
    public delegate void GameEventHandler<T>(object sender, T e) where T : EventArgs;
}
