using TabuleiroJogo;

namespace JogoXadrez {
    class Dama : Peca {
        public Dama(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor) {

        }

        private bool PodeMover(Posicao posicao) {
            Peca peca = Tabuleiro.PecaTabuleiro(posicao);

            return peca == null || peca.Cor != Cor;
        }

        public override bool[,] MovimentosPossiveis() {
            bool[,] matriz = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Posicao posicao = new Posicao(Posicao.Linha, Posicao.Coluna);

            //acima
            posicao.DefinirValores(posicao.Linha - 1, posicao.Coluna);

            while (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao)) {
                matriz[posicao.Linha, posicao.Coluna] = true;

                if (Tabuleiro.PecaTabuleiro(posicao) != null && Tabuleiro.PecaTabuleiro(posicao).Cor != Cor) {
                    break;
                }

                posicao.Linha = posicao.Linha - 1;
            }

            //abaixo
            posicao = new Posicao(Posicao.Linha, Posicao.Coluna);
            posicao.DefinirValores(posicao.Linha + 1, posicao.Coluna);

            while (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao)) {
                matriz[posicao.Linha, posicao.Coluna] = true;

                if (Tabuleiro.PecaTabuleiro(posicao) != null && Tabuleiro.PecaTabuleiro(posicao).Cor != Cor) {
                    break;
                }

                posicao.Linha = posicao.Linha + 1;
            }

            //direita
            posicao = new Posicao(Posicao.Linha, Posicao.Coluna);
            posicao.DefinirValores(posicao.Linha, posicao.Coluna + 1);

            while (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao)) {
                matriz[posicao.Linha, posicao.Coluna] = true;

                if (Tabuleiro.PecaTabuleiro(posicao) != null && Tabuleiro.PecaTabuleiro(posicao).Cor != Cor) {
                    break;
                }

                posicao.Coluna = posicao.Coluna + 1;
            }

            //esquerda
            posicao = new Posicao(Posicao.Linha, Posicao.Coluna);
            posicao.DefinirValores(posicao.Linha, posicao.Coluna - 1);

            while (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao)) {
                matriz[posicao.Linha, posicao.Coluna] = true;

                if (Tabuleiro.PecaTabuleiro(posicao) != null && Tabuleiro.PecaTabuleiro(posicao).Cor != Cor) {
                    break;
                }

                posicao.Coluna = posicao.Coluna - 1;
            }

            //noroeste

            posicao = new Posicao(Posicao.Linha, Posicao.Coluna);
            posicao.DefinirValores(posicao.Linha - 1, posicao.Coluna - 1);

            while (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao)) {
                matriz[posicao.Linha, posicao.Coluna] = true;
                if (Tabuleiro.PecaTabuleiro(posicao) != null && Tabuleiro.PecaTabuleiro(posicao).Cor != Cor) {
                    break;
                }

                posicao.DefinirValores(posicao.Linha - 1, posicao.Coluna - 1);
            }

            //nordeste

            posicao = new Posicao(Posicao.Linha, Posicao.Coluna);
            posicao.DefinirValores(posicao.Linha - 1, posicao.Coluna + 1);

            while (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao)) {
                matriz[posicao.Linha, posicao.Coluna] = true;
                if (Tabuleiro.PecaTabuleiro(posicao) != null && Tabuleiro.PecaTabuleiro(posicao).Cor != Cor) {
                    break;
                }

                posicao.DefinirValores(posicao.Linha - 1, posicao.Coluna + 1);
            }

            //sudeste

            posicao = new Posicao(Posicao.Linha, Posicao.Coluna);
            posicao.DefinirValores(posicao.Linha + 1, posicao.Coluna + 1);

            while (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao)) {
                matriz[posicao.Linha, posicao.Coluna] = true;
                if (Tabuleiro.PecaTabuleiro(posicao) != null && Tabuleiro.PecaTabuleiro(posicao).Cor != Cor) {
                    break;
                }

                posicao.DefinirValores(posicao.Linha + 1, posicao.Coluna + 1);
            }

            //sudoeste

            posicao = new Posicao(Posicao.Linha, Posicao.Coluna);
            posicao.DefinirValores(posicao.Linha + 1, posicao.Coluna - 1);

            while (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao)) {
                matriz[posicao.Linha, posicao.Coluna] = true;
                if (Tabuleiro.PecaTabuleiro(posicao) != null && Tabuleiro.PecaTabuleiro(posicao).Cor != Cor) {
                    break;
                }

                posicao.DefinirValores(posicao.Linha + 1, posicao.Coluna - 1);
            }

            return matriz;
        }

        public override string ToString() {
            return "D";
        }
    }
}