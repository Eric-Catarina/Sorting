// Sorting/sorting/simple/SelectionSort.cs
using Sorting.enemy;

namespace Sorting.sorting.simple
{
    class SelectionSort
    {
        public static Enemy[] Sorting(Enemy[] enemies, string sortBy)
        {
            int n = enemies.Length;
            
            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (CompareEnemies(enemies[j], enemies[minIndex], sortBy) < 0)
                    {
                        minIndex = j;
                    }
                }
                
                Enemy temp = enemies[minIndex];
                enemies[minIndex] = enemies[i];
                enemies[i] = temp;
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
        _ => 0 // Garante um retorno padrão
    };
}
    }
}