using Sorting.enemy;
namespace Sorting.search
{
    class BinarySearch
    {
        public static bool Search(Enemy[] enemies, string property, string value)
        {
            int left = 0;
            int right = enemies.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                string midValue = property.ToLower() switch
                {
                    "name" => enemies[mid].Name,
                    "health" => enemies[mid].Health.ToString(),
                    "damage" => enemies[mid].Damage.ToString(),
                    "level" => enemies[mid].Level.ToString(),
                    _ => ""
                };

                int comparison = string.Compare(midValue, value);

                if (comparison == 0)
                    return true;
                else if (comparison < 0)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return false;
        }
    }
}