using Microsoft.Xna.Framework;
using MonoeonCrawler.SceneSystem;
using MonoeonCrawler;
using MonoGameGum.Forms.Controls;
using Microsoft.Xna.Framework.Input;
using MonoeonCrawler.Characters;
using MonoeonCrawler.GameObjects;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using MonoeonCrawler.Levels;
using MonoeonCrawler.Levels.TestLevel;
public class GameScene : IScene
{
    private Game1 _game;
    private Player player;

    private List<Level> levels;
    private Level currentLevel;
    public GameScene(Game1 game)
    {
        _game = game;
    }

    public void Load()
    {
        player = new Player("Test Player", new Vector2(0, 0), new Mage(_game.Content));
        levels = [];

        levels.Add(new TestLevel(_game));
        currentLevel = levels[0];
    }

    public void Unload()
    {
        // Remove the buttons from Gum
        var root = _game.Root;

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
        currentLevel.Update(gameTime);
    }

    public void Draw(GameTime gameTime)
    {
        currentLevel.Draw(gameTime);

        player.Draw(_game.SpriteBatch);
    }

    
}