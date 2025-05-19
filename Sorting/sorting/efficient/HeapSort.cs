using Sorting.enemy;
namespace Sorting.sorting.efficient
{
    class HeapSort
    {
        public static Enemy[] Sorting(Enemy[] enemies, string sortBy)
        {
            int n = enemies.Length;

            // Build heap
            for (int i = n / 2 - 1; i >= 0; i--)
                Heapify(enemies, n, i, sortBy);

            // Extract elements
            for (int i = n - 1; i > 0; i--)
            {
                (enemies[0], enemies[i]) = (enemies[i], enemies[0]);
                Heapify(enemies, i, 0, sortBy);
            }

            return enemies;
        }

        private static void Heapify(Enemy[] arr, int n, int i, string sortBy)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < n && CompareEnemies(arr[left], arr[largest], sortBy) > 0)
                largest = left;

            if (right < n && CompareEnemies(arr[right], arr[largest], sortBy) > 0)
                largest = right;

            if (largest != i)
            {
                (arr[i], arr[largest]) = (arr[largest], arr[i]);
                Heapify(arr, n, largest, sortBy);
            }
        }

        private static int CompareEnemies(Enemy a, Enemy b, string sortBy)
        {
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
}


