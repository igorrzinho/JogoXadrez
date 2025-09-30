using tabuleiro;
using xadrez;

namespace JogoXadrez
{
    class Tela
    {
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
        public static PosicaoXadrez lerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }
        public static void imprimirPeca(Peca peca)
        {
            if (peca.cor == Cor.Branca)
            {
                System.Console.Write(" "+ peca + " ");
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write(" "+ peca + " ");
                Console.ForegroundColor = aux;
            }
        }
    }
}