using _8_Puzzle.Application;
using _8_Puzzle.Models;
using _8_Puzzle.TAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8_Puzzle
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //---------------------------------------------------------------------//
            //Estados do enunciado. 
            int[,] initial = new int[3, 3] { { 1, 2, 3 }, { 0, 4, 6 }, { 7, 5, 8 } };
            int[,] goal = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 0 } };

            //---------------------------------------------------------------------// 
            //Estados geeksforgeeks
            //int[,] initial = new int[3, 3] { { 1, 2, 3 }, { 5, 6, 0 }, { 7, 8, 4 } };
            //int[,] goal = new int[3, 3] { { 1, 2, 3 }, { 5, 8, 6 }, { 0, 7, 4 } };

            //---------------------------------------------------------------------// 
            //Estados ResearchGate
            //int[,] initial = new int[3, 3] { { 1, 2, 3 }, { 8, 0, 4 }, { 7, 6, 5 } };
            //int[,] goal = new int[3, 3] { { 2, 8, 1 }, { 0, 4, 3 }, { 7, 6, 5 } };

            //---------------------------------------------------------------------// 
            //Estados readthedocs.io
            //int[,] initial = new int[3, 3] { { 0, 1, 3 }, { 4, 2, 5 }, { 7, 8, 6 } };
            //int[,] goal = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 0 } };

            //int[,] initial = new int[3, 3] { { 3, 2, 1 }, { 6,5,4 }, { 8,7,0 } };
            //int[,] goal = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 0 } };


            App app = new App();
            Console.WriteLine("A*:");
            app.menu(initial, goal, 1);
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Best-First:");
            app.menu(initial, goal, 2);
            Console.WriteLine("Branch And Bound:");
            app.menu(initial, goal, 3);
        }
    }
}
