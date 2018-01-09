using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

[WebService(Namespace = "http://edd201513735/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]

public class Service : System.Web.Services.WebService
{
    static ArbolBinario arbol=new ArbolBinario();
    static Matriz matriz=new Matriz(1);
    static string prueba,jugador1="",jugador2="";
    static bool partidaActiva=false;


    public Service () {
       // arbol = new ArbolBinario();
        //matriz = new Matriz(1);
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public void Iniciar()
    {
        arbol = new ArbolBinario();
        matriz = new Matriz(1);
        jugador1 = "";
        jugador2 = "";
    }


    [WebMethod]
    public bool IniciarSesion(String nickname, String contraseña)
    {
        NodoArbol nodo = arbol.Buscar(nickname, arbol.Raiz);
        if (nodo != null)
        {
            if (String.Compare(nodo.Contraseña, contraseña) == 0)
            {
                nodo.Conexion = 1;
                if (jugador1.Equals(""))
                {
                    jugador1 = nodo.NickName;
                }else if (jugador2.Equals(""))
                {
                    jugador2 = nodo.NickName;
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    [WebMethod]
    public void InsertarArbol(String nickname, String contraseña, String correo, int conexion)
    {
        arbol.Insertar(nickname, contraseña, correo, conexion);
    }
    
    [WebMethod]
    public void InsertarJuego(String nickname, String oponente, int desplegadas, int sobrevivientes, int destruidas, int gano)
    {
        NodoArbol n = arbol.Buscar(nickname, arbol.Raiz);
        if (n != null)
        {
            n.Lista.Insertar(oponente, desplegadas, sobrevivientes, desplegadas, gano);
        }
    }

    [WebMethod]
    public void InsertarMatriz(int fila, int columna, String nombre, String nickname)
    {
        matriz.Insertar(fila, columna, nombre, nickname);
    }


}