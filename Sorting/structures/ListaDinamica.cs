// Sorting/structures/ListaDinamica.cs
using Sorting.enemy;

namespace Sorting.structures
{
    public class ListaDinamica
    {
        public class Celula
        {
            public Enemy Dado { get; set; }
            public Celula Prox { get; set; }
        }

        public Celula Primeiro { get; private set; }
        public int Tamanho { get; private set; }

        public ListaDinamica()
        {
            Primeiro = new Celula();
            Tamanho = 0;
        }

        public void Inserir(Enemy dado)
        {
            Celula nova = new Celula
            {
                Dado = dado,
                Prox = Primeiro.Prox
            };
            Primeiro.Prox = nova;
            Tamanho++;
        }
    }
}