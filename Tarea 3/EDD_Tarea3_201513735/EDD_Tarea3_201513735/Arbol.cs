using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDD_Tarea3_201513735
{
    class Arbol
    {
        Nodo raiz;
        String cadena;

        public Arbol()
        {
            this.Raiz = null;
        }

        public Nodo Raiz
        {
            get { return raiz; }
            set { raiz = value; }
        }

        public void Insertar(int val)
        {
            Nodo nuevo = new Nodo(val);
            if (this.Raiz == null)
            {
                this.Raiz = nuevo;
            }else
            {
                Recorrer(Raiz, nuevo);
            }
        }

        private void Recorrer(Nodo hoja, Nodo nuevo)
        {
            if (hoja.Valor < nuevo.Valor)
            {
                if (hoja.Der == null)
                {
                    hoja.Der = nuevo;
                }else
                {
                    Recorrer(hoja.Der, nuevo);
                }
            }else if (hoja.Valor > nuevo.Valor)
            {
                if (hoja.Izq == null)
                {
                    hoja.Izq = nuevo;
                }else
                {
                    Recorrer(hoja.Izq, nuevo);
                }
            }
        }

        public String PreOrden()
        {
            if (Raiz != null)
            {
                cadena = Raiz.Valor.ToString();
                recorrerPreOrden(Raiz.Izq);
                recorrerPreOrden(Raiz.Der);
            }

            cadena = cadena + "\n";

            return cadena;
        }

        private void recorrerPreOrden(Nodo n)
        {
            if (n != null)
            {
                cadena = cadena + ", " + n.Valor.ToString();
                recorrerPreOrden(n.Izq);
                recorrerPreOrden(n.Der);
            }
        }

        public String PostOrden()
        {
            cadena = "";
            if (Raiz != null)
            {
                recorrerPostOrden(Raiz.Izq);
                recorrerPostOrden(Raiz.Der);
                cadena = cadena + Raiz.Valor.ToString()+"\n";
            }

            return cadena;
        }

        private void recorrerPostOrden(Nodo n)
        {
            if (n != null)
            {
                recorrerPostOrden(n.Izq);
                recorrerPostOrden(n.Der);
                cadena = cadena + n.Valor.ToString() + ", ";
            }
        }

        public String InOrden()
        {
            cadena = "";
            if (Raiz != null)
            {
                recorrerInOrden(Raiz.Izq);
                cadena = cadena + Raiz.Valor.ToString() + ", ";
                recorrerInOrden(Raiz.Der);
            }

            return cadena;
        }

        private void recorrerInOrden(Nodo n)
        {
            if (n != null)
            {
                recorrerInOrden(n.Izq);
                cadena = cadena + n.Valor.ToString() + ", ";
                recorrerInOrden(n.Der);
            }
        }
    }
}
