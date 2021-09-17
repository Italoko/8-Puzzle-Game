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
            int[,] initial = new int[3, 3] { { 1, 2, 3 }, { 0, 4, 6 }, { 7, 5, 8 } };
            int[,] goal = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 0 } };
            App app = new App();
            app.menu(initial, goal, 1);
        }
    }
}
