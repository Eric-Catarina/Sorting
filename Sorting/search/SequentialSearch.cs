// Sorting/search/SequentialSearch.cs
using Sorting.enemy;
using Sorting.structures;

namespace Sorting.search
{
    public class SequentialSearch
    {
        public static bool Search(ListaDinamica lista, string nome)
        {
            var atual = lista.Primeiro.Prox;
            while (atual != null)
            {
                if (atual.Dado.Name.Equals(nome, StringComparison.OrdinalIgnoreCase))
                    return true;
                atual = atual.Prox;
            }
            return false;
        }
    }
}