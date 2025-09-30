using tabuleiro;
using xadrez;

namespace JogoXadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                    PartidaDeXadrez partida = new PartidaDeXadrez();
                while (!partida.terminada)
                {
                    Console.Clear();
                    Tela.imprimirTabuleiro(partida.tab);

                    Console.Write("Origem? ");
                    Posicao origem = Tela.lerPosicaoXadrez().ToPosicao();
                    Console.Write("Destino? ");
                    Posicao destino = Tela.lerPosicaoXadrez().ToPosicao();

                    partida.execultaMovimento(origem, destino);
                }

            }
            catch (TabuleiroException e)
            {
                System.Console.WriteLine(e.Message);
            }





        }
    }
}