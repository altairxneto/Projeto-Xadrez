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
        public bool Xeque { get; private set; }
        public Peca VulneravelEnPassant { get; private set; }

        public PartidaDeXadrez() {
            Tabuleiro = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Terminada = false;
            Xeque = false;
            VulneravelEnPassant = null;
            _pecas = new HashSet<Peca>();
            _capturadas = new HashSet<Peca>();
            ColocarPecas();
        }

        public Peca ExecutarMovimento(Posicao origem, Posicao destino) {
            Peca peca = Tabuleiro.RetirarPeca(origem);
            peca.IncrementarQuantidadeDeMovimentos();

            Peca pecaCapturada = Tabuleiro.RetirarPeca(destino);

            Tabuleiro.ColocarPeca(peca, destino);

            if(pecaCapturada != null) {
                _capturadas.Add(pecaCapturada);
            }

            //#JogadaEspecial roque pequeno

            if(peca is Rei && destino.Coluna == origem.Coluna + 2) {
                Posicao origemTorre = new Posicao(origem.Linha, origem.Coluna + 3);
                Posicao destinoTorre = new Posicao(origem.Linha, origem.Coluna + 1);

                Peca torr = Tabuleiro.RetirarPeca(origemTorre);
                torr.IncrementarQuantidadeDeMovimentos();

                Tabuleiro.ColocarPeca(torr, destinoTorre);
            }

            //#JogadaEspecial roque grande

            if (peca is Rei && destino.Coluna == origem.Coluna - 2) {
                Posicao origemTorre = new Posicao(origem.Linha, origem.Coluna - 4);
                Posicao destinoTorre = new Posicao(origem.Linha, origem.Coluna - 1);

                Peca torr = Tabuleiro.RetirarPeca(origemTorre);
                torr.IncrementarQuantidadeDeMovimentos();

                Tabuleiro.ColocarPeca(torr, destinoTorre);
            }

            //#JogadaEspecial En passant

            if(peca is Peao) {
                if(origem.Coluna != destino.Coluna && pecaCapturada == null) {
                    Posicao posicaoP;

                    if(peca.Cor == Cor.Branca) {
                        posicaoP = new Posicao(destino.Linha + 1, destino.Coluna);
                    }
                    else {
                        posicaoP = new Posicao(destino.Linha - 1, destino.Coluna);
                    }
                    pecaCapturada = Tabuleiro.RetirarPeca(posicaoP);
                    _capturadas.Add(pecaCapturada);
                }
            }

            return pecaCapturada;
        }

        public void DesfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada) {
            Peca peca = Tabuleiro.RetirarPeca(destino);
            peca.DecrementarQuantidadeDeMovimentos();

            if(pecaCapturada != null) {
                Tabuleiro.ColocarPeca(pecaCapturada, destino);
                _capturadas.Remove(pecaCapturada);
            }
            
            Tabuleiro.ColocarPeca(peca, origem);

            //#JogadaEspecial roque pequeno

            if (peca is Rei && destino.Coluna == origem.Coluna + 2) {
                Posicao origemTorre = new Posicao(origem.Linha, origem.Coluna + 3);
                Posicao destinoTorre = new Posicao(origem.Linha, origem.Coluna + 1);

                Peca torr = Tabuleiro.RetirarPeca(destinoTorre);
                torr.DecrementarQuantidadeDeMovimentos();

                Tabuleiro.ColocarPeca(torr, origemTorre);
            }

            //#JogadaEspecial roque grande

            if (peca is Rei && destino.Coluna == origem.Coluna - 2) {
                Posicao origemTorre = new Posicao(origem.Linha, origem.Coluna - 4);
                Posicao destinoTorre = new Posicao(origem.Linha, origem.Coluna - 1);

                Peca torr = Tabuleiro.RetirarPeca(destinoTorre);
                torr.DecrementarQuantidadeDeMovimentos();

                Tabuleiro.ColocarPeca(torr, origemTorre);
            }

            //#JogadaEspecial En passant

            if(peca is Peao) {
                if(origem.Coluna != destino.Coluna && pecaCapturada == VulneravelEnPassant) {
                    Peca peao = Tabuleiro.RetirarPeca(destino);

                    Posicao posicaoP;

                    if(peca.Cor == Cor.Branca) {
                        posicaoP = new Posicao(3, destino.Coluna);
                    }
                    else {
                        posicaoP = new Posicao(4, destino.Coluna);
                    }

                    Tabuleiro.ColocarPeca(peao, posicaoP);
                }
            }
        }

        public void RealizaJogada(Posicao origem, Posicao destino) {
            Peca pecaCapturada = ExecutarMovimento(origem, destino);

            if (EstaEmCheque(JogadorAtual)) {
                DesfazMovimento(origem, destino, pecaCapturada);

                throw new TabuleiroException("Você não pode se colocar em cheque!");
            }

            Peca peca = Tabuleiro.PecaTabuleiro(destino);

            //#JogadaEspecial Promocao

            if(peca is Peao) {
                if((peca.Cor == Cor.Branca && destino.Linha == 0) || (peca.Cor == Cor.Preta && destino.Linha == 7)) {
                    peca = Tabuleiro.RetirarPeca(destino);

                    _pecas.Remove(peca);

                    Peca dama = new Dama(Tabuleiro, peca.Cor);
                    Tabuleiro.ColocarPeca(dama, destino);

                    _pecas.Add(dama);
                }
            }

            if (EstaEmCheque(Adversaria(JogadorAtual))) {
                Xeque = true;
            }
            else {
                Xeque = false;
            }

            if (TesteXequemate(Adversaria(JogadorAtual))) {
                Terminada = true;
            }
            else {
                Turno++;
                MudaJogador();
            }

            //#JogadaEspecial En passant

            if(peca is Peao && (destino.Linha == origem.Linha - 2 || destino.Linha == origem.Linha + 2)) {
                VulneravelEnPassant = peca;
            }
            else {
                VulneravelEnPassant = null;
            }
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
            if (!Tabuleiro.PecaTabuleiro(origem).MovimentoPossivel(destino)) {
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

        private Cor Adversaria(Cor cor) {
            if(cor == Cor.Branca) {
                return Cor.Preta;
            }
            else {
                return Cor.Branca;
            }
        }

        private Peca Reii (Cor cor) {
            foreach(Peca peca in PecasEmJogo(cor)) {
                if(peca is Rei) {
                    return peca;
                }
            }
            return null;
        }

        public bool EstaEmCheque(Cor cor) {
            Peca R = Reii(cor);

            if(R == null) {
                throw new TabuleiroException("Não tem rei da cor " + cor + " no tabuleiro!");
            }

            foreach(Peca x in PecasEmJogo(Adversaria(cor))) {
                bool[,] matriz = x.MovimentosPossiveis();

                if (matriz[R.Posicao.Linha, R.Posicao.Coluna]) {
                    return true;
                }
            }
            return false;
        }

        public bool TesteXequemate(Cor cor) {
            if (!EstaEmCheque(cor)) {
                return false;
            }

            foreach(Peca peca in PecasEmJogo(cor)) {
                bool[,] matriz = peca.MovimentosPossiveis();

                for(int linha = 0; linha < Tabuleiro.Linhas; linha++) {
                    for(int coluna = 0; coluna < Tabuleiro.Colunas; coluna++) {
                        if (matriz[linha, coluna]) {
                            Posicao origem = peca.Posicao;
                            Posicao destino = new Posicao(linha, coluna);

                            Peca pecaCapturada = ExecutarMovimento(origem, destino);
                            bool testeXeque = EstaEmCheque(cor);

                            DesfazMovimento(origem, destino, pecaCapturada);

                            if(!testeXeque) {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public void ColocarNovaPeca(char coluna, int linha, Peca peca) {
            Tabuleiro.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
            _pecas.Add(peca);
        }

        private void ColocarPecas() {
            ColocarNovaPeca('a', 1, new Torre(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('b', 1, new Cavalo(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('c', 1, new Bispo(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('d', 1, new Dama(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('e', 1, new Rei(Tabuleiro, Cor.Branca, this));
            ColocarNovaPeca('f', 1, new Bispo(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('g', 1, new Cavalo(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('h', 1, new Torre(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('a', 2, new Peao(Tabuleiro, Cor.Branca, this));
            ColocarNovaPeca('b', 2, new Peao(Tabuleiro, Cor.Branca, this));
            ColocarNovaPeca('c', 2, new Peao(Tabuleiro, Cor.Branca, this));
            ColocarNovaPeca('d', 2, new Peao(Tabuleiro, Cor.Branca, this));
            ColocarNovaPeca('e', 2, new Peao(Tabuleiro, Cor.Branca, this));
            ColocarNovaPeca('f', 2, new Peao(Tabuleiro, Cor.Branca, this));
            ColocarNovaPeca('g', 2, new Peao(Tabuleiro, Cor.Branca, this));
            ColocarNovaPeca('h', 2, new Peao(Tabuleiro, Cor.Branca, this));

            ColocarNovaPeca('a', 8, new Torre(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('b', 8, new Cavalo(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('c', 8, new Bispo(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('d', 8, new Dama(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('e', 8, new Rei(Tabuleiro, Cor.Preta, this));
            ColocarNovaPeca('f', 8, new Bispo(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('g', 8, new Cavalo(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('h', 8, new Torre(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('a', 7, new Peao(Tabuleiro, Cor.Preta, this));
            ColocarNovaPeca('b', 7, new Peao(Tabuleiro, Cor.Preta, this));
            ColocarNovaPeca('c', 7, new Peao(Tabuleiro, Cor.Preta, this));
            ColocarNovaPeca('d', 7, new Peao(Tabuleiro, Cor.Preta, this));
            ColocarNovaPeca('e', 7, new Peao(Tabuleiro, Cor.Preta, this));
            ColocarNovaPeca('f', 7, new Peao(Tabuleiro, Cor.Preta, this));
            ColocarNovaPeca('g', 7, new Peao(Tabuleiro, Cor.Preta, this));
            ColocarNovaPeca('h', 7, new Peao(Tabuleiro, Cor.Preta, this));
        }
    }
}
