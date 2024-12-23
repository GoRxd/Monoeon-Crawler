using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MonoeonCrawler.Characters
{
    public class Knight : Character
    {
        public Knight(ContentManager content)
            : base(name: "Knight", description: "", maxHealth: 150, physicalDamage: 10, magicDamage: 0, maxMana: 50, content)
        {

        }

        public override void LevelUp()
        {
            base.LevelUp();
            MaxHealth += (int)(10 + Level * 2); // Health scales heavily with level.
            PhysicalDamage += (int)(3 + Level * 0.8); // Physical damage scales with level.
            Health = MaxHealth;
        }
    }
}
