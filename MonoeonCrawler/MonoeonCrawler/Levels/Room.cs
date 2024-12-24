using Microsoft.Xna.Framework;
using MonoeonCrawler.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MonoeonCrawler.Levels
{
    abstract public class Room
    {
        abstract public void Load();
        abstract public void Unload();
        abstract public void Update(GameTime gameTime);
        abstract public void Draw(GameTime gameTime);

        protected List<GameObject> gameObjects;

        protected Game1 game;

        protected List<Door> doors;

        public Room(Game1 _game)
        {
            gameObjects = new();
            game = _game;
            doors = new();
        }

        protected void DrawGameObjects()
        {
            foreach (var gameObject in gameObjects)
            {
                gameObject.Draw(game.SpriteBatch);
            }
        }

        protected void HandleCollisions()
        {
            foreach (var objectA in gameObjects)
            {
                foreach (var objectB in gameObjects)
                {
                    if (objectA != objectB)
                    {
                        if (objectA.GetRectangle().Intersects(objectB.GetRectangle()))
                        {
                            objectA.OnCollision(objectB);
                        }
                    }
                }
            }
        }
    }
}
