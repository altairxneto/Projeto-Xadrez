using System;
using TabuleiroJogo;
using XadrezConsole;

namespace Xadrez_Console {
    class Program {
        static void Main(string[] args) {
            Tabuleiro tabuleiro = new Tabuleiro(8, 8);

            Tela.ImprimirTabuleiro(tabuleiro);
        }
    }
}