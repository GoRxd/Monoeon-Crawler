using Microsoft.Xna.Framework;
using MonoeonCrawler.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MonoeonCrawler.Levels.TestLevel.Rooms
{
    public class TestRoom : Room
    {
        public TestRoom(Game1 _game) : base(_game)
        {
        }

        public override void Draw(GameTime gameTime)
        {
            DrawGameObjects();
        }

        public override void Load()
        {
            gameObjects.Add(new Table(Vector2.Zero, game.Content));
        }

        public override void Unload()
        {
            gameObjects.Clear();
        }

        public override void Update(GameTime gameTime)
        {
            
        }
    }
}
