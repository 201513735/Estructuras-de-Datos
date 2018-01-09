using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServidorEDD
{
    public class HojaB
    {

        HojaB padre;
        NodoB[] nodos;
        int k;

        public HojaB(int k)
        {
            this.k = k;
            Nodos = new NodoB[k];
            for (int i = 0; i < k; i++)
            {
                Nodos[i] = null;
            }
            Padre = null;
        }

        public void Insertar(NodoB nuevo)
        {
            int i = 0, j = 0;
            NodoB[] aux = new NodoB[k];
            while (i < k)
            {
                if (Nodos[j] != null)
                {
                    if (j < i)
                    {
                        aux[i] = Nodos[j];
                        j++;
                    }
                    else if (String.Compare(nuevo.Id, Nodos[j].Id) < 0)
                    {
                        aux[i] = nuevo;
                    }else
                    {
                        aux[i] = Nodos[j];
                        j++;
                    }
                }else if(i==j)
                {
                    aux[i] = nuevo;
                }
                else
                {
                    aux[i] = null;
                }
                i++;
            }

            Nodos = aux;
        }

        public NodoB[] Nodos
        {
            get { return nodos; }
            set { nodos = value; }
        }

        public HojaB Padre
        {
            get { return padre; }
            set { padre = value; }
        }
    }
}