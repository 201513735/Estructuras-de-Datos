using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for NodoMatriz
/// </summary>
public class NodoMatriz
{
    Unidad nave;
    int fila, columna;
    NodoMatriz arriba, abajo, derecha, izquierda, atras, enfrente;
    public NodoMatriz(String nombre, String nickname, int fila, int columna)
    {
        Nave = new Unidad(nombre,nickname);
        Fila = fila;
        Columna = columna;

        Arriba = null;
        Abajo = null;
        Derecha = null;
        Izquierda = null;
        Atras = null;
        Enfrente = null;
    }

    public Unidad Nave
    {
        get { return nave; }
        set { nave = value; }
    }

    public NodoMatriz Arriba
    {
        get { return arriba; }
        set { arriba = value; }
    }

    public NodoMatriz Abajo
    {
        get { return abajo; }
        set { abajo = value; }
    }

    public NodoMatriz Derecha
    {
        get { return derecha; }
        set { derecha = value; }
    }

    public NodoMatriz Izquierda
    {
        get { return izquierda; }
        set { izquierda = value; }
    }

    public NodoMatriz Enfrente
    {
        get { return enfrente; }
        set { enfrente = value; }
    }

    public NodoMatriz Atras
    {
        get { return atras; }
        set { atras = value; }
    }

    public int Fila
    {
        get { return fila; }
        set { fila = value; }
    }

    public int Columna
    {
        get { return columna; }
        set { columna = value; }
    }
}