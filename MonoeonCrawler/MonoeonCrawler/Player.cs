
using Microsoft.Xna.Framework;
using MonoeonCrawler.Characters;

namespace MonoeonCrawler
{
    public class Player : GameObject
    {
        public Character Character { get; private set; }
        public bool FacingRight { get; private set; } = true;

        public Player(string name, Vector2 position, Character character) : base(name, position)
        {
            Character = character;
        }

        public void Move(Vector2 direction)
        {
            Position += direction;

            if (direction != Vector2.Zero)
            {
                Character.SetWalking(true);
                FacingRight = direction.X >= 0;
            }
            else
            {
                Character.SetWalking(false);
            }
        }
    }

}
