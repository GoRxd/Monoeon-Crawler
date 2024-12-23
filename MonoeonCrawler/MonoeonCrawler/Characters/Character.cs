using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoeonCrawler.Abilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MonoeonCrawler.Characters
{
    public class Character
    {
        protected List<Ability> selectedAbilities;

        private List<Texture2D> walkingFrames;
        private List<Texture2D> idleFrames;
        private double animationTimer;
        private double frameTime = 0.1; // Time per frame in seconds
        private int currentFrame;
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


        public Character(string name, string description, int maxHealth, int physicalDamage, int magicDamage, int maxMana, ContentManager content)
        {
            walkingFrames = new List<Texture2D>();
            idleFrames = new List<Texture2D>();
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

            //// Load walking frames
            //for (int i = 0; i < 6; i++) 
            //{
            //    walkingFrames.Add(content.Load<Texture2D>($"Heroes/{name}/Run/{name}-running-{i}"));
            //}

            // Load idle frames
            for (int i = 0; i < 4; i++)
            {
                idleFrames.Add(content.Load<Texture2D>($"Heroes/{name}/Idle/{name}-idle-{i}"));
            }
        }

        public void SetWalking(bool walking)
        {
            if (isWalking != walking)
            {
                isWalking = walking;
                currentFrame = 0;
                animationTimer = 0;
            }
        }


        public void UpdateAnimation(GameTime gameTime)
        {
            animationTimer += gameTime.ElapsedGameTime.TotalSeconds;

            if (animationTimer >= frameTime)
            {
                currentFrame++;
                animationTimer -= frameTime;

                // Loop animation frames
                if (isWalking)
                {
                    currentFrame %= walkingFrames.Count;
                }
                else
                {
                    currentFrame %= idleFrames.Count;
                }
            }
        }

        public Texture2D GetCurrentFrame()
        {
            Debug.WriteLine(currentFrame);
            return isWalking ? walkingFrames[currentFrame] : idleFrames[currentFrame];
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

