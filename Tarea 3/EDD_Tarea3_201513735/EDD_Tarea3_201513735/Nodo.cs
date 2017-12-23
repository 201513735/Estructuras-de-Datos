using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDD_Tarea3_201513735
{
    class Nodo
    {
        int valor;
        Nodo izq, der;

        public Nodo(int valor)
        {
            this.Valor = valor;
            this.Izq = null;
            this.Der = null;
        }

        public Nodo Izq
        {
            get { return izq; }
            set { izq = value; }
        }

        public Nodo Der
        {
            get { return der; }
            set { der = value; }
        }

        public int Valor
        {
            get { return valor; }
            set { valor = value; }
        }
    }
}
