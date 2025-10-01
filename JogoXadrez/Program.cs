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
                    try
                    {

                        Console.Clear();
                        Tela.imprimirTabuleiro(partida.tab);
                        Console.WriteLine("Turno: " + partida.turno);
                        Console.WriteLine("Aguardando Jogador: " + partida.jogadorAtual);
                        Console.Write("Origem? ");
                        Posicao origem = Tela.lerPosicaoXadrez().ToPosicao();
                        partida.validarPosicaoDeOrigem(origem);
                        
                        bool[,] posicoesPossiveis = partida.tab.peca(origem).movimentosPossiveis();


                        Console.Clear();
                        Tela.imprimirTabuleiro(partida.tab, posicoesPossiveis);
                        Console.Write("Destino? ");
                        Posicao destino = Tela.lerPosicaoXadrez().ToPosicao();
                        partida.validarPosicaoDestino(origem, destino);
                        partida.realizaJogada(origem, destino);
                    }
                    catch (TabuleiroException e)
                    {
                        System.Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }

                }

            }
            catch (TabuleiroException e)
            {
                System.Console.WriteLine(e.Message);
            }





        }
    }
}