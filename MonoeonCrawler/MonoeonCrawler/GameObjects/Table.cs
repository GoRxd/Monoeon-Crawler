using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MonoeonCrawler.GameObjects
{
    public class Table : GameObject
    {
        public Texture2D Texture { get; private set; }
        //TODO: something like private List<GameObject> lyingItems;

        public Table(Vector2 position, ContentManager content) : base("Table", position)
        {
            Texture = content.Load<Texture2D>("table");
            Type = ObjectType.Obstacle;
        }

        public Table(string name, ContentManager content) : base(name)
        {
            Texture = content.Load<Texture2D>("table");
            Type = ObjectType.Obstacle;
        }

        public override Rectangle GetRectangle()
        {
            return new Rectangle(
                (int)Position.X,
                (int)Position.Y,
                Texture.Width,
                Texture.Height
            );
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, null, Color.White);
        }
        public override void OnCollision(GameObject objectB)
        {
            base.OnCollision(objectB);
        }
    }
}
