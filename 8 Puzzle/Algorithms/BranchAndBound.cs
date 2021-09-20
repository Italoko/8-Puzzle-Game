﻿using _8_Puzzle.Models;
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
        public void solve(int[,] initial, int[,] goal)
        {
            PriorityQueue pq = new PriorityQueue();
            List<int[,]> closedList = new List<int[,]>();

            Node root = new Node() {Parent = null,Mat=initial, G = 0,F=0};
            int mov = 0;
            bool flag = false;
            int[,] matTemp;
            // bottom, left, top, right
            int[] row = new int[] { 1, 0, -1, 0 };
            int[] col = new int[] { 0, -1, 0, 1 };

            pq.enqueue(root);
            closedList.Add(root.Mat);
            while (!pq.isEmpty() && !flag && mov <= Constants.maxMovements)
            {
                lowestCost = pq.dequeue();
                if(!equalsMat(lowestCost.Mat,goal))
                    for (int i = 0; i < 4; i++)
                        if (validatePosition(lowestCost.X + row[i], lowestCost.Y + col[i]))
                        {
                            matTemp = copyMat(lowestCost.Mat);
                            swap(matTemp, lowestCost.X, lowestCost.Y, lowestCost.X + row[i], lowestCost.Y + col[i]);
                            if (!contains(closedList, matTemp))
                            {
                                Node child = new Node()
                                {
                                    Parent = lowestCost,
                                    Mat = matTemp,
                                    G = lowestCost.G + Constants.Weight,
                                    F = lowestCost.G + Constants.Weight,
                                    H = 0
                                };
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
