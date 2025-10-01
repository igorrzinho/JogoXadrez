using tabuleiro;
using xadrez;

namespace JogoXadrez
{
    class Tela
    {
        public static void imprimirPartida(PartidaDeXadrez partida)
        {
            imprimirTabuleiro(partida.tab);
            imprimirPecasCapturadas(partida);

            Console.WriteLine("Turno: " + partida.turno);
            Console.WriteLine("Aguardando Jogador: " + partida.jogadorAtual);
        }

        public static void imprimirPecasCapturadas(PartidaDeXadrez partida)
        {
            imprimirConjunto(partida.pecasCapturadas(Cor.Branca));
            Console.WriteLine("Peças capturadas Brancas ");
            System.Console.WriteLine();
            Console.WriteLine("Peças capturadas Pretas ");
            imprimirConjunto(partida.pecasCapturadas(Cor.Preta));

        }

        public static void imprimirConjunto(HashSet<Peca> conjunto)
        {
            System.Console.Write("[");
            foreach (Peca x in conjunto)
            {
                System.Console.Write(x + " ");
            }
            System.Console.Write("]");
        }
        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            for (int i = 0; i < 8; i++)
            {
                System.Console.Write(8 - i + " |");
                for (int j = 0; j < 8; j++)
                {
                    if (tab.peca(i, j) == null)
                    {
                        System.Console.Write(" - ");

                    }
                    else
                    {
                        Tela.imprimirPeca(tab.peca(i, j));
                    }
                }
                System.Console.WriteLine();

            }
            System.Console.WriteLine("==+========================");
            System.Console.WriteLine("X |  A  B  C  D  E  F  G  H");
        }
        public static void imprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGreen;
            for (int i = 0; i < 8; i++)
            {
                System.Console.Write(8 - i + " |");
                for (int j = 0; j < 8; j++)
                {
                    if (posicoesPossiveis[i, j])
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    Tela.imprimirPeca(tab.peca(i, j));
                    Console.BackgroundColor = fundoOriginal;
                }
                System.Console.WriteLine();

            }
            System.Console.WriteLine("==+========================");
            System.Console.WriteLine("X | A B  C  D  E  F  G  H");
        }
        public static PosicaoXadrez lerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }
        public static void imprimirPeca(Peca peca)
        {
            if (peca == null)
            {
                System.Console.Write(" - ");

            }
            else
            {

                if (peca.cor == Cor.Branca)
                {
                    System.Console.Write(" " + peca + " ");
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write(" " + peca + " ");
                    Console.ForegroundColor = aux;
                }
            }
        }
    }
}