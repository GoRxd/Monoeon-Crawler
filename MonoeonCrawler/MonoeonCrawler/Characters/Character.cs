using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoeonCrawler.Abilities;
using System;
using System.Collections.Generic;

namespace MonoeonCrawler.Characters
{
    public class Character
    {
        protected List<Ability> selectedAbilities;

        public Texture2D Texture { get; protected set; }
        protected ContentManager content;

        private int health;
        private int mana;
        private double experience;

        public string Name { get; set; }
        public string Description { get; set; }

        public int Health
        {
            get => health;
            set => health = Math.Clamp(value, 0, MaxHealth);
        }

        public int MaxHealth { get; set; }

        public int PhysicalDamage { get; set; }

        public int MagicDamage { get; set; }

        public int Mana
        {
            get => mana;
            set => mana = Math.Clamp(value, 0, MaxMana);
        }

        public int MaxMana { get; protected set; }

        public int Level { get; protected set; } = 1;

        public double Experience
        {
            get => experience;
            set => experience = Math.Clamp(value, 0, MaxExperience);
        }

        public double MaxExperience { get; private set; }

        protected double MaxExperienceFormula()
        {
            return Math.Pow(Level / 0.07, 2);
        }

        public Character(string name, string description, int maxHealth, int physicalDamage, int magicDamage, int maxMana, ContentManager content)
        {
            selectedAbilities = new List<Ability>();
            this.content = content;
            Name = name;
            Description = description;
            MaxHealth = maxHealth;
            Health = MaxHealth;
            PhysicalDamage = physicalDamage;
            MagicDamage = magicDamage;
            MaxMana = maxMana;
            Mana = MaxMana;
            Experience = 0;
            MaxExperience = MaxExperienceFormula();
        }

        public bool CanLevelUp()
        {
            return Experience >= MaxExperience;
        }

        public virtual void LevelUp()
        {
            Level++;
            MaxExperience = MaxExperienceFormula();
        }
    }
}

