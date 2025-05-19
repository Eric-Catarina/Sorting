namespace Sorting.basic_class.@static
{
    class Lista
    {
        public int[] lista;
        public int cont;

        public Lista(int n)
        {
            lista = new int[n];
            cont = 0;
        }

        public bool InserirFim(int item)
        {
            if (cont < lista.Length)
            {
                lista[cont] = item;
                cont++;
                return true;
            }
            else
            {
                Console.WriteLine("Lista está cheia, não é possível inserir " + item);
                return false;
            }
        }

        public bool InserirInicio(int item)
        {
            return true;// implemente
        }

        public bool InserirPosicao(int pos)
        {
            return true;// implemente
        }

        public int RemoverFim()
        {
            return -1; // implemente
        }

        public int RemoverInicio()
        {
            return -1; // implemente
        }

        public int RemoverPosicao(int pos)
        {
            return -1; // implemente
        }
        public int Pesquisar(int item)
        {
            for (int i = 0; i < cont; i++)
            {
                if (lista[i] == item)
                {
                    return i;
                }
            }
            return -1;
        }

    }
}
