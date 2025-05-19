// Sorting/search/BinarySearch.cs
using Sorting.enemy;
using Sorting.structures;
using System.Collections.Generic;
using System.Linq;

namespace Sorting.search
{
    public class BinarySearch
    {
        public static bool Search(ListaDinamica lista, string nome)
        {
            List<Enemy> sortedList = new List<Enemy>();
            var atual = lista.Primeiro.Prox;
            
            while (atual != null)
            {
                sortedList.Add(atual.Dado);
                atual = atual.Prox;
            }

            sortedList = sortedList.OrderBy(e => e.Name).ToList();
            
            int left = 0;
            int right = sortedList.Count - 1;
            
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                int comparison = string.Compare(sortedList[mid].Name, nome, StringComparison.OrdinalIgnoreCase);
                
                if (comparison == 0) return true;
                if (comparison < 0) left = mid + 1;
                else right = mid - 1;
            }
            return false;
        }
    }
}