using System;

namespace AsteroidGame.UtilityClasses
{
    public class GameObjectEventArgs : EventArgs
    {
        public GameObjectEventArgsType EventType { get; private set; }
        public GameObjectEventArgs(GameObjectEventArgsType type)
        {
            EventType = type;
        }
    }
    public enum GameObjectEventArgsType
    {
        FLEW_AWAY,
        SHIP_COLLIEDED_WITH_BATTERY,
        BULLET_COLLIEDED_WITH_ASTEROID,
        SHIP_COLLIEDED_WITH_ASTEROID
    }
}
