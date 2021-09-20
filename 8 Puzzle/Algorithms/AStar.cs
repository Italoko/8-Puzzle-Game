using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _8_Puzzle.Models;
using _8_Puzzle.TAD;

namespace _8_Puzzle.Algorithms
{
    class AStar : Operations   
    {
        Node lowestCost; // Variável p/ receber o node de menor estado.
        public AStar()
        {}
        
        // Resolução A*
        public void solve(int[,] initial, int[,] goal)
        {
            //Fila com prioridade para armazenar os nodos
            PriorityQueue pq = new PriorityQueue();
            List<int[,]> closedList = new List<int[,]>();

            Node root = new Node(null, initial,0,calculateCost(initial,goal)); //Node raiz
            int mov = 0;        // Quantidade de movimentações 
            bool flag = false; // Flag para verificar se encontrou ou não.
            int[,] matTemp;    // Cópia temporária da matriz
                              // bottom, left, top, right
            int[] row = new int[] { 1, 0, -1, 0 };
            int[] col = new int[] { 0, -1, 0, 1 };

            pq.enqueue(root);
            closedList.Add(root.Mat);
            while (!pq.isEmpty() && !flag && mov <= Constants.maxMovements)
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
                            if (!contains(closedList,matTemp))
                            {
                                Node child = new Node(lowestCost, matTemp, lowestCost.G + Constants.Weight, calculateCost(matTemp, goal));
                                pq.enqueue(child);
                                closedList.Add(child.Mat);
                            }
                        }
                mov++;
            }
            if (mov <= Constants.maxMovements)
            {
                printPath(lowestCost);
                Console.WriteLine($"Qtd. Movimentações:{mov}");
            }
            else
                Console.WriteLine($"Máximo de movimentações atingido:{Constants.maxMovements}| Qtd de mov: {mov}");
        }
    }
}
