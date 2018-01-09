using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServidorEDD
{
    public class ListaTop
    {
        NodoTop cabeza;

        public ListaTop()
        {
            Cabeza = null;
        }

        public void Insertar(String nickname, int cantidad)
        {
            NodoTop nuevo = new NodoTop(cantidad, nickname);
            if (Cabeza == null)
            {
                Cabeza = nuevo;
            }else
            {
                if (Cabeza.Cantidad < cantidad)
                {
                    nuevo.Siguiente = Cabeza;
                    Cabeza.Anterior = nuevo;
                    Cabeza = nuevo;
                }else
                {
                    NodoTop aux = Cabeza;
                    while (aux.Siguiente != null)
                    {
                        if (aux.Siguiente.Cantidad <= cantidad)
                        {
                            aux.Siguiente.Anterior = nuevo;
                            nuevo.Siguiente = aux.Siguiente;
                            aux.Siguiente = nuevo;
                            nuevo.Anterior = aux;
                            break;
                        }
                        aux = aux.Siguiente;
                    }
                    if (aux.Siguiente == null)
                    {
                        aux.Siguiente = nuevo;
                        nuevo.Anterior = aux;
                    }
                }
            }
        }

        public NodoTop Cabeza
        {
            get { return cabeza; }
            set { cabeza = value; }
        }
    }
}