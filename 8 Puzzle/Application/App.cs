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
                    //OutroAlgoritmo(initial, goal);
                    break;
            }
        }
    }
}
