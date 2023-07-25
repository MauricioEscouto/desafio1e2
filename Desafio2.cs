public class NoListaEncadeadaSimples
{
    public int dado;
    public NoListaEncadeadaSimples proximo;

    public NoListaEncadeadaSimples(int dado)
    {
        this.dado = dado;
        this.proximo = null;
    }
}

public class ListaEncadeada
{
    public static int TemCiclo(NoListaEncadeadaSimples cabeca)
    {
        if (cabeca == null || cabeca.proximo == null)
            return 0;

        NoListaEncadeadaSimples lento = cabeca;
        NoListaEncadeadaSimples rapido = cabeca.proximo;

        while (rapido != null && rapido.proximo != null)
        {
            if (lento == rapido)
                return 1;

            lento = lento.proximo;
            rapido = rapido.proximo.proximo;
        }

        return 0;
    }
}

public class Desafio2
{
    public static void Main(string[] args)
    {
        NoListaEncadeadaSimples cabeca1 = new NoListaEncadeadaSimples(1);
        Console.WriteLine(ListaEncadeada.TemCiclo(cabeca1));

        NoListaEncadeadaSimples cabeca2 = new NoListaEncadeadaSimples(1);
        cabeca2.proximo = new NoListaEncadeadaSimples(2);
        cabeca2.proximo.proximo = new NoListaEncadeadaSimples(3);
        cabeca2.proximo.proximo.proximo = cabeca2.proximo; 
        Console.WriteLine(ListaEncadeada.TemCiclo(cabeca2)); 
    }
}