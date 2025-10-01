using tabuleiro;

namespace xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; }
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;

        public PartidaDeXadrez()
        {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
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

        public HashSet<Peca> pecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in capturadas)
            {
                if (x.cor == cor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Peca> pecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in pecas)
            {
                if (x.cor == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(pecasCapturadas(cor));
            return aux;
        }
        public void colocarNovaPeca(char coluna, int linha, Peca peca)
        {
            tab.colocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
            pecas.Add(peca);
        }
        private void colocarPecas()
        {
            // pecas brancas
            colocarNovaPeca('a', 8, new Torre(tab, Cor.Branca));
            colocarNovaPeca('b', 8, new Torre(tab, Cor.Branca));
            colocarNovaPeca('c', 8, new Torre(tab, Cor.Branca));
            colocarNovaPeca('d', 8, new Rei(tab, Cor.Branca));
            colocarNovaPeca('e', 8, new Torre(tab, Cor.Branca));
            colocarNovaPeca('f', 8, new Torre(tab, Cor.Branca));
            colocarNovaPeca('g', 8, new Torre(tab, Cor.Branca));
            colocarNovaPeca('h', 8, new Torre(tab, Cor.Branca));
            // pecas pretas
            colocarNovaPeca('a', 1, new Torre(tab, Cor. Preta));
            colocarNovaPeca('b', 1, new Torre(tab, Cor. Preta));
            colocarNovaPeca('c', 1, new Torre(tab, Cor. Preta));
            colocarNovaPeca('d', 1, new Rei(tab, Cor. Preta));
            colocarNovaPeca('e', 1, new Torre(tab, Cor. Preta));
            colocarNovaPeca('f', 1, new Torre(tab, Cor. Preta));
            colocarNovaPeca('g', 1, new Torre(tab, Cor. Preta));
            colocarNovaPeca('h', 1, new Torre(tab, Cor. Preta));
        }

    }
}