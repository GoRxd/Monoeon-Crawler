using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoeonCrawler.Characters;
using MonoeonCrawler.GameObjects;
using System.Collections.Generic;

namespace MonoeonCrawler
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Player player;
        private List<GameObject> gameObjects;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            gameObjects = new();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            player = new Player("Test Player", new Vector2(0, 0), new Mage(Content));
            gameObjects.Add(new Table(Vector2.Zero, Content));
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

        private void DrawGameObjects()
        {
            foreach (var gameObject in gameObjects)
            {
                gameObject.Draw(_spriteBatch);
            }
        }

        private void HandleCollisions()
        {
            foreach (var objectA in gameObjects)
            {
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
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            DrawGameObjects();

            player.Draw(_spriteBatch);
 
            _spriteBatch.End();

            base.Draw(gameTime);
        }


    }
}
