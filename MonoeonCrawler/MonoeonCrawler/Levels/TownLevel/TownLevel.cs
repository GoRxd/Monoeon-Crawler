using Microsoft.Xna.Framework;
using MonoeonCrawler.Levels.TestLevel.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoeonCrawler.Levels.TownLevel
{
    public class TownLevel : Level
    {
        public TownLevel(Game1 game, Player player) : base(game, player)
        {
            rooms.Add(new TownRoom(game, player));
            ChangeRoom(rooms[0]);
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
