using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using MonoeonCrawler.Characters;
using MonoeonCrawler.Levels.TestLevel;
using MonoeonCrawler.Levels;
using MonoeonCrawler.SceneSystem;
using MonoeonCrawler;
using System.Collections.Generic;
using System;
using MonoeonCrawler.Levels.TownLevel;

public class GameScene : IScene
{
    private Game1 _game;
    private Player player;

    private List<Level> levels;
    private Level currentLevel;

    private Matrix cameraMatrix;
    private Vector2 screenCenter;
    private Matrix scalingMatrix;
    private readonly Vector2 designedResolution = new Vector2(1920, 1080);

    public GameScene(Game1 game)
    {
        _game = game;

        // Calculate scaling based on screen size and designed resolution
        var viewportWidth = _game.GraphicsDevice.Viewport.Width;
        var viewportHeight = _game.GraphicsDevice.Viewport.Height;

        float scaleX = viewportWidth / designedResolution.X;
        float scaleY = viewportHeight / designedResolution.Y;
        float scale = Math.Min(scaleX, scaleY); // Maintain aspect ratio

        scalingMatrix = Matrix.CreateScale(scale);

        screenCenter = new Vector2(
            viewportWidth / 2f,
            viewportHeight / 2f
        );
    }

    public void Load()
    {
        player = new Player("Test Player", new Vector2(0, 0), new Mage(_game.Content));
        levels = new List<Level>();

        levels.Add(new TownLevel(_game, player));
        currentLevel = levels[0];
    }

    public void Unload()
    {
        // Clean up resources if needed
    }

    public void Update(GameTime gameTime)
    {
        float speed = 200f * (float)gameTime.ElapsedGameTime.TotalSeconds;
        KeyboardState keyboardState = Keyboard.GetState();
        Vector2 movement = Vector2.Zero;

        if (keyboardState.IsKeyDown(Keys.W)) movement.Y -= speed;
        if (keyboardState.IsKeyDown(Keys.S)) movement.Y += speed;
        if (keyboardState.IsKeyDown(Keys.A)) movement.X -= speed;
        if (keyboardState.IsKeyDown(Keys.D)) movement.X += speed;

        player.Move(movement);
        player.Character.UpdateAnimation(gameTime); // Update character animation

        // Update camera to center on the player, adjusting for player's dimensions
        var playerWidth = player.GetRectangle().Width;
        var playerHeight = player.GetRectangle().Height;

        cameraMatrix = Matrix.CreateTranslation(
            -player.Position.X + screenCenter.X - playerWidth / 2f,
            -player.Position.Y + screenCenter.Y - playerHeight / 2f,
            0f
        );

        currentLevel.Update(gameTime);
    }

    public void Draw(GameTime gameTime)
    {
        // Combine camera and scaling matrices
        var transformMatrix = cameraMatrix * scalingMatrix;

        _game.SpriteBatch.Begin(transformMatrix: transformMatrix);

        currentLevel.CurrentRoom.Draw(gameTime);
        player.Draw(_game.SpriteBatch);

        _game.SpriteBatch.End();
    }

}
