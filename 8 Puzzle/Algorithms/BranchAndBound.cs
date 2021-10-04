using _8_Puzzle.Models;
using _8_Puzzle.TAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_Puzzle.Algorithms
{
    class BranchAndBound : Operations
    {
        Node lowestCost;
        public SolutionStatistics solve(int[,] initial, int[,] goal)
        {
            PriorityQueue pq = new PriorityQueue();
            List<int[,]> closedList = new List<int[,]>();

            Node root = new Node(null, initial,1,0);
            int mov = 0;
            int qtdStates = 0;
            bool flag = false;
            int[,] matTemp;

            DateTime start = DateTime.Now;

            pq.enqueue(root);
            closedList.Add(root.Mat);
            while (!pq.isEmpty() && !flag && mov <= Constants.maxMovements)
            {
                lowestCost = pq.dequeue();

                if (equalsMat(lowestCost.Mat,goal)) //encontrou
                    flag = true;
                else
                {
                    for (int i = 0; i < 4; i++)
                        if (validatePosition(lowestCost.X + row[i], lowestCost.Y + col[i]))
                        {
                            matTemp = copyMat(lowestCost.Mat);
                            swap(matTemp, lowestCost.X, lowestCost.Y, lowestCost.X + row[i], lowestCost.Y + col[i]);
                            if (!contains(closedList, matTemp))
                            {
                                Node child = new Node(lowestCost, matTemp, lowestCost.G + Constants.Weight, 0);
                                pq.enqueue(child);
                                closedList.Add(child.Mat);
                            }
                            qtdStates++;
                        }
                    mov++;
                }
            }
            closedList.Add(goal);// add o ultimo estado.
            DateTime end = DateTime.Now; // fim da solução
            printPath(lowestCost);
            return new SolutionStatistics(start, end, mov, qtdStates, lowestCost);
        }
    }
}
