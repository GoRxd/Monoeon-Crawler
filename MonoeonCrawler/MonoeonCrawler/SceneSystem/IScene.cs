using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoeonCrawler.SceneSystem
{
    public interface IScene
    {
        public void Load();
        public void Unload();
        public void Update(GameTime gameTime);
        public void Draw(GameTime gameTime);
    }
}
