using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoeonCrawler.SceneSystem
{
    public class SceneManager
    {
        private Game1 _game;
        private IScene _currentScene;

        public SceneManager(Game1 game)
        {
            _game = game;
        }

        public void ChangeScene(IScene newScene)
        {
            _currentScene?.Unload();
            _currentScene = newScene;
            _currentScene?.Load();
        }

        public void Update(GameTime gameTime)
        {
            _currentScene?.Update(gameTime);
        }

        public void Draw(GameTime gameTime)
        {
            _currentScene?.Draw(gameTime);
        }
    }
}
