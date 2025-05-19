// Sorting/basic_class/dynamic/Celula.cs
namespace Sorting.basic_class.dynamic
{
    class Celula
    {
        public int valor;
        public Celula? prox;
        public Celula? ant; // Adicione esta linha

        public Celula()
        {
            this.valor = -1;
            this.prox = null;
            this.ant = null; // Adicione esta linha
        }

        public Celula(int valor)
        {
            this.valor = valor;
            this.prox = null;
            this.ant = null; // Adicione esta linha
        }
    }
}