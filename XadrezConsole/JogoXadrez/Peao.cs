using TabuleiroJogo;

namespace JogoXadrez {
    class Peao : Peca {

        private PartidaDeXadrez _partida;
        public Peao(Tabuleiro tabuleiro, Cor cor, PartidaDeXadrez partida) : base(tabuleiro, cor) {
            _partida = partida;
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

                //#JogadaEspecial En passant

                posicao = new Posicao(Posicao.Linha, Posicao.Coluna);
                if (posicao.Linha == 3) {
                    Posicao esquerda = new Posicao(posicao.Linha, posicao.Coluna - 1);
                    if(Tabuleiro.PosicaoValida(esquerda) && ExisteInimigo(esquerda) && Tabuleiro.PecaTabuleiro(esquerda) == _partida.VulneravelEnPassant) {
                        matriz[esquerda.Linha - 1, esquerda.Coluna] = true;
                    }

                    Posicao direita = new Posicao(posicao.Linha, posicao.Coluna + 1);
                    if (Tabuleiro.PosicaoValida(direita) && ExisteInimigo(direita) && Tabuleiro.PecaTabuleiro(direita) == _partida.VulneravelEnPassant) {
                        matriz[direita.Linha - 1, direita.Coluna] = true;
                    }
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

                //#JogadaEspecial En passant
                posicao = new Posicao(Posicao.Linha, Posicao.Coluna);
                if (posicao.Linha == 4) {
                    Posicao esquerda = new Posicao(posicao.Linha, posicao.Coluna - 1);
                    if (Tabuleiro.PosicaoValida(esquerda) && ExisteInimigo(esquerda) && Tabuleiro.PecaTabuleiro(esquerda) == _partida.VulneravelEnPassant) {
                        matriz[esquerda.Linha + 1, esquerda.Coluna] = true;
                    }

                    Posicao direita = new Posicao(posicao.Linha, posicao.Coluna + 1);
                    if (Tabuleiro.PosicaoValida(direita) && ExisteInimigo(direita) && Tabuleiro.PecaTabuleiro(direita) == _partida.VulneravelEnPassant) {
                        matriz[direita.Linha + 1, direita.Coluna] = true;
                    }
                }
            }

            return matriz;
        }
    }
}

