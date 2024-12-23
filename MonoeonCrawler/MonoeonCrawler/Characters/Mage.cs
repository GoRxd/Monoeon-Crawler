using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoeonCrawler.Characters
{
    public class Mage : Character
    {
        public Mage(ContentManager content)
            : base("Mage", "", maxHealth:100, physicalDamage: 0, magicDamage: 20, maxMana: 100, content)
        {

        }

        public override void LevelUp()
        {
            base.LevelUp();
            MaxMana += (int)(5 + Level * 1.5); // Mana increases more as level rises.
            MagicDamage += (int)(2 + Level * 0.5); // Magic damage scales with level.
            MaxHealth += (int)(3 + Level * 0.3); // Health increases modestly.
            Health = MaxHealth;
            Mana = MaxMana;
        }
    }
}
