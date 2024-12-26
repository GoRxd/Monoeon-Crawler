
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoeonCrawler.Characters;
using System;
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

        public Rectangle GetAnimRectangle()
        { 
            double frameWidth = Character.GetFrameWidth();
            double characterWidth = Character.GetCharacterWidth();
            double gap = (frameWidth - characterWidth) / 2;
            Texture2D characterTexture = Character.GetCurrentTexture();

            return new Rectangle((int)(frameWidth * Character.CurrentFrame) + (int)gap, 0, (int)characterWidth, characterTexture.Height);
        }
        public override Rectangle GetRectangle()
        {
            double characterWidth = Character.GetCharacterWidth();
            Texture2D characterTexture = Character.GetCurrentTexture();

            return new Rectangle((int)Position.X, (int)Position.Y, (int)characterWidth, characterTexture.Height);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            // Ensure the frame is flipped horizontally if the character is facing left
            SpriteEffects spriteEffect = FacingRight ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            Texture2D characterTexture = Character.GetCurrentTexture();

            spriteBatch.Draw(
                characterTexture,
                new Vector2(Position.X, Position.Y), // Maintain consistent Y position
                GetAnimRectangle(),
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
            if (objectB.Type == ObjectType.Obstacle)
            {
                //Debug.WriteLine("Collision Detected with: " + objectB.Name);

                Rectangle playerRect = GetRectangle();
                Rectangle obstacleRect = objectB.GetRectangle();

                Vector2 overlap = Vector2.Zero;

                // Calculate the overlap amount in X and Y directions
                if (playerRect.Right > obstacleRect.Left && playerRect.Left < obstacleRect.Right)
                {
                    // Determine the direction of overlap in X
                    float rightOverlap = playerRect.Right - obstacleRect.Left;
                    float leftOverlap = obstacleRect.Right - playerRect.Left;

                    overlap.X = rightOverlap < leftOverlap ? rightOverlap : -leftOverlap;
                }

                if (playerRect.Bottom > obstacleRect.Top && playerRect.Top < obstacleRect.Bottom)
                {
                    // Determine the direction of overlap in Y
                    float bottomOverlap = playerRect.Bottom - obstacleRect.Top;
                    float topOverlap = obstacleRect.Bottom - playerRect.Top;

                    overlap.Y = bottomOverlap < topOverlap ? bottomOverlap : -topOverlap;
                }

                // Adjust position based on the smallest overlap
                if (Math.Abs(overlap.X) < Math.Abs(overlap.Y))
                {
                    Position = new Vector2(Position.X - overlap.X, Position.Y);
                }
                else
                {
                    Position = new Vector2(Position.X, Position.Y - overlap.Y);
                }
            }
            else
            {
                // Default behavior for non-obstacle collisions
                base.OnCollision(objectB);
            }
        }


    }

}
