using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoeonCrawler.Levels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoeonCrawler.GameObjects
{
    public class Door : GameObject
    {
        public Texture2D Texture { get; private set; }
        public Room DestinationRoom {get; private set;}
        public Door(string name, Vector2 position, Room destination) : base(name, position)
        {
            DestinationRoom = destination;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public override Rectangle GetRectangle()
        {
            return Texture.Bounds;
        }
        public override void OnCollision(GameObject objectB)
        {
            base.OnCollision(objectB);
        }
    }
}
