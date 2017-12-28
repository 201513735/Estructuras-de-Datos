using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Matriz
/// </summary>
public class Matriz
{
    int nivel;
    ListaEncabezados filas, columnas;
    Matriz siguiente, anterior;


    public Matriz(int nivel)
    {
        Nivel = nivel;
        Filas = new ListaEncabezados();
        Columnas = new ListaEncabezados();
        Siguiente = null;
        Anterior = null;
    }

    public int Nivel
    {
        get { return nivel; }
        set { nivel = value; }
    }

    public ListaEncabezados Filas
    {
        get { return filas; }
        set { filas = value; }
    }

    public ListaEncabezados Columnas
    {
        get { return columnas; }
        set { columnas = value; }
    }

    public Matriz Siguiente
    {
        get { return siguiente; }
        set { siguiente = value; }
    }

    public Matriz Anterior
    {
        get { return anterior; }
        set { anterior = value; }
    }

    //*****************************************METODOS DE LA MATRIZ*****************************************

    public void Insertar(int fila, int columna, String nombre, String nickname)
    {
        NodoMatriz nuevo = new NodoMatriz(nombre,nickname, fila, columna);
        Matriz m=this;

        //SELECCIONANDO NIVEL DONDE SE INSERTARA
        switch (nuevo.Nave.Nivel)
        {
            case 0:
                if (m.Anterior == null)
                {
                    //CREANDO NIVEL 0
                    m.Anterior = new Matriz(0);
                    m = m.Anterior;
                }else
                {
                    m = m.Anterior;
                }
                break;
            case 1:
                break;
            case 2:
                if (m.Siguiente == null)
                {
                    //CREANDO NIVEL 2
                    m.Siguiente = new Matriz(2);
                    m = m.Siguiente;
                }else
                {
                    m = m.Siguiente;
                }
                break;
            case 3:
                if (m.Siguiente == null)
                {
                    //CREANDO NIVEL 2
                    m.Siguiente = new Matriz(2);
                    m = m.Siguiente;
                    //CREANDO NIVEL 3
                    m.Siguiente = new Matriz(3);
                    m = m.Siguiente;
                }else
                {
                    //YA EXISTE NIVEL 2
                    m = m.Siguiente;
                    if (m.Siguiente == null)
                    {
                        //CREANDO NIVEL 3
                        m.Siguiente = new Matriz(3);
                        m = m.Siguiente;
                    }
                    else
                    {
                        m = m.Siguiente;
                    }
                }
                break;
            default:
                break;
        }


        //INSERTANDO EN FILAS
        Encabezado f = m.Filas.getEncabezado(fila);
        if (f == null)
        {
            m.Filas.Insertar(fila);
            f = m.Filas.getEncabezado(fila);
            f.Acceso = nuevo;
        }else
        {
            if (nuevo.Columna < f.Acceso.Columna)
            {
                f.Acceso.Izquierda = nuevo;
                nuevo.Derecha = f.Acceso;
                f.Acceso = nuevo;
            }
            else
            {
                NodoMatriz aux = f.Acceso;
                while (aux.Derecha != null)
                {
                    if (nuevo.Columna < aux.Derecha.Columna)
                    {
                        nuevo.Derecha = aux.Derecha;
                        nuevo.Izquierda = aux;
                        aux.Derecha.Izquierda = nuevo;
                        aux.Derecha = nuevo;
                        break;
                    }
                    aux = aux.Derecha;
                }

                if (aux.Derecha == null)
                {
                    aux.Derecha = nuevo;
                    nuevo.Izquierda = aux;
                }
            }
            
        }

        //INSERTANDO EN COLUMNAS
        Encabezado c = m.Columnas.getEncabezado(columna);
        if (c == null)
        {
            m.Columnas.Insertar(columna);
            c = m.Columnas.getEncabezado(columna);
            c.Acceso = nuevo;
        }
        else
        {
            if (nuevo.Fila < c.Acceso.Fila)
            {
                c.Acceso.Arriba = nuevo;
                nuevo.Abajo = c.Acceso;
                c.Acceso = nuevo;
            }
            else
            {
                NodoMatriz aux = c.Acceso;
                while (aux.Abajo != null)
                {
                    if (nuevo.Fila < aux.Abajo.Fila)
                    {
                        nuevo.Abajo = aux.Abajo;
                        nuevo.Arriba = aux;
                        aux.Abajo.Arriba = nuevo;
                        aux.Abajo = nuevo;
                        break;
                    }
                    aux = aux.Abajo;
                }

                if (aux.Abajo == null)
                {
                    aux.Abajo = nuevo;
                    nuevo.Arriba = aux;
                }
            }
        }

        Matriz ma;
        NodoMatriz nodo;
        //DEFINIENDO ARRIBA
        ma = m.Siguiente;
        while (ma != null)
        {
            nodo = ma.getNodo(fila,columna);
            if (nodo != null)
            {
                nuevo.Arriba = nodo;
                nodo.Abajo = nuevo;
                break;
            }
            ma = ma.Siguiente;
        }

        //DEFINIENDO ABAJO
        ma = m.Anterior;
        while (ma != null)
        {
            nodo = ma.getNodo(fila, columna);
            if (nodo != null)
            {
                nuevo.Abajo = nodo;
                nodo.Arriba = nuevo;
                break;
            }
            ma = ma.Anterior;
        }

    }

