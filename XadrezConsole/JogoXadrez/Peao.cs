using TabuleiroJogo;

namespace JogoXadrez {
    class Peao : Peca {
        public Peao(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor) {

        }

        public override string ToString() {
            return "P";
        }

        public bool ExisteInimigo(Posicao posicao) {
            Peca peca = Tabuleiro.PecaTabuleiro(posicao);
            return peca != null && peca.Cor != Cor;
        }

        public bool Livre(Posicao posicao) {
            return Tabuleiro.PecaTabuleiro(posicao) == null;
        }

        public override bool[,] MovimentosPossiveis() {
            bool[,] matriz = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Posicao posicao = new Posicao(Posicao.Linha, Posicao.Coluna);

            if(Cor == Cor.Branca) {
                posicao.DefinirValores(posicao.Linha - 1, posicao.Coluna);
                if(Tabuleiro.PosicaoValida(posicao) && Livre(posicao)) {
                    matriz[posicao.Linha, posicao.Coluna] = true;
                }

                posicao = new Posicao(Posicao.Linha, Posicao.Coluna);
                posicao.DefinirValores(posicao.Linha - 2, posicao.Coluna);
                if (Tabuleiro.PosicaoValida(posicao) && Livre(posicao) && QteMovimentos == 0) {
                    matriz[posicao.Linha, posicao.Coluna] = true;
                }

                posicao = new Posicao(Posicao.Linha, Posicao.Coluna);
                posicao.DefinirValores(posicao.Linha - 1, posicao.Coluna - 1);
                if (Tabuleiro.PosicaoValida(posicao) && ExisteInimigo(posicao)) {
                    matriz[posicao.Linha, posicao.Coluna] = true;
                }

                posicao = new Posicao(Posicao.Linha, Posicao.Coluna);
                posicao.DefinirValores(posicao.Linha - 1, posicao.Coluna + 1);
                if (Tabuleiro.PosicaoValida(posicao) && ExisteInimigo(posicao)) {
                    matriz[posicao.Linha, posicao.Coluna] = true;
                }
            }
            else {
                posicao = new Posicao(Posicao.Linha, Posicao.Coluna);
                posicao.DefinirValores(posicao.Linha + 1, posicao.Coluna);
                if (Tabuleiro.PosicaoValida(posicao) && Livre(posicao)) {
                    matriz[posicao.Linha, posicao.Coluna] = true;
                }

                posicao = new Posicao(Posicao.Linha, Posicao.Coluna);
                posicao.DefinirValores(posicao.Linha + 2, posicao.Coluna);
                if (Tabuleiro.PosicaoValida(posicao) && Livre(posicao) && QteMovimentos == 0) {
                    matriz[posicao.Linha, posicao.Coluna] = true;
                }

                posicao = new Posicao(Posicao.Linha, Posicao.Coluna);
                posicao.DefinirValores(posicao.Linha + 1, posicao.Coluna - 1);
                if (Tabuleiro.PosicaoValida(posicao) && ExisteInimigo(posicao)) {
                    matriz[posicao.Linha, posicao.Coluna] = true;
                }

                posicao = new Posicao(Posicao.Linha, Posicao.Coluna);
                posicao.DefinirValores(posicao.Linha + 1, posicao.Coluna + 1);
                if (Tabuleiro.PosicaoValida(posicao) && ExisteInimigo(posicao)) {
                    matriz[posicao.Linha, posicao.Coluna] = true;
                }
            }

            return matriz;
        }
    }
}

