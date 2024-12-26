using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoeonCrawler.GameObjects;
using MonoeonCrawler.GameObjects.Tiles;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Metadata;

namespace MonoeonCrawler.Levels
{
    public abstract class Room
    {
        abstract public void Load();
        abstract public void Unload();
        abstract public void Update(GameTime gameTime);
        abstract public void Draw(GameTime gameTime);

        protected List<GameObject> gameObjects;
        protected List<GameObject> floorTiles;

        // 2D list of tile IDs for rows and columns of tiles
        protected List<List<int>> floorTileIDs;
        protected static Dictionary<int, Func<Vector2, ContentManager, Tile>> tileFactory; // Tile factory for ID-to-tile mapping

        protected Game1 game;

        protected List<Door> doors;

        protected Vector2 tilesStartPosition;

        public Room(Game1 _game)
        {
            gameObjects = new List<GameObject>();
            floorTiles = new List<GameObject>();
            floorTileIDs = new List<List<int>>(); // Initialize the 2D list
            doors = new List<Door>();
            game = _game;

            // Initialize the tile factory (shared for all rooms)
            tileFactory = new Dictionary<int, Func<Vector2, ContentManager, Tile>>
            {
                { 0, (position, content) => new BlankTile(position, content) },
                { 1, (position, content) => new GrassTile(position, content) }
                // Add more tile mappings here
            };
        }

        public void LoadFloorTiles(Vector2 startPosition)
        {
            floorTiles.Clear(); // Clear existing tiles

            tilesStartPosition = new(startPosition.X, startPosition.Y);

            for (int row = 0; row < floorTileIDs.Count; row++)
            {
                for (int col = 0; col < floorTileIDs[row].Count; col++)
                {
                    int tileID = floorTileIDs[row][col];
                    if (tileFactory.TryGetValue(tileID, out var createTile))
                    {
                        // Create tile and add to floorTiles
                        floorTiles.Add(createTile(startPosition, game.Content));
                    }
                    else if (tileID != 0)
                    {
                        // Handle invalid tile IDs (0 is treated as "no tile")
                        throw new Exception($"No tile defined for ID {tileID}");
                    }

                    // Move to the next column
                    startPosition.X += Tile.Size.X;
                }

                // Move to the next row and reset column position
                startPosition.X = tilesStartPosition.X;
                startPosition.Y += Tile.Size.Y;
            }
        }

        public void PlaceGameObjectOnTile(GameObject gameObject, int row, int col)
        {
            // Validate the row and column indices
            if (row < 0 || row >= floorTileIDs.Count || col < 0 || col >= floorTileIDs[row].Count)
            {
                throw new ArgumentOutOfRangeException("Row or column index is out of range.");
            }
            Debug.WriteLine($"{row}, {col}");
            // Calculate the tile's position
            Vector2 tilePosition = tilesStartPosition + new Vector2(col * Tile.Size.X, row * Tile.Size.Y);
            Debug.WriteLine($"{tilePosition.X}, {tilePosition.Y}");

            // Center the game object on the tile
            Vector2 centeredPosition = tilePosition + (Tile.Size / 2) - (gameObject.GetRectangle().Size.ToVector2() / 2);

            // Set the position of the game object
            gameObject.Position = centeredPosition;

            // Add the game object to the room's list
            gameObjects.Add(gameObject);
        }

        protected void DrawTiles()
        {
            foreach(var tile in floorTiles)
            {
                if (tile is BlankTile)
                    continue;
                else
                {
                    tile.Draw(game.SpriteBatch);
                }
            }
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
                foreach (var tile in floorTiles)
                { 
                    if (objectA.GetRectangle().Intersects(tile.GetRectangle()))
                    {
                        objectA.OnCollision(tile);
                    }
                }
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
