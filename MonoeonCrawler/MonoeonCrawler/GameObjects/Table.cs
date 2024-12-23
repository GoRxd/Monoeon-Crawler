using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
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
        }

        public override Rectangle GetRectangle()
        {
            return Texture.Bounds;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, null, Color.White);
        }
    }
}
