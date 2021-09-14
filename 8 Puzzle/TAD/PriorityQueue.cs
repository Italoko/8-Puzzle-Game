using _8_Puzzle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_Puzzle.TAD
{
    class PriorityQueue
    {
        PriorityQueue _inicio;
        Node _node;
        PriorityQueue _prox;

        public PriorityQueue()
        {}
        
        public bool isEmpty()
        {
            return Inicio == null;
        }
        public void enqueue(Node node)
        {
            PriorityQueue newPq = new PriorityQueue() { Node = node };

            if (isEmpty())
                Inicio = newPq;
            else
            {
                if (node.F < Inicio.Node.F)
                {
                    newPq.Prox = Inicio;
                    Inicio = newPq;
                }
                else
                {
                    PriorityQueue aux = Inicio;
                    while (aux.Prox != null && aux.Prox.Node.F <= node.F)
                        aux = aux.Prox;
                    newPq.Prox = aux.Prox;
                    aux.Prox = newPq;
                }
            }
        }
        public Node dequeue()
        {
            Node aux = Inicio.Node;
            if (!isEmpty())
                Inicio = Inicio.Prox;
            return aux;
        }

        internal PriorityQueue Inicio { get => _inicio; set => _inicio = value; }
        internal Node Node { get => _node; set => _node = value; }
        internal PriorityQueue Prox { get => _prox; set => _prox = value; }
    }
}
