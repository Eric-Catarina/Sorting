namespace Sorting.basic_class.dynamic
{
    class ListaDuplamenteEncadeada
    {
        public Celula? primeiro;
        public Celula? ultimo;
        

    public ListaDuplamenteEncadeada()
    {
        primeiro = ultimo = new Celula();
    }
    public bool Inserir(int item)
    {
        if (primeiro == null || ultimo == null) return false;

        Celula nova = new Celula(item);
        nova.prox = primeiro.prox;
        if (primeiro.prox != null)
            primeiro.prox.ant = nova;
        primeiro.prox = nova;
        nova.ant = primeiro;

        if (ultimo == primeiro)
            ultimo = nova;

        return true;
    }
        
public int Remover()
{
    if (primeiro == null || primeiro.prox == null)
        return -1;

    Celula tmp = primeiro.prox;
    primeiro.prox = tmp.prox;
    if (tmp.prox != null)
        tmp.prox.ant = primeiro;

    if (ultimo == tmp)
        ultimo = primeiro;

    return tmp.valor;
}
        public bool Pesquisar(int item)
        {
            for (Celula i = primeiro.prox; i != null; i = i.prox)
            {
                if (i.valor == item)
                    return true;
            }
            return false;
        }
    }
}