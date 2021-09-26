using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _8_Puzzle.Algorithms;
using _8_Puzzle.Models;

namespace _8_Puzzle.Menu
{
    class App
    {
        public SolutionStatistics menu(int[,] initial, int[,] goal, int op)
        {
            switch(op)
            {
                case 0:
                    AStar astar = new AStar();
                    return astar.solve(initial, goal);
                case 1:
                    BestFirst bf = new BestFirst();
                    return bf.solve(initial, goal);
                case 2:
                    BranchAndBound bb = new BranchAndBound();
                    return bb.solve(initial, goal);
            }
            return null;
        }
    }
}
