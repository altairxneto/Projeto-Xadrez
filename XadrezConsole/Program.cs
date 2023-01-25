using System;
using TabuleiroJogo;
using XadrezConsole;
using JogoXadrez;

namespace Xadrez_Console {
    class Program {
        static void Main(string[] args) {
            try {
                Tabuleiro tabuleiro = new Tabuleiro(8, 8);

                tabuleiro.ColocarPeca(new Torre(tabuleiro, Cor.Preta), new Posicao(0, 0));
                tabuleiro.ColocarPeca(new Torre(tabuleiro, Cor.Preta), new Posicao(1, 3));
                tabuleiro.ColocarPeca(new Rei(tabuleiro, Cor.Preta), new Posicao(0, 2));

                tabuleiro.ColocarPeca(new Torre(tabuleiro, Cor.Branca), new Posicao(3, 5));

                Tela.ImprimirTabuleiro(tabuleiro);

                Console.ReadLine();
            }
            catch(TabuleiroException excecao) {
                Console.WriteLine(excecao.Message);
            }
            
        }
    }
}