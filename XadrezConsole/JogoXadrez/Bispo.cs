using TabuleiroJogo;

namespace JogoXadrez {
    class Bispo:Peca {
        public Bispo(Tabuleiro tabuleiro, Cor cor):base(tabuleiro, cor) {

        }

        public override string ToString() {
            return "B";
        }

        public bool PodeMover(Posicao posicao) {
            Peca peca = Tabuleiro.PecaTabuleiro(posicao);
            return peca == null || peca.Cor != Cor;
        }

        public override bool[,] MovimentosPossiveis() {
            bool[,] matriz = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Posicao posicao = new Posicao(Posicao.Linha, Posicao.Coluna);

            //noroeste

            posicao.DefinirValores(posicao.Linha - 1, posicao.Coluna - 1);

            while(Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao)) {
                matriz[posicao.Linha, posicao.Coluna] = true;
                if(Tabuleiro.PecaTabuleiro(posicao) != null && Tabuleiro.PecaTabuleiro(posicao).Cor != Cor) {
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
    }
}
