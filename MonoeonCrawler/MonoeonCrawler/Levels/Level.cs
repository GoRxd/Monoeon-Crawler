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
        public Room CurrentRoom { get; protected set; }
        protected List<Room> rooms;
        protected Game1 game;
        protected Player player;

        public Level(Game1 _game, Player player)
        {
            game = _game;
            this.player = player;
            rooms = new();
        }

        public void ChangeRoom(Room room)
        {
            CurrentRoom?.Unload();
            CurrentRoom = room;
            CurrentRoom?.Load();
        }

        public virtual void Update(GameTime gameTime)
        {
            CurrentRoom?.Update(gameTime);
        }
    }
}
