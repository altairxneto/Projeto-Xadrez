
namespace TabuleiroJogo {
    public abstract class Peca {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QteMovimentos { get; protected set; }
        public Tabuleiro Tabuleiro { get; protected set; }

        public Peca(Tabuleiro tabuleiro, Cor cor) {
            Posicao = null;
            Tabuleiro = tabuleiro;
            Cor = cor;
            QteMovimentos = 0;
        }

        public void IncrementarQuantidadeDeMovimentos() {
            QteMovimentos++;
        }

        public void DecrementarQuantidadeDeMovimentos() {
            QteMovimentos--;
        }

        public bool ExisteMovimentosPossiveis() {
            bool[,] matriz = MovimentosPossiveis();

            for(int linha = 0; linha < Tabuleiro.Linhas; linha++) {
                for(int coluna = 0; coluna < Tabuleiro.Colunas; coluna++) {
                    if (matriz[linha, coluna]) {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool PodeMoverPara(Posicao posicao) {
            return MovimentosPossiveis()[posicao.Linha, posicao.Coluna];
        }

        public abstract bool[,] MovimentosPossiveis();

    }
}
