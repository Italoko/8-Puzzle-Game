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

        public SolutionStatistics(DateTime start, DateTime end, int steps, int differentStates,Node goal)
        {
            Start = start;
            End = end;
            Temp = end - start;
            Steps = steps;
            Visiteds = getPath(goal);
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
        private List<int[,]> getPath(Node node)
        {
            List<int[,]> path = new List<int[,]>();
            while(node != null)
            {
                path.Add(node.Mat);
                node = node.Parent;
            }
            path.Reverse();
            return path;
        }
    }
}
