using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ArbolBinario
/// </summary>
public class ArbolBinario
{
    NodoArbol raiz;

    public ArbolBinario()
    {
        this.Raiz = null;
    }

    public NodoArbol Raiz
    {
        get { return raiz; }
        set { raiz = value; }
    }

    public void Insertar(String nickname, String contraseña, String correo, int conexion)
    {
        NodoArbol nuevo = new NodoArbol(nickname, contraseña, correo, conexion);
        if (this.Raiz == null)
        {
            this.Raiz = nuevo;
        }else
        {
            Comparar(this.Raiz, nuevo);
        }
    }

    private void Comparar(NodoArbol hoja, NodoArbol nuevo)
    {
        if (String.Compare(hoja.NickName, nuevo.NickName) < 0)
        {
            if (hoja.Der == null)
            {
                hoja.Der = nuevo;
                nuevo.Padre = hoja;
            }else
            {
                Comparar(hoja.Der, nuevo);
            }
        }else if (String.Compare(hoja.NickName, nuevo.NickName) > 0)
        {
            if (hoja.Izq == null)
            {
                hoja.Izq = nuevo;
                nuevo.Padre = hoja;
            }else
            {
                Comparar(hoja.Izq, nuevo);
            }
        }
    }

    public void Eliminar(String nickname)
    {
        NodoArbol n = Buscar(nickname, Raiz);
        if (n != null)
        {
            if(n.Der==null && n.Izq == null)
            {
                if (n==this.Raiz)
                {
                    this.Raiz = null;
                }else
                {
                    if (n.Padre.Der == n)
                    {
                        n.Padre.Der = null;
                    }else
                    {
                        n.Padre.Izq = null;
                    }
                }
            }else if(n.Der==null && n.Izq != null)
            {
                if (n.Padre == null)
                {
                    this.Raiz = n.Izq;
                }
                else
                {
                    if (n.Padre.Der == n)
                    {
                        n.Padre.Der = n.Izq;
                    }
                    else
                    {
                        n.Padre.Izq = n.Izq;
                    }
                }
            }
            else if(n.Der!=null & n.Izq == null)
            {
                if (n.Padre == null)
                {
                    this.Raiz = n.Der;
                }
                else
                {
                    if (n.Padre.Der == n)
                    {
                        n.Padre.Der = n.Der;
                    }
                    else
                    {
                        n.Padre.Izq = n.Der;
                    }
                }
            }
            else
            {
                //AMBOS NODOS ESTAN LLENOS
                NodoArbol aux = n.Der;
                while (aux.Izq != null)
                {
                    aux = aux.Izq;
                }
                if (aux.Der != null)
                {
                    if (aux.Padre != n)
                    {
                        aux.Padre.Izq = aux.Der;
                        aux.Der.Padre = aux.Padre;
                    }
                    else
                    {
                        aux.Padre.Der = aux.Der;
                        aux.Der.Padre = aux.Padre;
                    }
                }
                else
                {
                    if (aux.Padre != n)
                    {
                        aux.Padre.Izq = null;
                    }
                    else
                    {
                        aux.Padre.Der = null;
                    }
  
                }
                //Si es la Raiz
                if (n.Padre == null)
                {
                    Raiz = aux;
                    aux.Padre = null;
                    aux.Izq = n.Izq;
                    aux.Der = n.Der;
                    if (n.Izq != null)
                    {
                        n.Izq.Padre = aux;
                    }
                    
                    if (n.Der != null)
                    {
                        n.Der.Padre = aux;
                    }
                }else
                {
                    aux.Izq = n.Izq;
                    aux.Der = n.Der;
                    if (n.Izq != null)
                    {
                        n.Izq.Padre = aux;
                    }

                    if (n.Der != null)
                    {
                        n.Der.Padre = aux;
                    }

                    if (n.Padre.Der == n)
                    {
                        n.Padre.Der = aux;
                    }else
                    {
                        n.Padre.Izq = aux;
                    }
                }
            }
        }
    }

    public NodoArbol Buscar(String nickname, NodoArbol n)
    {
        if (n != null)
        {
            if (String.Compare(n.NickName, nickname) == 0)
            {
                return n;
            }
            else if (String.Compare(n.NickName, nickname) < 0)
            {
                if (n.Der != null)
                {
                    return Buscar(nickname, n.Der);
                }
                else
                {
                    return null;
                }

            }
            else if (String.Compare(n.NickName, nickname) > 0)
            {
                if (n.Izq != null)
                {
                    return Buscar(nickname, n.Izq);
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

    public void Modificar(String nickname, String nuevo, String contraseña, String correo, int conexion)
    {
        this.Eliminar(nickname);
        this.Insertar(nuevo, contraseña, correo, conexion);
    }
}