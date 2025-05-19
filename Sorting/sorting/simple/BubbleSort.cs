using Sorting.enemy;
namespace Sorting.sorting.simple
{
    class BubbleSort
    {
        public static Enemy[] Sorting(Enemy[] enemies, string sortBy)
        {

            int n = enemies.Length;

            for (int i = 0; i < n; i++)
            {
                for (int j = n - 1; j > i; j--)
                {
                    bool shouldSwap = false;
                    switch (sortBy.ToLower())
                    {
                        case "name":
                            shouldSwap = string.Compare(enemies[j].Name, enemies[j - 1].Name) < 0;
                            break;
                        case "health":
                            shouldSwap = enemies[j].Health < enemies[j - 1].Health;
                            break;
                        case "damage":
                            shouldSwap = enemies[j].Damage < enemies[j - 1].Damage;
                            break;
                        case "level":
                            shouldSwap = enemies[j].Level < enemies[j - 1].Level;
                            break;
                    }

                    if (shouldSwap)
                    {
                        Enemy tmp = enemies[j];
                        enemies[j] = enemies[j - 1];
                        enemies[j - 1] = tmp;
                    }
                }
            }

            return enemies;
        }
    }
}