namespace MonoeonCrawler.Abilities
{
    abstract public class Ability
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public DamageType Type { get; protected set; }
        public int ManaCost { get; protected set; }
        public Ability(string name, string description, int manaCost)
        {
            Name = name;
            Description = description;
            ManaCost = manaCost;
        }
        public abstract void Use();
    }
}