
using Microsoft.Xna.Framework;
using MonoeonCrawler.Characters;

namespace MonoeonCrawler
{
    public class Player : GameObject
    {
        public Character Character { get; private set; }
        public Player(string name, Vector2 position, Character character) : base(name, position)
        {
            Character = character;
        }
    }
}
