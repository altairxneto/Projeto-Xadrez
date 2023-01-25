using System;
using TabuleiroJogo;
using XadrezConsole;
using JogoXadrez;

namespace Xadrez_Console {
    class Program {
        static void Main(string[] args) {
            try {
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.Terminada) {
                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.Tabuleiro);

                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();

                    var pecaTabuleiro = partida.Tabuleiro.PecaTabuleiro(origem);

                    bool[,] posicoesPossiveis = pecaTabuleiro.MovimentosPossiveis();

                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.Tabuleiro, posicoesPossiveis);

                    Console.WriteLine();
                    Console.Write("Destino: ");
                    Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();

                    partida.ExecutarMovimento(origem, destino);
                }
            }
            catch (TabuleiroException excecao) {
                Console.WriteLine(excecao.Message);
            }

        }
    }
}