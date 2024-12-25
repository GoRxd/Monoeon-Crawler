using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoeonCrawler.Abilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;

namespace MonoeonCrawler.Characters
{
    public class Character
    {
        protected List<Ability> selectedAbilities;
        public Texture2D IdleTexture { get; protected set; }
        public Texture2D WalkingTexture { get; protected set; }

        public const int runningFrameWidth = 320;
        public const int idleFrameWidth = 160;
        public const int idleCharacterWidth = 125;
        public const int runningCharacterWidth = 130;
        private double animationTimer;
        private double frameTime = 0.25; // Time per frame in seconds
        public int CurrentFrame { get; protected set; }
        private bool isWalking;

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

        public double GetCharacterWidth()
        {
            return isWalking ? runningCharacterWidth : idleCharacterWidth;
        }

        public double GetFrameWidth()
        {
            return isWalking ? runningFrameWidth : idleFrameWidth;
        }


        public Character(string name, string description, int maxHealth, int physicalDamage, int magicDamage, int maxMana, ContentManager content)
        {
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
            IdleTexture = content.Load<Texture2D>($"Heroes/{Name}/Idle/Idle-Sheet");
            WalkingTexture = content.Load<Texture2D>($"Heroes/{Name}/Run/Run-Sheet");
        }

        public void SetWalking(bool walking)
        {
            if (isWalking != walking)
            {
                isWalking = walking;
                CurrentFrame = 0;
                animationTimer = 0;
            }
        }


        public void UpdateAnimation(GameTime gameTime)
        {
            animationTimer += gameTime.ElapsedGameTime.TotalSeconds;

            if (animationTimer >= frameTime)
            {
                CurrentFrame++;
                animationTimer -= frameTime;

                // Loop animation frames
                if (isWalking)
                {
                    CurrentFrame %= 6;
                }
                else
                {
                    CurrentFrame %= 4;
                }
            }
        }

        public Texture2D GetCurrentTexture()
        {
            return isWalking ? WalkingTexture : IdleTexture;
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

