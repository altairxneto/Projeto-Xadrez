
namespace TabuleiroJogo {
    public class Tabuleiro {
        public int Linhas { get; set; }
        public int Colunas { get; set; }

        private Peca[,] _pecas;

        public Tabuleiro(int linhas, int colunas) {
            Linhas = linhas;
            Colunas = colunas;
            _pecas = new Peca[linhas, colunas];
        }

        public Peca PecaTabuleiro(int linha, int coluna) {
            return _pecas[linha, coluna];
        }

        public Peca PecaTabuleiro(Posicao posicao) {
            return _pecas[posicao.Linha, posicao.Coluna];
        }

        public bool ExistePeca(Posicao posicao) {
            ValidarPosicao(posicao);

            return PecaTabuleiro(posicao) != null;
        }

        public void ColocarPeca(Peca peca, Posicao posicao) {
            if (ExistePeca(posicao)) {
                throw new TabuleiroException("Já existe uma peça nessa posição!");
            }

            _pecas[posicao.Linha, posicao.Coluna] = peca;
            peca.Posicao = posicao;
        }

        public Peca RetirarPeca(Posicao posicao) {
            if(PecaTabuleiro(posicao) == null) {
                return null;
            }

            Peca auxiliar = PecaTabuleiro(posicao);
            auxiliar.Posicao = null;

            _pecas[posicao.Linha, posicao.Coluna] = null;
            return auxiliar;
        }

        public bool PosicaoValida(Posicao posicao) {
            if(posicao.Linha < 0 || posicao.Linha >= Linhas || posicao.Coluna < 0 || posicao.Coluna >= Colunas) {
                return false;
            }
            return true;
        }

        public void ValidarPosicao(Posicao posicao) {
            if (!PosicaoValida(posicao)) {
                throw new TabuleiroException("Posição inválida");
            }
        }
    }
}
