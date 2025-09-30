using tabuleiro;
using xadrez;

namespace JogoXadrez
{
    class Program
    {
        static void Main(string[] args)
        {


            PosicaoXadrez pos = new PosicaoXadrez('a', 1);
            System.Console.WriteLine(pos);
            System.Console.WriteLine(pos.ToPosicao());


        }
    }
}