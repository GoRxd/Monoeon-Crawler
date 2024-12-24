using MonoeonCrawler.Levels.TestLevel.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoeonCrawler.Levels.TestLevel
{
    public class TestLevel : Level
    {
        public TestLevel(Game1 game) : base(game)
        {
            rooms.Add(new TestRoom(game));
            ChangeRoom(rooms[0]);
        }
    }
}
