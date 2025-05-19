// Sorting/hash/HashTable.cs
using Sorting.enemy;
using System.Collections.Generic;

namespace Sorting.hash
{
    public class HashTable
    {
        private const int Size = 100;
        private readonly LinkedList<Enemy>[] table;

        public HashTable()
        {
            table = new LinkedList<Enemy>[Size];
            for (int i = 0; i < Size; i++)
                table[i] = new LinkedList<Enemy>();
        }

        private int HashFunction(string name)
        {
            int hash = 0;
            foreach (char c in name)
                hash += c;
            return hash % Size;
        }

        public void Add(Enemy enemy)
        {
            int index = HashFunction(enemy.Name);
            table[index].AddLast(enemy);
        }

        public bool Contains(string name)
        {
            int index = HashFunction(name);
            foreach (Enemy enemy in table[index])
            {
                if (enemy.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }
    }
}