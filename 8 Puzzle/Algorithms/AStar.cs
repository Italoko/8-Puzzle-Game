using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _8_Puzzle.Models;
using _8_Puzzle.TAD;

namespace _8_Puzzle.Algorithms
{
    class AStar
    {
        Node lowestCost; // Variável p/ receber o node de menor estado.
        public AStar()
        {}
        //Calcula qtd de peças fora do lugar.
        private int calculateCost(int[,] initial, int[,] goal)
        {
            int count = 0;
            for (int x = 0; x < Constants.N; x++)
                for (int y = 0; y < Constants.N; y++)
                    if (initial[x, y] != goal[x, y] && initial[x, y] != 0)
                        count++;
            return (count);
        }
        //Valida posição do quadro branco na matriz ( no ato de swap ) 
        private bool validatePosition(int x, int y)
        {
            if (x >= 0 && x < Constants.N && y >= 0 && y < Constants.N)
                return true;
            return false;
        }
        //Faz a troca do quadro branco com nova posição
        private void swap(int[,]mat,int x,int y,int newX, int newY)
        {
            int aux = mat[newX, newY];

            mat[newX, newY] = mat[x, y];
            mat[x, y] = aux;
        }
        // Faz cópia de matriz
        private int[,] copyMat(int[,]source)
        {
            int[,] destiny = new int[Constants.N, Constants.N];
            for (int x = 0; x < Constants.N; x++)
            {
                for (int y = 0; y < Constants.N; y++)
                    destiny[x, y] = source[x, y];
            }
            return destiny;
        }
        //Imprime o caminho feito até o objetivo final
        public void printPath(Node final)
        {
            if (final != null)
            {                 
                printPath(final.Parent);
                final.printBoard();
                Console.WriteLine("-------------");
            }
        }
        // Resolução A*
        public void solve(int[,] initial, int[,] goal)
        {
            //Fila com prioridade para armazenar os nodos
            PriorityQueue pq = new PriorityQueue();
           
            Node root = new Node(null, initial,0,calculateCost(initial,goal)); //Node raiz
            bool flag = false; // Flag para verificar se encontrou ou não.
            int[,] matTemp;    // Cópia temporária da matriz
                              // bottom, left, top, right
            int[] row = new int[] { 1, 0, -1, 0 };
            int[] col = new int[] { 0, -1, 0, 1 };

            pq.enqueue(root);
            while (!pq.isEmpty() && !flag)
            {
                lowestCost = pq.dequeue();

                if (lowestCost.H == 0) //encontrou
                    flag = true;
                else
                    for (int i = 0; i < 4; i++) // até 4 filhos por node
                        if (validatePosition(lowestCost.X + row[i], lowestCost.Y + col[i]))
                        {
                            matTemp = copyMat(lowestCost.Mat);
                            swap(matTemp, lowestCost.X, lowestCost.Y, lowestCost.X + row[i], lowestCost.Y + col[i]);
                            Node child = new Node(lowestCost, matTemp, lowestCost.G + 1, calculateCost(matTemp, goal));

                            pq.enqueue(child);
                        }
            }
            printPath(lowestCost);
        }
    }
}
