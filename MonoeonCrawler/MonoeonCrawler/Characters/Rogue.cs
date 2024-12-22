using MonoeonCrawler.Characters;
using MonoeonCrawler;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
public class Rogue : Character
{
    public Rogue(ContentManager content)
        : base(name: "Rogue", description: "", maxHealth: 80, physicalDamage: 30, magicDamage: 10, maxMana: 75, content)
    {
        Texture = content.Load<Texture2D>("Heroes/Rogue/Idle/rogue-idle0.png");
    }

    public override void LevelUp()
    {
        base.LevelUp();
        MaxHealth += (int)(5 + Level * 1.2); // Moderate health scaling.
        PhysicalDamage += (int)(2 + Level * 0.7); // Physical damage scales modestly.
        MaxMana += (int)(3 + Level * 1.1); // Mana scales for hybrid abilities.
        Health = MaxHealth;
        Mana = MaxMana;
    }
}