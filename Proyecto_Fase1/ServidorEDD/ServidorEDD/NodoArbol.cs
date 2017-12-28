using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for NodoArbol
/// </summary>
public class NodoArbol
{
    String nickname, contraseña, correo;
    int conexion;
    ListaJuegos lista;
    NodoArbol der, izq, padre;

    public NodoArbol(String nickname, String contraseña, String correo, int conexion)
    {
        this.NickName = nickname;
        this.Contraseña = contraseña;
        this.Correo = correo;
        this.Conexion = conexion;
        this.Der = null;
        this.Izq = null;
        this.Padre = null;
        this.Lista = new ListaJuegos();
    }

    public ListaJuegos Lista
    {
        get { return lista; }
        set { lista = value; }
    }

    public int Conexion
    {
        get { return conexion; }
        set { conexion = value; }
    }

    public NodoArbol Der
    {
        get { return der; }
        set { der = value; }
    }

    public NodoArbol Izq
    {
        get { return izq; }
        set { izq = value; }
    }

    public NodoArbol Padre
    {
        get { return padre; }
        set { padre = value; }
    }

    public String NickName
    {
        get { return nickname; }
        set { nickname = value; }
    }

    public String Contraseña
    {
        get { return contraseña; }
        set { contraseña = value; }
    }

    public String Correo
    {
        get { return correo; }
        set { correo = value; }
    }
}