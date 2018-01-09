using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServidorEDD
{
    public class NodoHash
    {
        NodoArbol usuario;
        int clave;

        public NodoHash(NodoArbol usuario, int clave)
        {
            Clave = clave;
            Usuario = usuario;
        }

        public int Clave
        {
            get { return clave; }
            set { clave = value; }
        }

        public NodoArbol Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }
    }
}