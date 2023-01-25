using TabuleiroJogo;

namespace JogoXadrez {
    class Rei:Peca {
        public Rei(Tabuleiro tabuleiro, Cor cor):base(tabuleiro, cor) {

        }

        public override string ToString() {
            return "R";
        }

        public bool PodeMover(Posicao posicao) {
            Peca peca = Tabuleiro.PecaTabuleiro(posicao);

            return peca == null || peca.Cor != Cor;
        }

        public override bool[,] MovimentosPossiveis() {
            bool[,] matriz = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Posicao posicao = new Posicao(Posicao.Linha, Posicao.Coluna);

            //acima
            posicao.DefinirValores(posicao.Linha - 1, posicao.Coluna);

            if(Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao)) {
                matriz[posicao.Linha, posicao.Coluna] = true;
            }

            //nordeste
            posicao = new Posicao(Posicao.Linha, Posicao.Coluna);
            posicao.DefinirValores(posicao.Linha - 1, posicao.Coluna + 1);

            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao)) {
                matriz[posicao.Linha, posicao.Coluna] = true;
            }

            //direita
            posicao = new Posicao(Posicao.Linha, Posicao.Coluna);
            posicao.DefinirValores(posicao.Linha, posicao.Coluna + 1);

            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao)) {
                matriz[posicao.Linha, posicao.Coluna] = true;
            }

            //sudeste
            posicao = new Posicao(Posicao.Linha, Posicao.Coluna);
            posicao.DefinirValores(posicao.Linha + 1, posicao.Coluna + 1);

            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao)) {
                matriz[posicao.Linha, posicao.Coluna] = true;
            }

            //abaixo
            posicao = new Posicao(Posicao.Linha, Posicao.Coluna);
            posicao.DefinirValores(posicao.Linha + 1, posicao.Coluna);

            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao)) {
                matriz[posicao.Linha, posicao.Coluna] = true;
            }

            //sudoeste
            posicao = new Posicao(Posicao.Linha, Posicao.Coluna);
            posicao.DefinirValores(posicao.Linha + 1, posicao.Coluna - 1);

            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao)) {
                matriz[posicao.Linha, posicao.Coluna] = true;
            }

            //esquerda
            posicao = new Posicao(Posicao.Linha, Posicao.Coluna);
            posicao.DefinirValores(posicao.Linha, posicao.Coluna - 1);

            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao)) {
                matriz[posicao.Linha, posicao.Coluna] = true;
            }

            //noroeste
            posicao = new Posicao(Posicao.Linha, Posicao.Coluna);
            posicao.DefinirValores(posicao.Linha - 1, posicao.Coluna - 1);

            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao)) {
                matriz[posicao.Linha, posicao.Coluna] = true;
            }

            return matriz;
        }
    }
}
