// Sorting/sorting/simple/InsertionSort.cs
using Sorting.enemy;

namespace Sorting.sorting.simple
{
    class InsertionSort
    {
        public static Enemy[] Sorting(Enemy[] enemies, string sortBy)
        {
            int n = enemies.Length;
            for (int i = 1; i < n; i++)
            {
                Enemy key = enemies[i];
                int j = i - 1;

                while (j >= 0 && CompareEnemies(enemies[j], key, sortBy) > 0)
                {
                    enemies[j + 1] = enemies[j];
                    j--;
                }
                enemies[j + 1] = key;
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