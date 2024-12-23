
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;

namespace MonoeonCrawler
{
    abstract public class GameObject
    {
        public string Name { get; private set; }
        public Vector2 Position { get; set; }

        public ObjectType Type { get; private set; }

        public GameObject(string name) : this(name, Vector2.Zero) { }

        public GameObject(string name, Vector2 position)
        {
            Name = name;
            Position = position;
        }

        public abstract Rectangle GetRectangle();

        public abstract void Draw(SpriteBatch spriteBatch);

        public virtual void OnCollision(GameObject objectB)
        {
            Debug.WriteLine($"{Name} object has not implemented OnCollision.");
        }
    }

}
