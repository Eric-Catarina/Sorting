using Sorting.enemy; // Adicionar esta linha
using Sorting.enums;
using Sorting.sorting.simple;
using Sorting.sorting.efficient;

namespace Sorting.manager
{
    class ManagerFileSorting
    {
        public static void Ordenar(Sortings algoritmo, Enemy[] vet, string sortBy)
        {
            int[] ordenado;

            switch (algoritmo)
            {
                case Sortings.BUBBLESORT:
                    BubbleSort.Sorting(vet, sortBy);
                    break;

                case Sortings.SELECTIONSORT:
                    SelectionSort.Sorting(vet, sortBy);
                    break;

                case Sortings.INSERTIONSORT:
                    InsertionSort.Sorting(vet, sortBy); break;

                // case Sortings.BUCKETSORT:
                //     break;

                // case Sortings.COUNTINGSORT:
                //     break;

                // case Sortings.RADIXSORT:
                //     break;

                // case Sortings.SHELLSORT:
                //     break;

                // case Sortings.QUICKSORT:
                //     break;

                // case Sortings.MERGESORT:
                //     break;

                // case Sortings.HEAPSORT:
                //     break;
            }
        }
    }
}
