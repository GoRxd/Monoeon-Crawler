using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoeonCrawler.Characters;
using MonoeonCrawler.GameObjects;
using MonoeonCrawler.SceneSystem;
using MonoGameGum.GueDeriving;
using RenderingLibrary;
using System.Collections.Generic;
using System.Diagnostics;

namespace MonoeonCrawler
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        public SpriteBatch SpriteBatch { get; private set; }

        public ContainerRuntime Root { get; private set; }
        public SceneManager SceneManager { get; private set; }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // Initialize the scene manager and start with the MainMenuScene
            var gumProject = MonoGameGum.GumService.Default.Initialize(
                this.GraphicsDevice);

            Root = new ContainerRuntime();
            Root.Width = 0;
            Root.Height = 0;
            Root.WidthUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
            Root.HeightUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
            Root.AddToManagers(SystemManagers.Default, null);
            SceneManager = new SceneManager(this);
            SceneManager.ChangeScene(new MainMenuScene(this));
            // Set the game to fullscreen
            _graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            _graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            //_graphics.IsFullScreen = true;
            _graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            MonoGameGum.GumService.Default.Update(this, gameTime, Root);
            SceneManager.Update(gameTime);


            base.Update(gameTime);
        }

        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //DrawGameObjects();

            //player.Draw(_spriteBatch);
            MonoGameGum.GumService.Default.Draw();
            SceneManager.Draw(gameTime);

            base.Draw(gameTime);
        }


    }
}
