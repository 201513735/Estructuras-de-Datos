using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServidorEDD
{
    public class TablaHash
    {
        NodoHash[] tabla;
        int densidad;
        int elementos;

        public TablaHash(int k)
        {
            Tabla = new NodoHash[k];
            Densidad = 0;
            elementos = 0;
            for(int i=0; i < k; i++)
            {
                Tabla[i] = null;
            }
        }

        public int Plegamiento(String nick)
        {
            int clave = 0;
            Char[] a = nick.ToCharArray();
            for(int i = 0; i < a.Length; i++)
            {
                clave = clave + Convert.ToInt32(a[i]);
            }
            return clave;
        }

        public int Modular(int clave)
        {
            return clave % Tabla.Length;
        }

        public void Insertar(NodoArbol n)
        {
            NodoHash nuevo = new NodoHash(n, Plegamiento(n.NickName));
            int c = Modular(nuevo.Clave);
            if (Tabla[c] == null)
            {
                Tabla[c] = nuevo;
                elementos++;
            }else
            {
                int i = 1;
                while (Tabla[c] != null)
                {
                    c = Modular(nuevo.Clave + i ^ 2);
                    i++;
                }

                Tabla[c] = nuevo;
                elementos++;
            }

            densidad = (elementos / Tabla.Length) * 100;
            if (densidad >= 50)
            {
                Agrandar();
            }
        }

        public void Agrandar()
        {
            TablaHash t = new TablaHash(Tabla.Length * 2);
            for(int i = 0; i < Tabla.Length; i++)
            {
                if (Tabla[i] != null)
                {
                    t.Insertar(Tabla[i].Usuario);
                }
            }
            Tabla = t.Tabla;
            Densidad = t.Densidad;
        }

        public NodoHash[] Tabla
        {
            get { return tabla; }
            set { tabla = value; }
        }

        public int Densidad
        {
            get { return densidad; }
            set { densidad = value; }
        }
    }
}