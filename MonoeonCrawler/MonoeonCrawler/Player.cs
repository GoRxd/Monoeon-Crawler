
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoeonCrawler.Characters;
using System.Diagnostics;
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

        public override Rectangle GetRectangle()
        { 
            double frameWidth = Character.GetFrameWidth();
            double characterWidth = Character.GetCharacterWidth();
            double gap = (frameWidth - characterWidth) / 2;
            Texture2D characterTexture = Character.GetCurrentTexture();

            return new Rectangle((int)(frameWidth * Character.CurrentFrame) + (int)gap, 0, (int)characterWidth, characterTexture.Height);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            // Ensure the frame is flipped horizontally if the character is facing left
            SpriteEffects spriteEffect = FacingRight ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            Texture2D characterTexture = Character.GetCurrentTexture();
            Debug.WriteLine(characterTexture);

            spriteBatch.Draw(
                characterTexture,
                new Vector2(Position.X, Position.Y), // Maintain consistent Y position
                GetRectangle(),
                Color.White,
                0f,
                Vector2.Zero,
                1f,
                spriteEffect,
                0f
            );
        }
        public override void OnCollision(GameObject objectB)
        {
            base.OnCollision(objectB);
        }
    }

}
