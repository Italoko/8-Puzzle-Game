using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_Puzzle.Models
{
    public class Node 
    { 
        //Nó pai (ant)
        Node _parent;
        //Matriz tabuleiro
        int[,] _mat;// = new int[Constants.N, Constants.N];
        //Coordenadas do quadro em branco 
        int _x, _y;
        
        /*
         * F = Custo que é dado por G + H, onde: 
         * G = Nível da árvore ou custo que teve para percorrer até la(qtd de movimentos).
         * H = Resultado da função heuristica 
        */
        int _f,_g,_h;

        //Usado p/ A*
        public Node(Node parent, int[,] mat,int g,int h)
        {
            G = g;
            H = h;
            F = G + H;
            _parent = parent;
            Mat = mat;
            (_x,_y) = identifyBlankBoard();
        }

        //Usado p/ Best-First
        public Node(Node parent, int[,] mat, int h)
        {
            G = 0;
            H = h;
            F = G + H;
            _parent = parent;
            Mat = mat;
            (_x, _y) = identifyBlankBoard();
        }

        public Node()
        {}

        internal Node Parent { get => _parent; set => _parent = value; }
        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }
        public int F { get => _f; set => _f = value; }
        public int G { get => _g; set => _g = value; }
        public int H { get => _h; set => _h = value; }
        public int[,] Mat { get => _mat; set => _mat = value; }
        
        //Identifica o "quadro branco"
        private (int,int) identifyBlankBoard() 
        {
            for (int x = 0; x < Constants.N; x++)
            {
                for (int y = 0; y < Constants.N; y++)
                    if (Mat[x,y] == 0)
                        return (x, y);
            }
            return (-1, -1);
        }

        //Imprime a matriz.
        public void printBoard()
        {
            for (int x = 0; x < Constants.N; x++)
            {
                for (int y = 0; y < Constants.N; y++)
                    Console.Write(Mat[x,y]+" ");
                Console.WriteLine("");
            }
        }
    }
}
