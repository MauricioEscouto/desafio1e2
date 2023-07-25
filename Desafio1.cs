using System;

public class Desafio1
{
    public static void Main()
    {
        Node root = null;
        root = Inserir(root, 3);
        root = Inserir(root, 2);
        root = Inserir(root, 4);
        root = Inserir(root, 5);
        root = Inserir(root, 6);

        PercursoEmOrdem(root);
    }

    public class Node
    {
        public int valor;
        public Node esquerda;
        public Node direita;
        public int altura;

        public Node(int val)
        {
            this.valor = val;
            this.esquerda = null;
            this.direita = null;
            this.altura = 0;
        }
    }

    public static Node Inserir(Node raiz, int novoValor)
    {
        if (raiz == null)
        {
            raiz = new Node(novoValor);
        }
        else if (novoValor < raiz.valor)
        {
            raiz.esquerda = Inserir(raiz.esquerda, novoValor);
        }
        else
        {
            raiz.direita = Inserir(raiz.direita, novoValor);
        }

        AtualizarAltura(raiz);

        int fatorBalanceamento = Altura(raiz.esquerda) - Altura(raiz.direita);

        if (fatorBalanceamento > 1)
        {
            if (novoValor < raiz.esquerda.valor)
            {
                raiz = RotacaoDireita(raiz);
            }
            else
            {
                raiz.esquerda = RotacaoEsquerda(raiz.esquerda);
                raiz = RotacaoDireita(raiz);
            }
        }
        else if (fatorBalanceamento < -1)
        {
            if (novoValor > raiz.direita.valor)
            {
                raiz = RotacaoEsquerda(raiz);
            }
            else
            {
                raiz.direita = RotacaoDireita(raiz.direita);
                raiz = RotacaoEsquerda(raiz);
            }
        }

        return raiz;
    }

    public static int Altura(Node raiz)
    {
        if (raiz == null) return -1;
        return raiz.altura;
    }

    public static void AtualizarAltura(Node raiz)
    {
        if (raiz == null) return;
        int alturaEsquerda = Altura(raiz.esquerda);
        int alturaDireita = Altura(raiz.direita);
        raiz.altura = Math.Max(alturaEsquerda, alturaDireita) + 1;
    }

    public static Node RotacaoDireita(Node raiz)
    {
        Node novaRaiz = raiz.esquerda;
        Node novaRaizDireita = novaRaiz.direita;
        novaRaiz.direita = raiz;
        raiz.esquerda = novaRaizDireita;
        AtualizarAltura(raiz);
        AtualizarAltura(novaRaiz);
        return novaRaiz;
    }

    public static Node RotacaoEsquerda(Node raiz)
    {
        Node novaRaiz = raiz.direita;
        Node novaRaizEsquerda = novaRaiz.esquerda;
        novaRaiz.esquerda = raiz;
        raiz.direita = novaRaizEsquerda;
        AtualizarAltura(raiz);
        AtualizarAltura(novaRaiz);
        return novaRaiz;
    }

    public static void PercursoEmOrdem(Node raiz)
    {
        if (raiz != null)
        {
            PercursoEmOrdem(raiz.esquerda);
            Console.Write(raiz.valor + "(BF=" + (Altura(raiz.esquerda) - Altura(raiz.direita)) + ") ");
            PercursoEmOrdem(raiz.direita);
        }
    }
}
