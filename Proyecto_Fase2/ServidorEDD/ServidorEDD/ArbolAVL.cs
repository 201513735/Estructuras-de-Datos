using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServidorEDD
{
    public class ArbolAVL
    {
        NodoAVL raiz;

        public ArbolAVL()
        {
            Raiz = null;
        }

        public NodoAVL Raiz
        {
            get { return raiz; }
            set { raiz = value; }
        }

        public void Insertar(NodoArbol jugador)
        {
            NodoAVL nuevo = new NodoAVL(jugador);
            if (Raiz == null)
            {
                Raiz = nuevo;
            }else
            {
                comparar(Raiz, nuevo);
            }
            Raiz=equilibrar(Raiz);
        }

        public void Insertar(String nickname, String contraseña, String correo)
        {
            NodoAVL nuevo = new NodoAVL(nickname, correo, contraseña);
            if (Raiz == null)
            {
                Raiz = nuevo;
            }else
            {
                comparar(Raiz, nuevo);
            }
            Raiz=equilibrar(Raiz);
        }

        private void comparar(NodoAVL hoja, NodoAVL nuevo)
        {
            if (String.Compare(hoja.Nickname, nuevo.Nickname) < 0)
            {
                if (hoja.Derecha == null)
                {
                    hoja.Derecha = nuevo;
                    nuevo.Padre = hoja;
                }
                else
                {
                    comparar(hoja.Derecha, nuevo);
                }
            }
            else if (String.Compare(hoja.Nickname, nuevo.Nickname) > 0)
            {
                if (hoja.Izquierda == null)
                {
                    hoja.Izquierda = nuevo;
                    nuevo.Padre = hoja;
                }
                else
                {
                    comparar(hoja.Izquierda, nuevo);
                }
            }
        }

        public NodoAVL equilibrar(NodoAVL nodo)
        {
            if (nodo.Izquierda != null)
            {
                nodo.Izquierda = equilibrar(nodo.Izquierda);
            }
            if (nodo.Derecha != null)
            {
                nodo.Derecha = equilibrar(nodo.Derecha);
            }

            nodo.Fe = altura(nodo.Derecha) - altura(nodo.Izquierda);

            if (nodo.Fe <= -2)
            {
                if (nodo.Izquierda.Fe >= 1)
                {
                    nodo = dobleDerecha(nodo);
                }
                else
                {
                    nodo = simpleDerecha(nodo);
                }
            }
            else if (nodo.Fe >= 2)
            {
                if (nodo.Derecha.Fe <= -1)
                {
                    nodo = dobleIzquierda(nodo);
                }
                else
                {
                    nodo = simpleIzquierda(nodo);
                }
            }
            return nodo;
        }

        private int altura(NodoAVL n)
        {
            if (n == null)
            {
                return 0;
            }
            else
            {
                return 1+ maximo(altura(n.Derecha),altura(n.Izquierda));
            }
        }

        private int maximo(int a, int b)
        {
            if (a < b)
            {
                return a;
            }else
            {
                return b;
            }
        }

        private NodoAVL simpleIzquierda(NodoAVL nodo)
        {
            NodoAVL Padre = nodo.Padre;
            NodoAVL P = nodo;
            NodoAVL Q = P.Derecha;
            NodoAVL B = Q.Izquierda;

            if (Padre != null)
            {
                if (Padre.Derecha == P)
                {
                    Padre.Derecha = Q;
                }
                else
                {
                    Padre.Izquierda = Q;
                }
            }
            else
            {
                this.Raiz = Q;
            }

            P.Derecha = B;
            Q.Izquierda = P;

            P.Padre = Q;
            if (B != null)
            {
                B.Padre = P;
            }
            Q.Padre = Padre;

            P.Fe = 0;
            Q.Fe = 0;

            return Q;
        }

        private NodoAVL dobleIzquierda(NodoAVL nodo)
        {
            NodoAVL Padre = nodo.Padre;
            NodoAVL P = nodo;
            NodoAVL Q = P.Derecha;
            NodoAVL R = Q.Izquierda;
            NodoAVL B = R.Izquierda;
            NodoAVL C = R.Derecha;

            if (Padre != null)
            {
                if (Padre.Derecha == P)
                {
                    Padre.Derecha = R;
                }
                else
                {
                    Padre.Izquierda = R;
                }
            }
            else
            {
                Raiz = R;
            }

            Q.Izquierda = C;
            P.Derecha = B;
            R.Izquierda = P;
            R.Derecha = Q;

            R.Padre = Padre;
            P.Padre = Q.Padre = R;

            if (B != null)
            {
                B.Padre = P;
            }
            if (C != null)
            {
                C.Padre = Q;
            }
            switch (R.Fe)
            {
                case -1: Q.Fe = 0; P.Fe = 1; break;
                case 0: Q.Fe = 0; P.Fe = 0; break;
                case 1: Q.Fe = -1; P.Fe = 0; break;
            }
            R.Fe = 0;
            return R;
        }

        private NodoAVL simpleDerecha(NodoAVL nodo)
        {
            NodoAVL Padre = nodo.Padre;
            NodoAVL P = nodo;
            NodoAVL Q = P.Izquierda;
            NodoAVL B = Q.Derecha;

            if (Padre != null)
            {
                if (Padre.Derecha == P)
                {
                    Padre.Derecha = Q;
                }
                else
                {
                    Padre.Izquierda = Q;
                }
            }
            else
            {
                Raiz = Q;
            }

            P.Izquierda = B;
            Q.Derecha = P;

            P.Padre = Q;
            if (B != null)
            {
                B.Padre = P;
            }
            Q.Padre = Padre;

            P.Fe = 0;
            Q.Fe = 0;

            return Q;
        }

        private NodoAVL dobleDerecha(NodoAVL nodo)
        {
            NodoAVL Padre = nodo.Padre;
            NodoAVL P = nodo;
            NodoAVL Q = P.Izquierda;
            NodoAVL R = Q.Derecha;
            NodoAVL B = R.Izquierda;
            NodoAVL C = R.Derecha;

            if (Padre != null)
            {
                if (Padre.Derecha == P)
                {
                    Padre.Derecha = R;
                }
                else
                {
                    Padre.Izquierda = R;
                }
            }
            else
            {
                Raiz = R;
            }

            Q.Derecha = B;
            P.Izquierda = C;
            R.Izquierda = Q;
            R.Derecha = P;

            R.Padre = Padre;
            P.Padre = Q.Padre = R;

            if (B != null)
            {
                B.Padre = Q;
            }
            if (C != null)
            {
                C.Padre = P;
            }
            switch (R.Fe)
            {
                case -1: Q.Fe = 0; P.Fe = 1; break;
                case 0: Q.Fe = 0; P.Fe = 0; break;
                case 1: Q.Fe = -1; P.Fe = 0; break;
            }
            R.Fe = 0;

            return R;
        }

        public NodoAVL Buscar(String nickname, NodoAVL n)
        {
            if (n != null)
            {
                if (String.Compare(n.Nickname, nickname) == 0)
                {
                    return n;
                }
                else if (String.Compare(n.Nickname, nickname) < 0)
                {
                    if (n.Derecha != null)
                    {
                        return Buscar(nickname, n.Derecha);
                    }
                    else
                    {
                        return null;
                    }

                }
                else if (String.Compare(n.Nickname, nickname) > 0)
                {
                    if (n.Izquierda != null)
                    {
                        return Buscar(nickname, n.Izquierda);
                    }
                    else
                    {
                        return null;
                    }
                }
                else { return null; }
            }
            else
            {
                return null;
            }
        }

        public void Eliminar(String nickname)
        {
            NodoAVL n = Buscar(nickname, Raiz);
            if (n != null)
            {
                if (n.Derecha == null && n.Izquierda == null)
                {
                    if (n == this.Raiz)
                    {
                        this.Raiz = null;
                    }
                    else
                    {
                        if (n.Padre.Derecha == n)
                        {
                            n.Padre.Derecha = null;
                        }
                        else
                        {
                            n.Padre.Izquierda = null;
                        }
                    }
                }
                else if (n.Derecha == null && n.Izquierda != null)
                {
                    if (n.Padre == null)
                    {
                        this.Raiz = n.Izquierda;
                    }
                    else
                    {
                        if (n.Padre.Derecha == n)
                        {
                            n.Padre.Derecha = n.Izquierda;
                        }
                        else
                        {
                            n.Padre.Izquierda = n.Izquierda;
                        }
                    }
                }
                else if (n.Derecha != null & n.Izquierda == null)
                {
                    if (n.Padre == null)
                    {
                        this.Raiz = n.Derecha;
                    }
                    else
                    {
                        if (n.Padre.Derecha == n)
                        {
                            n.Padre.Derecha = n.Derecha;
                        }
                        else
                        {
                            n.Padre.Izquierda = n.Derecha;
                        }
                    }
                }
                else
                {
                    //AMBOS NODOS ESTAN LLENOS
                    NodoAVL aux = n.Derecha;
                    while (aux.Izquierda != null)
                    {
                        aux = aux.Izquierda;
                    }
                    if (aux.Derecha != null)
                    {
                        if (aux.Padre != n)
                        {
                            aux.Padre.Izquierda = aux.Derecha;
                            aux.Derecha.Padre = aux.Padre;
                        }
                        else
                        {
                            aux.Padre.Derecha = aux.Derecha;
                            aux.Derecha.Padre = aux.Padre;
                        }
                    }
                    else
                    {
                        if (aux.Padre != n)
                        {
                            aux.Padre.Izquierda = null;
                        }
                        else
                        {
                            aux.Padre.Derecha = null;
                        }

                    }
                    //Si el nodo a eliminar es la Raiz
                    if (n.Padre == null)
                    {
                        Raiz = aux;
                        aux.Padre = null;
                        aux.Izquierda = n.Izquierda;
                        aux.Derecha = n.Derecha;
                        if (n.Izquierda != null)
                        {
                            n.Izquierda.Padre = aux;
                        }

                        if (n.Derecha != null)
                        {
                            n.Derecha.Padre = aux;
                        }
                    }
                    else
                    {
                        aux.Izquierda = n.Izquierda;
                        aux.Derecha = n.Derecha;
                        if (n.Izquierda != null)
                        {
                            n.Izquierda.Padre = aux;
                        }

                        if (n.Derecha != null)
                        {
                            n.Derecha.Padre = aux;
                        }

                        if (n.Padre.Derecha == n)
                        {
                            n.Padre.Derecha = aux;
                        }
                        else
                        {
                            n.Padre.Izquierda = aux;
                        }
                    }
                }
            }
            Raiz=equilibrar(this.raiz);
        }

        

    }
}