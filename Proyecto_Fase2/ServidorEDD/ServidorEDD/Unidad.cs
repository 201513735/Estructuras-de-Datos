using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Unidad
/// </summary>
public class Unidad
{
    int movimiento, alcance, daño, vida, nivel;
    String nombre, nickname;
    int mover, atacar;

    public Unidad(string nombre, string nickname)
    {
        Nombre = nombre;
        Nickname = nickname;
        if (nombre.ToLower().Contains("submarino"))
        {
            Alcance = 5;
            Movimiento = 1;
            Daño = 2;
            Vida = 10;
            Nivel = 0;
        }else if (nombre.ToLower().Contains("neosatelite"))
        {
            Movimiento = 6;
            Alcance = 0;
            Daño = 2;
            Vida = 10;
            Nivel = 3;
        }
        else if (nombre.ToLower().Contains("bombardero"))
        {
            Movimiento = 7;
            Alcance = 0;
            Daño = 5;
            Vida = 10;
            Nivel = 2;
        }
        else if (nombre.ToLower().Contains("caza"))
        {
            Movimiento = 9;
            Alcance = 1;
            Daño = 2;
            Vida = 20;
            Nivel = 2;
        }
        else if (nombre.ToLower().Contains("helicoptero"))
        {
            Movimiento = 9;
            Alcance = 1;
            Daño = 3;
            Vida = 15;
            Nivel = 2;
        }
        else if (nombre.ToLower().Contains("fragata"))
        {
            Movimiento = 5;
            Alcance = 2;
            Daño = 3;
            Vida = 10;
            Nivel = 1;
        }
        else if (nombre.ToLower().Contains("crucero"))
        {
            Movimiento = 6;
            Alcance = 1;
            Daño = 3;
            Vida = 15;
            Nivel = 1;
        }
    }

    public int Mover
    {
        get { return mover; }
        set { mover = value; }
    }

    public int Atacar
    {
        get { return atacar; }
        set { atacar = value; }
    }

    public String Nickname
    {
        get { return nickname; }
        set { nickname = value; }
    }

    public String Nombre
    {
        get { return nombre; }
        set { nombre = value; }
    }

    public int Movimiento
    {
        get { return movimiento; }
        set { movimiento = value; }
    }

    public int Alcance
    {
        get { return alcance; }
        set { alcance = value; }
    }

    public int Daño
    {
        get { return daño; }
        set { daño = value; }
    }

    public int Vida
    {
        get { return vida; }
        set { vida = value; }
    }

    public int Nivel
    {
        get { return nivel; }
        set { nivel = value; }
    }
}