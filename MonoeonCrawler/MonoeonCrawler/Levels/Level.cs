using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoeonCrawler.Levels
{
    public class Level
    {
        protected Room currentRoom;
        protected List<Room> rooms;
        protected Game1 game;

        public Level(Game1 _game)
        {
            game = _game;
            rooms = new();
        }

        public void ChangeRoom(Room room)
        {
            currentRoom?.Unload();
            currentRoom = room;
            currentRoom?.Load();
        }

        public void Update(GameTime gameTime)
        {
            currentRoom?.Update(gameTime);
        }

        public void Draw(GameTime gameTime)
        {
            currentRoom?.Draw(gameTime);
        }
    }
}
