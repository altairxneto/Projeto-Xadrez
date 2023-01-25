using TabuleiroJogo;

namespace XadrezConsole {
    public class Tela {
        public static void ImprimirTabuleiro(Tabuleiro tabuleiro) {

            for(int linha = 0; linha < tabuleiro.Linhas; linha++) {
                Console.Write(8 - linha + " ");

                for(int coluna = 0; coluna < tabuleiro.Colunas; coluna++) {
                    if(tabuleiro.PecaTabuleiro(linha, coluna) == null) {
                        Console.Write("- ");
                    }
                    else {
                        ImprimirPeca(tabuleiro.PecaTabuleiro(linha, coluna));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }

            Console.Write("  A B C D E F G H");
        }

        public static void ImprimirPeca(Peca peca) {
            if(peca.Cor == Cor.Branca) {
                Console.Write(peca);
            }
            else {
                ConsoleColor aux = Console.ForegroundColor;

                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.Write(peca);

                Console.ForegroundColor = aux;
            }
        }
    }
}
