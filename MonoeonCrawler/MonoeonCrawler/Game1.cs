using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoeonCrawler.Characters;

namespace MonoeonCrawler
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Player player;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            player = new Player("Test Player", new Vector2(0, 0), new Mage(Content));
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            float speed = 200f * (float)gameTime.ElapsedGameTime.TotalSeconds;
            KeyboardState keyboardState = Keyboard.GetState();
            Vector2 movement = Vector2.Zero;

            if (keyboardState.IsKeyDown(Keys.W)) movement.Y -= speed;
            if (keyboardState.IsKeyDown(Keys.S)) movement.Y += speed;
            if (keyboardState.IsKeyDown(Keys.A)) movement.X -= speed;
            if (keyboardState.IsKeyDown(Keys.D)) movement.X += speed;

            player.Move(movement);
            player.Character.UpdateAnimation(gameTime); // Update character animation

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            Texture2D tableTexture = Content.Load<Texture2D>("table");
            _spriteBatch.Draw(tableTexture, new Rectangle(0, 0, tableTexture.Width, tableTexture.Height), Color.White);

            // Get the current frame of the character's animation
            Texture2D currentFrame = player.Character.GetCurrentFrame();

            // Calculate the vertical alignment offset
            // Align the frames to a fixed Y position (e.g., the character's feet or base level)
            float yOffset = player.Position.Y + (currentFrame.Height - currentFrame.Height); // Adjust based on frame height

            // Ensure the frame is flipped horizontally if the character is facing left
            SpriteEffects spriteEffect = player.FacingRight ? SpriteEffects.None : SpriteEffects.FlipHorizontally;

            // Draw the character frame at the correct position, adjusting for any size differences
            _spriteBatch.Draw(
                currentFrame,
                new Vector2(player.Position.X, yOffset), // Maintain consistent Y position
                null, // No need for a source rectangle
                Color.White,
                0f,
                Vector2.Zero,
                1f,
                spriteEffect,
                0f
            );

            _spriteBatch.End();

            base.Draw(gameTime);
        }


    }
}
