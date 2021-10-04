using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_Puzzle.Models
{
    public class SolutionStatistics
    {
        DateTime _start, _end;
        TimeSpan _temp;
        int _steps, pathSolutionSize, _differentStates;
        List<int[,]> _visiteds;
        List<string> _stepByStep;

        public SolutionStatistics(DateTime start, DateTime end, int steps, int differentStates,Node goal)
        {
            Start = start;
            End = end;
            Temp = end - start;
            Steps = steps;
            (Visiteds,StepByStep) = getPath(goal);
            PathSolutionSize = Visiteds.Count();
            DifferentStates = differentStates;
        }

        public DateTime Start { get => _start; set => _start = value; }
        public DateTime End { get => _end; set => _end = value; }
        public int Steps { get => _steps; set => _steps = value; }
        public int PathSolutionSize { get => pathSolutionSize; set => pathSolutionSize = value; }
        public int DifferentStates { get => _differentStates; set => _differentStates = value; }
        public List<int[,]> Visiteds { get => _visiteds; set => _visiteds = value; }
        public TimeSpan Temp { get => _temp; set => _temp = value; }
        public List<string> StepByStep { get => _stepByStep; set => _stepByStep = value; }

        private string getStep(int x, int y, int antX, int antY)
        {
            string changed = "Trocou com:";

             // bottom, left, top, right
             int[] row = new int[] { 1, 0, -1, 0 };
             int[] col = new int[] { 0, -1, 0, 1 };


            for (int i = 0; i < 4; i++)
                if (antX + row[i] == x && antY + col[i] == y)
                    switch (i)
                    {
                        case 0:
                            return changed + "Abaixo";
                        case 1:
                            return changed + "Esquerda";
                        case 2:
                            return changed + "Cima";
                        case 3:
                            return changed + "Direita";
                    }
            return "";
        }
        private (List<int[,]>,List<string>) getPath(Node node)
        {
            int antX, antY;
            List<int[,]> path = new List<int[,]>();
            List<string> sbs = new List<string>();
            
            while (node != null)
            {
                (antX, antY) = (node.X, node.Y);
                path.Add(node.Mat);
                node = node.Parent;
                if(node!=null)
                    sbs.Add(getStep(antX, antY,node.X, node.Y));
            }
            path.Reverse();
            sbs.Reverse();
            return (path,sbs);
        }
    }
}
