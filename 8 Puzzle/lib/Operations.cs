using _8_Puzzle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_Puzzle
{
    public abstract class Operations
    {
        // bottom, left, top, right
        public int[] row = new int[] { 1, 0, -1, 0 };
        public int[] col = new int[] { 0, -1, 0, 1 };

        //Calcula qtd de peças fora do lugar.
        public int calculateCost(int[,] initial, int[,] goal)
        {
            int count = 0;
            for (int x = 0; x < Constants.N; x++)
                for (int y = 0; y < Constants.N; y++)
                    if (initial[x, y] != goal[x, y] && initial[x, y] != 0)
                        count++;
            return count;
        }
        //Valida posição do quadro branco na matriz ( no ato de swap ) 
        public bool validatePosition(int x, int y)
        {
            if (x >= 0 && x < Constants.N && y >= 0 && y < Constants.N)
                return true;
            return false;
        }
        
        //Faz a troca do quadro branco com nova posição
        public void swap(int[,] mat, int x, int y, int newX, int newY)
        {
            int aux = mat[newX, newY];

            mat[newX, newY] = mat[x, y];
            mat[x, y] = aux;
        }
        // Faz cópia de matriz
        public int[,] copyMat(int[,] source)
        {
            int[,] destiny = new int[Constants.N, Constants.N];
            for (int x = 0; x < Constants.N; x++)
            {
                for (int y = 0; y < Constants.N; y++)
                    destiny[x, y] = source[x, y];
            }
            return destiny;
        }
        //retorna se uma matriz é igual a outra.
        public bool equalsMat(int[,] m1, int[,] m2)
        {
            int count = 0;
            for (int x = 0; x < Constants.N && count == 0; x++)
                for (int y = 0; y < Constants.N; y++)
                    if (m1[x, y] != m2[x, y])
                        count++;
            return count == 0;
        }
        //Verifica se esse estado(matriz) ja existe na lista fechada
        public bool contains(List<int[,]> closedList, int[,] matTemp)
        {
            foreach (int[,] mat in closedList)
                if (equalsMat(mat, matTemp))
                    return true;
            return false;
        }
        //Imprime o caminho feito até o objetivo final
        public void printPath(Node final)
        {
            if (final != null)
            {
                printPath(final.Parent);
                final.printBoard();
                Console.WriteLine("   ");
            }
        }
    }
}
