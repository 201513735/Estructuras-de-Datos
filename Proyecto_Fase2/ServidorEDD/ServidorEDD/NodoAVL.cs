using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServidorEDD
{
    public class NodoAVL
    {
        NodoArbol jugador;
        String nickname, correo, contraseña;
        NodoAVL derecha, izquierda, padre;
        int fe;

        public NodoAVL(NodoArbol jugador)
        {
            Jugador = jugador;
            Nickname = jugador.NickName;
            Contraseña = "";
            Correo = "";
            Derecha = null;
            Izquierda = null;
            fe = 0;
        }

        public NodoAVL(String nickname, String correo, String contraseña)
        {
            Nickname = nickname;
            Correo = correo;
            Contraseña = contraseña;
            Jugador = null;
            Derecha = null;
            Izquierda = null;
            fe = 0;
        }

        public int Fe
        {
            get { return fe; }
            set { fe = value; }
        }

        public NodoAVL Padre
        {
            get { return padre; }
            set { padre = value; }
        }

        public NodoAVL Izquierda
        {
            get { return izquierda; }
            set { izquierda = value; }
        }

        public NodoAVL Derecha
        {
            get { return derecha; }
            set { derecha = value; }
        }

        public NodoArbol Jugador
        {
            get { return jugador; }
            set { jugador = value; }
        }

        public String Nickname
        {
            get { return nickname; }
            set { nickname = value; }
        }

        public String Correo
        {
            get { return correo; }
            set { correo = value; }
        }

        public String Contraseña
        {
            get { return contraseña; }
            set { contraseña = value; }
        }
    }
}