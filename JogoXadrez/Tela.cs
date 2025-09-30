using tabuleiro;

namespace JogoXadrez
{
    class Tela
    {
        public static void ImprimirTabuleiro(Tabuleiro tab)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (tab.peca(i, j) == null)
                    {
                        System.Console.Write(" - ");

                    }
                    else
                    {
                        System.Console.Write(" "+ tab.peca(i, j) + " ");
                    }
                }
                System.Console.WriteLine();
                
            }
        }
    }
}