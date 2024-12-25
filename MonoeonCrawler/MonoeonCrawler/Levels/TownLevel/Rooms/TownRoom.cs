using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoeonCrawler.GameObjects;
using MonoeonCrawler.GameObjects.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MonoeonCrawler.Levels.TestLevel.Rooms
{
    public class TownRoom : Room
    {
        protected Player player;

        public TownRoom(Game1 _game, Player player) : base(_game)
        {
            game = _game;
            this.player = player;
        }

        public override void Draw(GameTime gameTime)
        {
            // Draw floor tiles first
            foreach (var tile in floorTiles)
            {
                tile.Draw(game.SpriteBatch);
            }

            // Then draw regular game objects
            DrawGameObjects();
        }

        public override void Load()
        {
            // Example: Adding floor tiles (adjust positions as needed)
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    //floorTiles.Add(new Tile($"Tile_{x}_{y}", new Vector2(x * 32, y * 32)));
                }
            }

            // Add other game objects
            gameObjects.Add(player);
            gameObjects.Add(new Table(new Vector2(300, 200), game.Content));
        }

        public override void Unload()
        {
            gameObjects.Clear();
            floorTiles.Clear();
        }

        public override void Update(GameTime gameTime)
        {
            HandleCollisions();

            // Update floor tiles (if necessary)
            foreach (var tile in floorTiles)
            {
                tile.OnCollision(null); // Dummy collision call if tiles need to handle updates
            }
        }
    }

    
}
