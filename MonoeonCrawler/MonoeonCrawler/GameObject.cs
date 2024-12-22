
using Microsoft.Xna.Framework;

namespace MonoeonCrawler
{
    abstract public class GameObject
    {
        public string Name { get; private set; }
        public Vector2 Position { get; set; }

        public GameObject(string name) : this(name, Vector2.Zero) { }

        public GameObject(string name, Vector2 position)
        {
            Name = name;
            Position = position;
        }
    }

}
