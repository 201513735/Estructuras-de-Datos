using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for NodoLista
/// </summary>
public class NodoLista
{
    String oponente;
    int desplegadas, destruidas, sobrevivientes;
    int gano;
    NodoLista siguiente, anterior;

    public NodoLista(String oponente, int desplegadas, int sobrevivientes, int destruidas, int gano)
    {
        this.oponente = oponente;
        this.desplegadas = desplegadas;
        this.sobrevivientes = sobrevivientes;
        this.destruidas = destruidas;
        this.gano = gano;
        this.siguiente = null;
        this.anterior = null;
    }

    public NodoLista Siguiente
    {
        get { return siguiente; }
        set { siguiente = value; }
    }

    public NodoLista Anterior
    {
        get { return anterior; }
        set { anterior = value; }
    }

    public String Oponente
    {
        get { return oponente; }
        set { oponente = value; }
    }

    public int Desplegadas
    {
        get { return desplegadas; }
        set { desplegadas = value; }
    }

    public int Sobrevivientes
    {
        get { return sobrevivientes; }
        set { sobrevivientes = value; }
    }

    public int Destruidas
    {
        get { return destruidas; }
        set { destruidas = value; }
    }

    public int Gano
    {
        get { return gano; }
        set { gano = value; }
    }
}