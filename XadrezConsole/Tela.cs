using TabuleiroJogo;

namespace XadrezConsole {
    public class Tela {
        public static void ImprimirTabuleiro(Tabuleiro tabuleiro) {

            for(int linha = 0; linha < tabuleiro.Linhas; linha++) {
                for(int coluna = 0; coluna < tabuleiro.Colunas; coluna++) {
                    if(tabuleiro.PecaTabuleiro(linha, coluna) == null) {
                        Console.Write("- ");
                    }
                    else {
                        Console.Write(tabuleiro.PecaTabuleiro(linha, coluna) + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
