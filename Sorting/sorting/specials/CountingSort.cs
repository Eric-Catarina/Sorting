namespace Sorting.sorting.specials
{
    class CountingSort
    {
        public static int[] Sorting(int[] vet)
        {
            int n = vet.Length;
            int biggestValue = vet.Max();
            int[] count = new int[biggestValue + 1];

            // Inicializa o vetor de contagem com zeros
            for (int i = 0; i < biggestValue + 1; i++)
            {
                count[i] = 0;
            }

            // Fill the count array
            for (int i = 0; i < n; i++)
            {
                count[vet[i]]++;
            }

            // Store the cumulative count of each array
            for (int i = 1; i < biggestValue + 1; i++)
            {
                count[i] += count[i - 1];
            }

            // Build the output character array
            int[] output = new int[n];
            for (int i = n - 1; i >= 0; i--)
            {
                output[count[vet[i]] - 1] = vet[i];
                count[vet[i]]--;
            }

            // Copy the output array to the original array
            for (int i = 0; i < n; i++)
            {
                vet[i] = output[i];
            }
            
           

            return vet;
        }
    }    
}

