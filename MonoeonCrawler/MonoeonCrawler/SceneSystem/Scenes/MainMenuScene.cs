using Microsoft.Xna.Framework;
using MonoeonCrawler.SceneSystem;
using MonoeonCrawler;
using MonoGameGum.Forms.Controls;
using System.Diagnostics;
public class MainMenuScene : IScene
{
    private Game1 _game;
    private Button _startButton;
    private Button _exitButton;

    public MainMenuScene(Game1 game)
    {
        _game = game;
    }

    public void Load()
    {
        // Create the buttons with Gum
        _startButton = new Button
        {
            Text = "Start Game",
            X = 100,
            Y = 100,
            Width = 200,
            Height = 50
        };
        _startButton.Click += (_, _) => _game.SceneManager.ChangeScene(new GameScene(_game));

        _exitButton = new Button
        {
            Text = "Exit",
            X = 100,
            Y = 200,
            Width = 200,
            Height = 50
        };
        _exitButton.Click += (_, _) => _game.Exit();

        // Add the buttons to Gum using Visuals
        var root = _game.Root;
        root.Children.Add(_startButton.Visual);
        root.Children.Add(_exitButton.Visual);
    }

    public void Unload()
    {
        // Remove the buttons from Gum
        var root = _game.Root;
        root.Children.Remove(_startButton.Visual);
        root.Children.Remove(_exitButton.Visual);
    }

    public void Update(GameTime gameTime)
    {
        // Gum handles updating the UI components automatically
    }

    public void Draw(GameTime gameTime)
    {
        // Gum handles the drawing automatically
    }
}