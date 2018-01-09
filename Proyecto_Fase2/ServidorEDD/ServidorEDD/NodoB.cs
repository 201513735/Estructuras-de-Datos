using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServidorEDD
{
    public class NodoB
    {
        int x, y, resultado, numero;
        String unidadAtacante, unidadDañada, emisor, receptor, fecha, tiempoRestante, id;
        HojaB izquierda, derecha;

        public NodoB(String id, int x, int y, String unidadAtacante, int resultado, String unidadDañada, String emisor, String receptor, String fecha, String tiempoRestante, int numero)
        {
            Id = id;
            X = x;
            Y = y;
            UnidadAtacante = unidadAtacante;
            UnidadDañada = unidadDañada;
            Emisor = emisor;
            Receptor = receptor;
            Fecha = fecha;
            TiempoRestante = tiempoRestante;
            Resultado = resultado;
            Numero = numero;
            Izquierda = null;
            Derecha = null;
        }

        public String Id
        {
            get { return id; }
            set { id = value; }
        }

        public String TiempoRestante
        {
            get { return tiempoRestante; }
            set { tiempoRestante = value; }
        }

        public String Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public String Receptor
        {
            get { return receptor; }
            set { receptor = value; }
        }

        public String Emisor
        {
            get { return emisor; }
            set { emisor = value; }
        }

        public String UnidadDañada
        {
            get { return unidadDañada; }
            set { unidadDañada = value; }
        }

        public String UnidadAtacante
        {
            get { return unidadAtacante; }
            set { unidadAtacante = value; }
        }

        public HojaB Derecha
        {
            get { return derecha; }
            set { derecha = value; }
        }

        public HojaB Izquierda
        {
            get { return izquierda; }
            set { izquierda = value; }
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public int Resultado
        {
            get { return resultado; }
            set { resultado = value; }
        }

        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }
    }
}