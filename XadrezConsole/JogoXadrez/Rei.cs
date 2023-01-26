using TabuleiroJogo;

namespace JogoXadrez {
    class Rei:Peca {
        private PartidaDeXadrez _partida;
        public Rei(Tabuleiro tabuleiro, Cor cor, PartidaDeXadrez partida):base(tabuleiro, cor) {
            _partida = partida;
        }

        public override string ToString() {
            return "R";
        }

        public bool PodeMover(Posicao posicao) {
            Peca peca = Tabuleiro.PecaTabuleiro(posicao);

            return peca == null || peca.Cor != Cor;
        }

        private bool TesteTorreParaRoque(Posicao posicao) {
            Peca peca = Tabuleiro.PecaTabuleiro(posicao);

            return peca != null && peca is Torre && peca.Cor == Cor && peca.QteMovimentos == 0;
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

            // #jogadaEspecial Roque
            posicao = new Posicao(Posicao.Linha, Posicao.Coluna);
            if (QteMovimentos == 0 && !_partida.Xeque) {
                //#roquePequeno
                Posicao posicaoTorre1 = new Posicao(posicao.Linha, posicao.Coluna + 3);
                if (TesteTorreParaRoque(posicaoTorre1)) {
                    Posicao posicao1 = new Posicao(posicao.Linha, posicao.Coluna + 1);
                    Posicao posicao2 = new Posicao(posicao.Linha, posicao.Coluna + 2);

                    if(Tabuleiro.PecaTabuleiro(posicao1) == null && Tabuleiro.PecaTabuleiro(posicao2) == null) {
                        matriz[posicao.Linha, posicao.Coluna + 2] = true;
                    }
                }

                //#roqueGrande
                Posicao posicaoTorre2 = new Posicao(posicao.Linha, posicao.Coluna - 4);
                if (TesteTorreParaRoque(posicaoTorre2)) {
                    Posicao posicao1 = new Posicao(posicao.Linha, posicao.Coluna - 1);
                    Posicao posicao2 = new Posicao(posicao.Linha, posicao.Coluna - 2);
                    Posicao posicao3 = new Posicao(posicao.Linha, posicao.Coluna - 3);

                    if (Tabuleiro.PecaTabuleiro(posicao1) == null && Tabuleiro.PecaTabuleiro(posicao2) == null && Tabuleiro.PecaTabuleiro(posicao3) == null) {
                        matriz[posicao.Linha, posicao.Coluna - 2] = true;
                    }
                }
            }

            return matriz;
        }
    }
}
