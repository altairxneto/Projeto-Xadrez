using TabuleiroJogo;
using System.Collections.Generic;

namespace JogoXadrez {
    public class PartidaDeXadrez {
        public Tabuleiro Tabuleiro { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Terminada { get; private set; }
        private HashSet<Peca> _pecas;
        private HashSet<Peca> _capturadas;

        public PartidaDeXadrez() {
            Tabuleiro = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Terminada = false;
            _pecas = new HashSet<Peca>();
            _capturadas = new HashSet<Peca>();
            ColocarPecas();
        }

        public void ExecutarMovimento(Posicao origem, Posicao destino) {
            Peca peca = Tabuleiro.RetirarPeca(origem);
            peca.IncrementarQuantidadeDeMovimentos();

            Peca pecaCapturada = Tabuleiro.RetirarPeca(destino);

            Tabuleiro.ColocarPeca(peca, destino);

            if(pecaCapturada != null) {
                _capturadas.Add(pecaCapturada);
            }
        }

        public void RealizaJogada(Posicao origem, Posicao destino) {
            ExecutarMovimento(origem, destino);
            Turno++;
            MudaJogador();
        }

        public void ValidarPosicaoDeOrigem(Posicao posicao) {
            if(Tabuleiro.PecaTabuleiro(posicao) == null) {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
            }

            if(JogadorAtual != Tabuleiro.PecaTabuleiro(posicao).Cor) {
                throw new TabuleiroException("A peça de origem escolhida não é sua!");
            }

            if (!Tabuleiro.PecaTabuleiro(posicao).ExisteMovimentosPossiveis()) {
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida!");
            }
        }

        public void ValidarPosicaoDeDestino(Posicao origem, Posicao destino) {
            if (!Tabuleiro.PecaTabuleiro(origem).PodeMoverPara(destino)) {
                throw new TabuleiroException("Posição de destino inválida!");
            }
        }

        private void MudaJogador() {
            if(JogadorAtual == Cor.Branca) {
                JogadorAtual = Cor.Preta;
            }
            else {
                JogadorAtual = Cor.Branca;
            }
        }

        public HashSet<Peca> pecasCapturadas(Cor cor) {
            HashSet<Peca> auxiliar = new HashSet<Peca>();
            foreach(Peca x in _capturadas) {
                if(x.Cor == cor) {
                    auxiliar.Add(x);
                }
            }
            return auxiliar;
        }

        public HashSet<Peca> PecasEmJogo(Cor cor) {
            HashSet<Peca> auxiliar = new HashSet<Peca>();

            foreach(Peca x in _pecas) {
                if(x.Cor == cor) {
                    auxiliar.Add(x);
                }
            }
            auxiliar.ExceptWith(pecasCapturadas(cor));
            
            return auxiliar;
        }

        public void ColocarNovaPeca(char coluna, int linha, Peca peca) {
            Tabuleiro.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
            _pecas.Add(peca);
        }

        private void ColocarPecas() {
            ColocarNovaPeca('c', 1, new Torre(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('c', 2, new Torre(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('d', 2, new Torre(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('e', 2, new Torre(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('e', 1, new Torre(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('d', 1, new Rei(Tabuleiro, Cor.Branca));

            ColocarNovaPeca('c', 7, new Torre(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('c', 8, new Torre(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('d', 7, new Torre(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('e', 7, new Torre(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('e', 8, new Torre(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('d', 8, new Rei(Tabuleiro, Cor.Preta));
        }
    }
}
