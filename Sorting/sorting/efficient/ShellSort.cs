// Sorting/sorting/efficient/ShellSort.cs
using Sorting.enemy; // Adicionar esta linha

namespace Sorting.sorting.efficient
{
    class ShellSort
    {
        public static Enemy[] Sorting(Enemy[] enemies, string sortBy)
        {
            // Implementação real do ShellSort para Enemy
            int n = enemies.Length;
            int gap = n / 2;

            while (gap > 0)
            {
                for (int i = gap; i < n; i++)
                {
                    Enemy temp = enemies[i];
                    int j;
                    for (j = i; j >= gap && CompareEnemies(enemies[j - gap], temp, sortBy) > 0; j -= gap)
                    {
                        enemies[j] = enemies[j - gap];
                    }
                    enemies[j] = temp;
                }
                gap /= 2;
            }
            return enemies;
        }

        private static int CompareEnemies(Enemy a, Enemy b, string sortBy)
        {
            return sortBy.ToLower() switch
            {
                "name" => string.Compare(a.Name, b.Name),
                "health" => a.Health.CompareTo(b.Health),
                "damage" => a.Damage.CompareTo(b.Damage),
                "level" => a.Level.CompareTo(b.Level),
                _ => 0
            };
        }
    }
}