    public NodoMatriz getNodo(int fila, int columna)
    {
        NodoMatriz nodo=null;
        Encabezado f = this.Filas.getEncabezado(fila);
        if (f != null)
        {
            nodo = f.Acceso;
            while (nodo != null)
            {
                if (nodo.Columna == columna)
                {
                    break;
                }
                nodo = nodo.Derecha;
            }
        }
        return nodo;
    }

    public NodoMatriz getNodo(String nombre)
    {
        NodoMatriz nodo = null;
        Encabezado e = this.Filas.Cabeza;
        while (e != null)
        {
            nodo = e.Acceso;
            while (nodo != null)
            {
                if (String.Compare(nodo.Nave.Nombre, nombre) == 0)
                {
                    break;
                }
                nodo = nodo.Derecha;
            }
            if (nodo != null)
            {
                break;
            }
            e = e.Siguiente;
        }

        return nodo;
    }

    public void Eliminar(String nombre)
    {
        NodoMatriz nodo = this.getNodo(nombre);
        if (nodo != null)
        {
            //ELIMINANDO EN FILAS
            Encabezado fila = this.Filas.getEncabezado(nodo.Fila);
            if (fila.Acceso == nodo)
            {
                fila.Acceso = nodo.Derecha;
                if (fila.Acceso == null)
                {
                    this.Filas.Eliminar(fila.Id);
                }else
                {
                    fila.Acceso.Izquierda = null;
                }
            }else
            {
                nodo.Izquierda.Derecha = nodo.Derecha;
                if (nodo.Derecha != null)
                {
                    nodo.Derecha.Izquierda = nodo.Izquierda;
                }
            }

            //ELIMINANDO EN COLUMNAS
            Encabezado columna = this.Columnas.getEncabezado(nodo.Columna);
            if (columna.Acceso == nodo)
            {
                columna.Acceso = nodo.Abajo;
                if (columna.Acceso == null)
                {
                    this.Columnas.Eliminar(columna.Id);
                }else
                {
                    columna.Acceso.Arriba = null;
                }
            }else
            {
                nodo.Arriba.Abajo = nodo.Abajo;
                if (nodo.Abajo != null)
                {
                    nodo.Abajo.Arriba = nodo.Arriba;
                }
            }

            //ELIMINANDO ARRIBA Y ABAJO
            if (nodo.Abajo != null)
            {
                nodo.Abajo.Arriba = nodo.Arriba;
            }
            if (nodo.Arriba != null)
            {
                nodo.Arriba.Abajo = nodo.Abajo;
            }
        }
    }
}