using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ListaJuegos
/// </summary>
public class ListaJuegos
{
    NodoLista cabeza;

    public ListaJuegos()
    {
        this.cabeza = null;
    }

    public NodoLista Cabeza
    {
        get { return cabeza; }
        set { cabeza = value; }
    }

    public void Insertar(String oponente, int desplegadas, int sobrevivientes, int destruidas, int gano)
    {
        NodoLista nuevo = new NodoLista(oponente, desplegadas, sobrevivientes, destruidas, gano);
        if (cabeza == null)
        {
            cabeza = nuevo;
        }else
        {
            NodoLista aux = cabeza;
            while (aux.Siguiente!=null)
            {
                aux = aux.Siguiente;
            }
            nuevo.Anterior = aux;
            aux.Siguiente = nuevo;
        }
    }
}