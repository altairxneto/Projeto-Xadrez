using TabuleiroJogo;

namespace JogoXadrez {
    class Cavalo : Peca {
        public Cavalo(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor) {

        }

        public override string ToString() {
            return "C";
        }

        public bool PodeMover(Posicao posicao) {
            Peca peca = Tabuleiro.PecaTabuleiro(posicao);
            return peca == null || peca.Cor != Cor;
        }

        public override bool[,] MovimentosPossiveis() {
            bool[,] matriz = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Posicao posicao = new Posicao(Posicao.Linha, Posicao.Coluna);
            posicao.DefinirValores(posicao.Linha - 1, posicao.Coluna - 2);
            
            if(Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao)) {
                matriz[posicao.Linha, posicao.Coluna] = true;
            }

            posicao = new Posicao(Posicao.Linha, Posicao.Coluna);
            posicao.DefinirValores(posicao.Linha - 2, posicao.Coluna - 1);

            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao)) {
                matriz[posicao.Linha, posicao.Coluna] = true;
            }

            posicao = new Posicao(Posicao.Linha, Posicao.Coluna);
            posicao.DefinirValores(posicao.Linha - 2, posicao.Coluna + 1);

            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao)) {
                matriz[posicao.Linha, posicao.Coluna] = true;
            }

            posicao = new Posicao(Posicao.Linha, Posicao.Coluna);
            posicao.DefinirValores(posicao.Linha - 1, posicao.Coluna + 2);

            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao)) {
                matriz[posicao.Linha, posicao.Coluna] = true;
            }

            posicao = new Posicao(Posicao.Linha, Posicao.Coluna);
            posicao.DefinirValores(posicao.Linha + 1, posicao.Coluna + 2);

            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao)) {
                matriz[posicao.Linha, posicao.Coluna] = true;
            }

            posicao = new Posicao(Posicao.Linha, Posicao.Coluna);
            posicao.DefinirValores(posicao.Linha + 2, posicao.Coluna + 1);

            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao)) {
                matriz[posicao.Linha, posicao.Coluna] = true;
            }

            posicao = new Posicao(Posicao.Linha, Posicao.Coluna);
            posicao.DefinirValores(posicao.Linha + 2, posicao.Coluna - 1);

            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao)) {
                matriz[posicao.Linha, posicao.Coluna] = true;
            }

            posicao = new Posicao(Posicao.Linha, Posicao.Coluna);
            posicao.DefinirValores(posicao.Linha + 1, posicao.Coluna - 2);

            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao)) {
                matriz[posicao.Linha, posicao.Coluna] = true;
            }

            return matriz;
        }
    }
}