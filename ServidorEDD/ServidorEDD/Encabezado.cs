using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Encabezado
/// </summary>
public class Encabezado
{
    int id;
    NodoMatriz acceso;
    Encabezado siguiente, anterior;

    public Encabezado(int id)
    {
        Id = id;
        Acceso = null;
        Siguiente = null;
        Anterior = null;
    }

    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    public NodoMatriz Acceso
    {
        get { return acceso; }
        set { acceso = value; }
    }

    public Encabezado Siguiente
    {
        get { return siguiente; }
        set { siguiente = value; }
    }

    public Encabezado Anterior
    {
        get { return anterior; }
        set { anterior = value; }
    }
}