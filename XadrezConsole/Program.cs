using System;
using TabuleiroJogo;
using XadrezConsole;
using JogoXadrez;

namespace Xadrez_Console {
    class Program {
        static void Main(string[] args) {
            PosicaoXadrez posicao = new PosicaoXadrez('c', 7);

            Console.WriteLine(posicao);
            Console.WriteLine(posicao.ToPosicao());
        }
    }
}