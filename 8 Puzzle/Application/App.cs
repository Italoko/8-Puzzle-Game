using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _8_Puzzle.Algorithms;

namespace _8_Puzzle.Application
{
    class App
    {
        public void menu(int[,] initial, int[,] goal, int op)
        {
            switch(op)
            {
                case 1:
                    AStar astar = new AStar();
                    astar.solve(initial, goal);
                    break;
                case 2:
                    BestFirst bf = new BestFirst();
                    bf.solve(initial, goal);
                    break;
                case 3:
                    BranchAndBound bb = new BranchAndBound();
                    bb.solve(initial, goal);
                    break;
            }
        }
    }
}
