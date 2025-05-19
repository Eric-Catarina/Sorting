// Sorting/enemy/Enemy.cs
namespace Sorting.enemy
{
    public class Enemy
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public int Level { get; set; }

        public Enemy(string name, int health, int damage, int level)
        {
            Name = name;
            Health = health;
            Damage = damage;
            Level = level;
        }

        public override string ToString()
        {
            return $"{Name} (Health: {Health}, Damage: {Damage}, Level: {Level})";
        }
    }
}