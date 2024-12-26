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
            this.player = player;

            // Define a 2D array of tile IDs for this room
            floorTileIDs = new List<List<int>>
            {
                new() { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                new() { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                new() { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                new() { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                new() { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                new() { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                new() { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                new() { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                new() { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                new() { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                new() { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                new() { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                new() { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                new() { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                new() { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                new() { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                new() { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                new() { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                new() { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                new() { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                new() { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,1, 1, 1, 1, 1, 1, 1, 1, 1, 1},

 
            };
        }

        public override void Draw(GameTime gameTime)
        {
            DrawTiles();

            // Then draw regular game objects
            DrawGameObjects();
        }

        public override void Load()
        {
            // Load floor tiles with a starting position and tile size
            LoadFloorTiles(Vector2.Zero); // Start position and tile dimensions

            PlaceGameObjectOnTile(player, 0, 0);
            Table testTable = new Table("Test table", game.Content);
            int tableRow = floorTileIDs.Count - 1;
            int tableCol = floorTileIDs[tableRow].Count - 1;
            PlaceGameObjectOnTile(testTable, tableRow, tableCol);
        }

        public override void Unload()
        {
            gameObjects.Clear();
            floorTiles.Clear();
        }

        public override void Update(GameTime gameTime)
        {
            HandleCollisions();

        }
    }

    
}
