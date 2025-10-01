using tabuleiro;

namespace xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual{ get; private set; }
        public bool terminada {get; private set;}


        public PartidaDeXadrez()
        {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            colocarPecas();
            terminada = false;
        }

        public void execultaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.retirarPeca(origem);
            p.incrementarQtdMovimentos();
            tab.retirarPeca(destino);
            tab.colocarPeca(p, destino);
        }

        public void realizaJogada(Posicao origem, Posicao destino)
        {
            execultaMovimento(origem, destino);
            turno++;
            mudaJogador();
        }
        public void validarPosicaoDeOrigem(Posicao pos)
        {
            if (tab.peca(pos) == null)
            {
                throw new TabuleiroException("Não existe peça na posição nesta origem ");
            }

            if (jogadorAtual != tab.peca(pos).cor)
            {
                throw new TabuleiroException("Vez do jogador : " + jogadorAtual);
            }
            if (!tab.peca(pos).existeMovimentosPossiveis())
            {
                throw new TabuleiroException("Não existe movimentos possiveis para a  peça!");
                
            }
        }
        public void validarPosicaoDestino(Posicao origem, Posicao destino)
        {
            if (!tab.peca(origem).podeMoverPara(destino))
            {
                throw new TabuleiroException("Posiçao de destino invalida");
            }
        }

        private void mudaJogador()
        {
            if (jogadorAtual == Cor.Branca)
            {
                jogadorAtual = Cor.Preta;
            }
            else
            {
                jogadorAtual = Cor.Branca;
            }
        }
        private void colocarPecas()
        {
            // pecas brancas
            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('a', 8).ToPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('b', 8).ToPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('c', 8).ToPosicao());
            tab.colocarPeca(new Rei(tab, Cor.Branca), new PosicaoXadrez('d', 8).ToPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('e', 8).ToPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('f', 8).ToPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('g', 8).ToPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('h', 8).ToPosicao());
            // pecas pretas
            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('a', 1).ToPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('b', 1).ToPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('c', 1).ToPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('d', 1).ToPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('e', 1).ToPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('f', 1).ToPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('g', 1).ToPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('h', 1).ToPosicao());
        }

    }
}