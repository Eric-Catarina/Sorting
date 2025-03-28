using Sorting.manager;
using Sorting.print;

public class Program
{
    public static void Main(string[] args)
    {
        // https://github.com/accj1990/Sorting.git
        // https://pt.overleaf.com/read/kptbxrwtrzch#8b9776

        int[] vet = ManagerFileReader.Arquivo100TXT();

        PrintSolutionStatic.ImprimirArrayMesmaLinha(vet, Sorting.enums.Sortings.COUNTINGSORT);

        ManagerFileSorting.Ordenar(Sorting.enums.Sortings.COUNTINGSORT, vet);

        PrintSolutionStatic.ImprimirArrayMesmaLinha(vet, Sorting.enums.Sortings.COUNTINGSORT);


        // Crie um menu que solicite ao usuário qual é o arquivo que será lido e qual algoritmo deverá ser executado



    }
}