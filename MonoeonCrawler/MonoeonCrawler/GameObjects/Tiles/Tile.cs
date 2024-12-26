using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace MonoeonCrawler.GameObjects.Tiles
{
    // Updated Tile class inheriting from GameObject
    public class Tile : GameObject
    {
        protected Texture2D texture;
        public static readonly Vector2 Size = new Vector2(180, 180);
        public Tile(string name, Vector2 position) : base(name, position)
        {
            Type = ObjectType.Tile;
        }

        public override Rectangle GetRectangle()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, texture.Width, texture.Height);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, GetRectangle(), Color.White);
        }

        public override void OnCollision(GameObject objectB)
        {
            base.OnCollision(objectB);
        }
    }
}
