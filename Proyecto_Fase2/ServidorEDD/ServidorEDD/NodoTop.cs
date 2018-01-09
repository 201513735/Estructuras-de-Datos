using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServidorEDD
{
    public class NodoTop
    {
        int cantidad;
        String nickname;
        NodoTop siguiente, anterior;

        public NodoTop(int cantidad, String nickname)
        {
            Cantidad = cantidad;
            Nickname = nickname;
            Anterior = null;
            Siguiente = null;
        }

        public NodoTop Anterior
        {
            get { return anterior; }
            set { anterior = value; }
        }

        public NodoTop Siguiente
        {
            get { return siguiente; }
            set { siguiente = value; }
        }

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public String Nickname
        {
            get { return nickname; }
            set { nickname = value; }
        }
    }
}