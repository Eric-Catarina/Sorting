using Sorting.enemy;
namespace Sorting.sorting.efficient
{
    class HeapSort
    {
        public static Enemy[] Sorting(Enemy[] enemies, string sortBy)
        {
            if (enemies.Length <= 1)
                return enemies;

            // Divide o array em duas partes
            int mid = enemies.Length / 2;
            Enemy[] left = new Enemy[mid];
            Enemy[] right = new Enemy[enemies.Length - mid];

            Array.Copy(enemies, 0, left, 0, mid);
            Array.Copy(enemies, mid, right, 0, enemies.Length - mid);

            // Recursivamente ordena as duas metades
            left = Sorting(left, sortBy);
            right = Sorting(right, sortBy);

            // Combina as metades ordenadas
            return Merge(left, right, sortBy);
        }

        private static Enemy[] Merge(Enemy[] left, Enemy[] right, string sortBy)
        {
            Enemy[] result = new Enemy[left.Length + right.Length];
            int leftIndex = 0, rightIndex = 0, resultIndex = 0;

            while (leftIndex < left.Length && rightIndex < right.Length)
            {
                if (CompareEnemies(left[leftIndex], right[rightIndex], sortBy) <= 0)
                {
                    result[resultIndex] = left[leftIndex];
                    leftIndex++;
                }
                else
                {
                    result[resultIndex] = right[rightIndex];
                    rightIndex++;
                }
                resultIndex++;
            }

            // Copia os elementos restantes (se houver)
            while (leftIndex < left.Length)
            {
                result[resultIndex] = left[leftIndex];
                leftIndex++;
                resultIndex++;
            }

            while (rightIndex < right.Length)
            {
                result[resultIndex] = right[rightIndex];
                rightIndex++;
                resultIndex++;
            }

            return result;
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
