using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ServidorEDD
{
    /// <summary>
    /// Summary description for WebService
    /// </summary>
    [WebService(Namespace = "http://servidoredd2/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {
        static ArbolBinario arbol = new ArbolBinario();
        static Matriz matriz = new Matriz(1);

        static string prueba, jugador1 = "", jugador2 = "", tiempo, dot;
        static bool partidaActiva = false;
        static int nivel0, nivel1, nivel2, nivel3, tamañoX, tamañoY, tipo;


        [WebMethod]
        public Byte[] Usuariosgrafo()
        {
            dot = "digraph ABB{\n node[shape=record];{\n";
            nodosArbol(arbol.Raiz);
            dot = dot + "}\n";
            enlacesNodosArbol(arbol.Raiz);
            dot = dot + "}\n";

            TextWriter t = new StreamWriter(@"C:\GrafosEDD\grafoArbol.dot");
            t.WriteLine(dot);
            t.Close();

            Byte[] a= new Byte[0];

                String comando = "C:\\Program Files (x86)\\Graphviz2.38\\bin\\dot -Tpng C:\\GrafosEDD\\grafoArbol.dot -o C:\\GrafosEDD\\grafoArbol.png";
                System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c" + comando);
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;

                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo = procStartInfo;
                proc.Start();

                //FileStream foto = new FileStream("C:\\GrafosEDD\\grafoArbol.png", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                //a = new Byte[foto.Length];
                //BinaryReader reader = new BinaryReader(foto);
                //a = reader.ReadBytes(Convert.ToInt32(foto.Length));
                //foto.Close();

            return a;
        }

        public void enlacesNodosArbol(NodoArbol n)
        {
            if (n != null)
            {
                if (n.Der != null)
                {
                    dot = dot + n.NickName+":f2->"+n.Der.NickName+":f1;\n";
                }

                if (n.Izq != null)
                {
                    dot = dot + n.NickName + ":f0->" + n.Izq.NickName + ":f1;\n";
                }

                if (n.Lista.Cabeza != null)
                {
                    dot = dot + n.NickName + ":f1->" + n.NickName + "0;\n" ;
                    NodoLista aux = n.Lista.Cabeza;
                    int i = 0;
                    while (aux.Siguiente != null)
                    {
                        dot = dot + n.NickName + i.ToString() + "->"+n.NickName+(i+1).ToString()+";\n";
                        dot = dot + n.NickName + (i + 1).ToString() + "->" + n.NickName + i.ToString() + ";\n";
                        aux = aux.Siguiente;
                        i++;
                    }
                }

                enlacesNodosArbol(n.Izq);
                enlacesNodosArbol(n.Der);
            }
        }

        public void nodosArbol(NodoArbol n)
        {
            if (n != null)
            {
                dot = dot + n.NickName + "[label=\"<f0>|<f1>Nickname: " + n.NickName + "--Password: " + n.Contraseña + "--Correo: " + n.Correo + "|<f2>\"]\n";
                NodoLista aux = n.Lista.Cabeza;
                int i = 0;
                while (aux != null)
                {
                    dot = dot + n.NickName + i.ToString() + "[label=\"Oponente: "+aux.Oponente+"--Desplegadas: "+aux.Desplegadas.ToString()+"--Destruidas: "+aux.Destruidas.ToString()+"--Sobrevivientes: "+aux.Sobrevivientes.ToString()+"\"]\n";
                    i++;
                    aux = aux.Siguiente;
                }
                nodosArbol(n.Izq);
                nodosArbol(n.Der);
            }
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
                    }
                    else if (jugador2.Equals(""))
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
        public String devolver()
        {
            if (arbol.Raiz != null)
            {
                return arbol.Raiz.NickName;
            }else
            {
                return "vacio";
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

        [WebMethod]
        public void ModificarUsuario(String nickname, String nickname2, String contraseña, String correo)
        {
            arbol.Modificar(nickname, nickname2, contraseña, correo, 0);
        }

        [WebMethod]
        public void EliminarUsuario(String nickname)
        {
            arbol.Eliminar(nickname);
        }
    }
}
