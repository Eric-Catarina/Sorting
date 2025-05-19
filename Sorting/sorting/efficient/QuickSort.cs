using Sorting.enemy;
namespace Sorting.sorting.efficient
{
    class QuickSort
    {
        public static Enemy[] Sorting(Enemy[] enemies, string sortBy)
        {
            return QuickSortRecursive(enemies, 0, enemies.Length - 1, sortBy);
        }

        private static Enemy[] QuickSortRecursive(Enemy[] enemies, int left, int right, string sortBy)
        {
            if (left < right)
            {
                int pivot = Partition(enemies, left, right, sortBy);
                QuickSortRecursive(enemies, left, pivot - 1, sortBy);
                QuickSortRecursive(enemies, pivot + 1, right, sortBy);
            }
            return enemies;
        }

        private static int Partition(Enemy[] enemies, int left, int right, string sortBy)
        {
            Enemy pivot = enemies[right];
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (CompareEnemies(enemies[j], pivot, sortBy) <= 0)
                {
                    i++;
                    Swap(enemies, i, j);
                }
            }
            Swap(enemies, i + 1, right);
            return i + 1;
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

        private static void Swap(Enemy[] enemies, int i, int j)
        {
            Enemy temp = enemies[i];
            enemies[i] = enemies[j];
            enemies[j] = temp;
        }
    }
}