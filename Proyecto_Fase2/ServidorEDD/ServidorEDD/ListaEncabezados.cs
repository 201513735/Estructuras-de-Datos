using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ListaEncabezados
/// </summary>
public class ListaEncabezados
{
    Encabezado cabeza;

    public ListaEncabezados()
    {
        Cabeza = null;
    }

    public Encabezado Cabeza
    {
        get { return cabeza; }
        set { cabeza = value; }
    }

    public void Insertar(int id)
    {
        Encabezado nuevo = new Encabezado(id);

        if (this.Cabeza == null)
        {
            Cabeza = nuevo;
        }else
        {
            if (nuevo.Id < Cabeza.Id)
            {
                nuevo.Siguiente = Cabeza;
                Cabeza.Anterior = nuevo;
                Cabeza = nuevo;
            }else
            {
                Encabezado aux = Cabeza;

                while (aux.Siguiente != null)
                {
                    if (nuevo.Id < aux.Siguiente.Id)
                    {
                        nuevo.Siguiente = aux.Siguiente;
                        nuevo.Anterior = aux;
                        aux.Siguiente.Anterior = nuevo;
                        aux.Siguiente = nuevo;
                        break;
                    }
                    aux = aux.Siguiente;
                }

                if (aux.Siguiente == null)
                {
                    nuevo.Anterior = aux;
                    aux.Siguiente = nuevo;
                }
            }
        }
    }

    public Encabezado getEncabezado(int id)
    {
        Encabezado aux = Cabeza;
        while (aux != null)
        {
            if (aux.Id == id)
            {
                break;
            }
            aux = aux.Siguiente;
        }

        return aux;
    }

    public void Eliminar(int id)
    {
        Encabezado n = getEncabezado(id);
        if (n != null)
        {
            if (n != Cabeza)
            {
                if (n.Siguiente != null)
                {
                    n.Anterior.Siguiente = n.Siguiente;
                    n.Siguiente.Anterior = n.Anterior;
                }else
                {
                    n.Anterior.Siguiente = null;
                }
            }else
            {
                if (n.Siguiente != null)
                {
                    n.Siguiente.Anterior = null;
                    Cabeza = n.Siguiente;
                }
                else
                {
                    Cabeza = null;
                }
            }
        }
    }

}