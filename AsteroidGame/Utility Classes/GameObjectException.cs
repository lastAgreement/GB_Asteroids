using System;

namespace AsteroidGame.UtilityClasses
{
    class GameObjectException:Exception
    {
        public GameObjectException(string message): base(message) {}
    }
}
