using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoeonCrawler.GameObjects.Tiles
{
    public class BlankTile : Tile
    {
        public BlankTile(Vector2 position, ContentManager content) : base("Blank Tile", position)
        {
            texture = content.Load<Texture2D>("BlankTile");
            Type = ObjectType.Obstacle;
        }
    }
}
