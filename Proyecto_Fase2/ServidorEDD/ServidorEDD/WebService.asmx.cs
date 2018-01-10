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
        static ArbolBinario arbol2;
        static Matriz matriz = new Matriz(1);
        static ArbolB historial=new ArbolB(3,1);
        static ListaTop listaTop;
        static TablaHash tabla;

        static String jugador1 = "", jugador2 = "", tiempo2="", dot, tipo="", activo="";
        static String consola = "";
        static public bool partidaActiva = false;
        static int nivel0, nivel1, nivel2, nivel3, tamañoX, tamañoY;
        static int base1x, base1y, base2x, base2y;

        [WebMethod]
        public Byte[] tablaGrafo()
        {
            tabla = new TablaHash(43);
            ingresarTabla(arbol.Raiz);

            dot = "digraph TablaHash{\n graph[rankdir=\"LR\"];\n tabla[label=\"";
            NodoArbol n;
            for(int i = 0; i < tabla.Tabla.Length; i++)
            {
                if (tabla.Tabla[i] != null)
                {
                    n = tabla.Tabla[i].Usuario;
                    dot = dot + "Nick: " + n.NickName + "  --  Password: " + n.Correo + "  --  Correo: " + n.Correo + "  --  Conexion: " + n.Conexion.ToString() + " | \n";
                }
            }
            dot = dot + "\"\n shape=\"record\"];\n }";

            TextWriter t = new StreamWriter(@"C:\GrafosEDD\grafoTabla.dot");
            t.WriteLine(dot);
            t.Close();

            Byte[] a = new Byte[0];

            String comando = "\"C:/Program Files (x86)/Graphviz2.38/bin/dot.exe\" -Tpng C:\\GrafosEDD\\grafoTabla.dot -o C:\\GrafosEDD\\grafoTabla.png";
            var procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd.exe", "/c" + comando);
            var proc = new System.Diagnostics.Process { StartInfo = procStartInfo };
            proc.Start();
            proc.WaitForExit();

            FileStream foto = new FileStream("C:\\GrafosEDD\\grafoTabla.png", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            a = new Byte[foto.Length];
            BinaryReader reader = new BinaryReader(foto);
            a = reader.ReadBytes(Convert.ToInt32(foto.Length));
            foto.Close();

            return a;
        }

        [WebMethod]
        public void setActivo(String nick)
        {
            activo = nick;
        }

        public void ingresarTabla(NodoArbol n)
        {
            if (n != null)
            {
                tabla.Insertar(n);
                ingresarTabla(n.Der);
                ingresarTabla(n.Izq);
            }
        }

        [WebMethod]
        public void terminarPartida(String nickname, String oponente, int desplegadas, int sobrevivientes, int destruidas, int gano)
        {
            arbol.Buscar(nickname, arbol.Raiz).Lista.Insertar(oponente, desplegadas, sobrevivientes, destruidas, gano, historial);
        }

        [WebMethod]
        public void accionContactos(String accion, String nick, String nick2, String contraseña, String correo)
        {
            NodoArbol n = arbol.Buscar(nick,arbol.Raiz);
            if (n != null)
            {
                if (accion.Equals("Eliminar"))
                {
                    n.Contactos.Eliminar(nick2);
                }
                else
                {
                    NodoArbol n2 = arbol.Buscar(nick2, arbol.Raiz);
                    if (n2 != null)
                    {
                        n.Contactos.Insertar(n2);
                    }else
                    {
                        n.Contactos.Insertar(nick2, contraseña, correo);
                    }
                }
            }
        }

        [WebMethod]
        public Byte[] topGrafo(String top)
        {
            listaTop = new ListaTop();
            if (top.Equals("Eliminados"))
            {
                listaEliminados(arbol.Raiz);
            }else
            {
                listaContactos(arbol.Raiz);
            }

            dot = "digraph Top{\n";
            NodoTop aux = listaTop.Cabeza;
            int i = 0;
            while (aux != null && i<10)
            {
                dot = dot + aux.Nickname + "[label=\"Nickname: " + aux.Nickname + "\\n Cantidad: "+aux.Cantidad.ToString()+"\"]\n";
                aux = aux.Siguiente;
                i++;
            }

            aux = listaTop.Cabeza;
            i = 0;
            while(aux.Siguiente!=null && i < 9)
            {
                dot = dot + aux.Nickname + "->" + aux.Siguiente.Nickname + ";\n";
                aux = aux.Siguiente;
                i++;
            }
            dot = dot + "}\n";

            TextWriter t = new StreamWriter(@"C:\GrafosEDD\grafoTop.dot");
            t.WriteLine(dot);
            t.Close();

            Byte[] a = new Byte[0];

            String comando = "\"C:/Program Files (x86)/Graphviz2.38/bin/dot.exe\" -Tpng C:\\GrafosEDD\\grafoTop.dot -o C:\\GrafosEDD\\grafoTop.png";
            var procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd.exe", "/c" + comando);
            var proc = new System.Diagnostics.Process { StartInfo = procStartInfo };
            proc.Start();
            proc.WaitForExit();

            FileStream foto = new FileStream("C:\\GrafosEDD\\grafoTop.png", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            a = new Byte[foto.Length];
            BinaryReader reader = new BinaryReader(foto);
            a = reader.ReadBytes(Convert.ToInt32(foto.Length));
            foto.Close();

            return a;

        }

        public void listaContactos(NodoArbol n)
        {
            if (n != null)
            {
                listaTop.Insertar(n.NickName, contarContactos(n.Contactos.Raiz));
                listaContactos(n.Der);
                listaContactos(n.Izq);
            }
        }

        public void listaEliminados(NodoArbol n)
        {
            if (n != null)
            {
                listaTop.Insertar(n.NickName, contarEliminados(n));
                listaEliminados(n.Der);
                listaEliminados(n.Izq);
            }
        }

        public int contarContactos(NodoAVL n)
        {
            if (n != null)
            {
                return 1 + contarContactos(n.Izquierda) + contarContactos(n.Derecha);
            }
            else
            {
                return 0;
            }
        }

        public int contarEliminados(NodoArbol n)
        {
            int no = 0;
            NodoLista aux = n.Lista.Cabeza;
            while (aux != null)
            {
                no = no + aux.Destruidas;
                aux = aux.Siguiente;
            }
            return no;
        }

        [WebMethod]
        public void setBase(int x, int y, int jugador)
        {
            if (jugador == 1)
            {
                base1x = x;
                base1y = y;
            }
            else
            {
                base2x = x;
                base2y = y;
            }
        }

        [WebMethod]
        public void setTiempo(String tiempo)
        {
            tiempo2 = tiempo;
        }

        [WebMethod]
        public String getConsola()
        {
            return consola;
        }

        [WebMethod]
        public String getJugador1()
        {
            return jugador1;
        }

        [WebMethod]
        public String getJugador2()
        {
            return jugador2;
        }

        [WebMethod]
        public bool moverUnidad(String nombre, int x, int y, String nickname)
        {
            Matriz m = encontrarMatriz(nombre);
            NodoMatriz n=null;
            if (m != null)
            {
                n = m.getNodo(nombre);
            }

            if (n != null)
            {
                int mx = x - n.Columna;
                int my = y - n.Fila;
                int r = Math.Abs(mx) + Math.Abs(my);
                if (n.Nave.Movimiento >= r && m.getNodo(y,x)==null && n.Nave.Mover==0 && n.Nave.Nickname.Equals(nickname))
                {
                    m.Eliminar(nombre);
                    matriz.Insertar(y, x, nombre, n.Nave.Nickname);
                    n.Nave.Mover = 1;
                    consola = consola + nickname + ":  movio a la unidad " + nombre + ". \n ";
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
        public String atacarUnidad(String nombre, int columna, int fila, String nickname, int nivel)
        {
            String resultado = "";
            String receptor;
            if (nickname.Equals(jugador1))
            {
                receptor = jugador2;
            }else
            {
                receptor = jugador1;
            }
            Matriz m = encontrarMatriz(nombre);
            NodoMatriz atacante = null;
            if (m != null)
            {
                atacante = m.getNodo(nombre);
            }


            m = matriz;
            if (nivel == 0)
            {
                m = m.Anterior;
            }else if (nivel == 2)
            {
                m = m.Siguiente;
            }else if (nivel == 3 && m.Siguiente!=null)
            {
                m = m.Siguiente.Siguiente;
            }

            NodoMatriz victima = null;
            if (m != null)
            {
                victima = m.getNodo(fila, columna);
            }
            if (atacante != null && victima!=null && String.Compare(atacante.Nave.Nickname,victima.Nave.Nickname)!=0 && String.Compare(atacante.Nave.Nickname, nickname) == 0 && atacante.Nave.Atacar==0)
            {
                int rango = Math.Abs(atacante.Fila-fila) + Math.Abs(atacante.Columna-columna);
                if (rango <= atacante.Nave.Alcance)
                {
                    if (nombre.ToLower().Contains("fragata"))
                    {
                        if(rango>=2 && rango <= 6)
                        {
                            atacante.Nave.Atacar = 1;
                            victima.Nave.Vida = victima.Nave.Vida - atacante.Nave.Daño;
                            if (victima.Nave.Vida <= 0)
                            {
                                m.Eliminar(victima.Nave.Nombre);
                                resultado = victima.Nave.Nombre;
                                historial.Insertar(columna, fila, nombre, 0, victima.Nave.Nombre, nickname, receptor,DateTime.Today.ToString(), tiempo2, 0);
                                consola = consola + nickname + ": ataco a la unidad " + victima.Nave.Nombre + ". \n";
                            }
                            else
                            {
                                resultado = "1,"+victima.Nave.Nombre;
                                consola = consola + nickname + ": derrivo a la unidad " + victima.Nave.Nombre + ". \n";
                                historial.Insertar(columna, fila, nombre, 1, victima.Nave.Nombre, nickname, receptor, DateTime.Today.ToString(), tiempo2, 0);
                            }
                            
                        }
                        else
                        {
                            resultado="error";
                        }
                    }else if(nombre.ToLower().Contains("bombardero") || nombre.ToLower().Contains("neosatelite"))
                    {
                        if (atacante.Abajo == victima)
                        {
                            atacante.Nave.Atacar = 1;
                            victima.Nave.Vida = victima.Nave.Vida - atacante.Nave.Daño;
                            if (victima.Nave.Vida <= 0)
                            {
                                m.Eliminar(victima.Nave.Nombre);
                                resultado = victima.Nave.Nombre;
                                historial.Insertar(columna, fila, nombre, 0, victima.Nave.Nombre, nickname, receptor, DateTime.Today.ToString(), tiempo2, 0);
                            }
                            else
                            {
                                resultado = "1,"+victima.Nave.Nombre;
                                historial.Insertar(columna, fila, nombre, 1, victima.Nave.Nombre, nickname, receptor, DateTime.Today.ToString(), tiempo2, 0);
                            }
                        }
                        else
                        {
                            resultado = "error";
                        }
                    }else
                    {
                        atacante.Nave.Atacar = 1;
                        victima.Nave.Vida = victima.Nave.Vida - atacante.Nave.Daño;
                        if (victima.Nave.Vida <= 0)
                        {
                            m.Eliminar(victima.Nave.Nombre);
                            resultado = victima.Nave.Nombre;
                            historial.Insertar(columna, fila, nombre, 0, victima.Nave.Nombre, nickname, receptor, DateTime.Today.ToString(), tiempo2, 0);
                        }
                        else
                        {
                            resultado = "1,"+victima.Nave.Nombre;
                            historial.Insertar(columna, fila, nombre, 1, victima.Nave.Nombre, nickname, receptor, DateTime.Today.ToString(), tiempo2, 0);
                        }
                    }
                }else
                {
                    resultado = "error";
                }
            }
            else
            {
                resultado = "error";
            }

            return resultado;
        }

        [WebMethod]
        public void terminarTurno(String nick)
        {
            Matriz ma;
            if (matriz.Anterior != null)
            {
                ma = matriz.Anterior;
            }
            else
            {
                ma = matriz;
            }
            Encabezado fila;
            NodoMatriz m;
            while (ma != null)
            {
                fila = ma.Filas.Cabeza;
                while (fila != null)
                {
                    m = fila.Acceso;
                    while (m != null)
                    {
                        m.Nave.Atacar = 0;
                        m.Nave.Mover = 0;
                        m = m.Derecha;
                    }

                    fila = fila.Siguiente;
                }
                ma = ma.Siguiente;
            }

            if (nick.Equals(jugador1))
            {
                activo = jugador2;
            }
            else
            {
                activo = jugador1;
            }
        }

        [WebMethod]
        public String getActivo()
        {
            return activo;
        }

        [WebMethod]
        public int contarUnidades(String nick)
        {
            int c = 0;
            Matriz ma;
            if (matriz.Anterior != null)
            {
                ma = matriz.Anterior;
            }
            else
            {
                ma = matriz;
            }
            Encabezado fila;
            NodoMatriz m;
            while (ma != null)
            {
                fila = ma.Filas.Cabeza;
                while (fila != null)
                {
                    m = fila.Acceso;
                    while (m != null)
                    {
                        if (m.Nave.Nickname.Equals(nick))
                        {
                            c++;
                        }
                        m = m.Derecha;
                    }

                    fila = fila.Siguiente;
                }
                ma = ma.Siguiente;
            }
            return c;
        }

        private Matriz encontrarMatriz(String nombre)
        {
            Matriz m = matriz;
            if (nombre.ToLower().Contains("submarino"))
            {
                m = m.Anterior;
            }else if(nombre.ToLower().Contains("caza") || nombre.ToLower().Contains("bombardero") || nombre.ToLower().Contains("helicoptero"))
            {
                m = m.Siguiente;
            }
            else if(m.Siguiente!=null && nombre.ToLower().Contains("neosatelite"))
            {
                m = m.Siguiente.Siguiente;
            }
            return m;
        }

        [WebMethod]
        public int getJugador(String nickname)
        {
            if (jugador1.Equals(nickname))
            {
                return 1;
            }else
            {
                return 2;
            }
        }

        [WebMethod]
        public int getDatoInt(int n)
        {
            int r=0;
            switch (n)
            {
                case 0:
                    r = nivel0;
                    break;
                case 1:
                    r = nivel1;
                    break;
                case 2:
                    r = nivel2;
                    break;
                case 3:
                    r = nivel3;
                    break;
                case 4:
                    r = tamañoX;
                    break;
                case 5:
                    r = tamañoY;
                    break;
            }

            return r;
        }

        [WebMethod]
        public String getTiempo()
        {
            return tiempo2;
        }

        [WebMethod]
        public String getOponente(String nick)
        {
            if (nick.Equals(jugador1))
            {
                return jugador2;
            }
            else
            {
                return jugador1;
            }
        }

        [WebMethod]
        public String getTipo()
        {
            return tipo;
        }

        [WebMethod]
        public void definirArbolB(int indice, int parametro)
        {
            historial = new ArbolB(indice, parametro);
        }

        [WebMethod]
        public void valoresPartida(int n0, int n1, int n2, int n3, int tx, int ty, String t)
        {
            nivel0 = n0;
            nivel1 = n1;
            nivel2 = n2;
            nivel3 = n3;
            tamañoX = tx;
            tamañoY = ty;
            tipo = t;
        }

        //----------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------

        [WebMethod]
        public void reiniciarArbol()
        {
            arbol = new ArbolBinario();
        }

        [WebMethod]
        public void reiniciarMatriz()
        {
            matriz = new Matriz(1);
            partidaActiva = false;
            
        }

        [WebMethod]
        public bool getPartidaActiva()
        {
            return partidaActiva;
        }

        [WebMethod]
        public void setPartidaActiva(bool valor)
        {
            partidaActiva = valor;
        }

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

            String comando = "\"C:/Program Files (x86)/Graphviz2.38/bin/dot.exe\" -Tpng C:\\GrafosEDD\\grafoArbol.dot -o C:\\GrafosEDD\\grafoArbol2.png";
            var procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd.exe", "/c" + comando);
            var proc = new System.Diagnostics.Process { StartInfo= procStartInfo };
            proc.Start();
            proc.WaitForExit();

            FileStream foto = new FileStream("C:\\GrafosEDD\\grafoArbol2.png", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            a = new Byte[foto.Length];
            BinaryReader reader = new BinaryReader(foto);
            a = reader.ReadBytes(Convert.ToInt32(foto.Length));
            foto.Close();

            return a;
        }

        [WebMethod]
        public Byte[] espejoArbol()
        {
            arbol2=new ArbolBinario();
            arbol2.Raiz = espejo(arbol.Raiz);
            dot = "digraph ABB{\n node[shape=record];{\n";
            nodosArbol(arbol2.Raiz);
            dot = dot + "}\n";
            enlacesNodosArbol(arbol2.Raiz);
            dot = dot + "}\n";

            TextWriter t = new StreamWriter(@"C:\GrafosEDD\grafoArbol2.dot");
            t.WriteLine(dot);
            t.Close();

            Byte[] a = new Byte[0];

            String comando = "\"C:/Program Files (x86)/Graphviz2.38/bin/dot.exe\" -Tpng C:\\GrafosEDD\\grafoArbol2.dot -o C:\\GrafosEDD\\grafoArbol2.png";
            var procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd.exe", "/c" + comando);
            var proc = new System.Diagnostics.Process { StartInfo = procStartInfo };
            proc.Start();
            proc.WaitForExit();

            FileStream foto = new FileStream("C:\\GrafosEDD\\grafoArbol2.png", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            a = new Byte[foto.Length];
            BinaryReader reader = new BinaryReader(foto);
            a = reader.ReadBytes(Convert.ToInt32(foto.Length));
            foto.Close();

            return a;
        }

        [WebMethod]
        public Byte[] arbolBGrafo()
        {
            dot = "digraph ArbolB{\n node[shape=record];{\n";
            nodosB(historial.Raiz);
            dot = dot + "}\n";
            enlacesB(historial.Raiz);
            dot = dot + "}\n";

            TextWriter t = new StreamWriter(@"C:\GrafosEDD\grafoArbolB.dot");
            t.WriteLine(dot);
            t.Close();

            Byte[] a = new Byte[0];
            String comando = "\"C:/Program Files (x86)/Graphviz2.38/bin/dot.exe\" -Tpng C:\\GrafosEDD\\grafoArbolB.dot -o C:\\GrafosEDD\\grafoArbolB.png";
            var procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd.exe", "/c" + comando);
            var proc = new System.Diagnostics.Process { StartInfo = procStartInfo };
            proc.Start();
            proc.WaitForExit();

            FileStream foto = new FileStream("C:\\GrafosEDD\\grafoArbolB.png", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            a = new Byte[foto.Length];
            BinaryReader reader = new BinaryReader(foto);
            a = reader.ReadBytes(Convert.ToInt32(foto.Length));
            foto.Close();

            return a;
        }

        [WebMethod]
        public Byte[] AVLGrafo(String nickname)
        {
            NodoArbol nodo = arbol.Buscar(nickname, arbol.Raiz);
            Byte[] a = new Byte[0];

            dot = "digraph AVL{\n node[shape=record];{\n";
            nodosAVL(nodo.Contactos.Raiz);
            dot = dot + "}\n";
            enlacesAVL(nodo.Contactos.Raiz);
            dot = dot + "}\n";

            TextWriter t = new StreamWriter(@"C:\GrafosEDD\grafoAVL.dot");
            t.WriteLine(dot);
            t.Close();


            String comando = "\"C:/Program Files (x86)/Graphviz2.38/bin/dot.exe\" -Tpng C:\\GrafosEDD\\grafoAVL.dot -o C:\\GrafosEDD\\grafoAVL.png";
            var procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd.exe", "/c" + comando);
            var proc = new System.Diagnostics.Process { StartInfo = procStartInfo };
            proc.Start();
            proc.WaitForExit();

            FileStream foto = new FileStream("C:\\GrafosEDD\\grafoAVL.png", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            a = new Byte[foto.Length];
            BinaryReader reader = new BinaryReader(foto);
            a = reader.ReadBytes(Convert.ToInt32(foto.Length));
            foto.Close();

            return a;
        }

        private void nodosAVL(NodoAVL n)
        {
            if (n != null)
            {
                dot = dot + n.Nickname + "[label=\"<f0>|<f1>Nickname: " + n.Nickname + "|<f2>\"]\n";
                nodosAVL(n.Izquierda);
                nodosAVL(n.Derecha);
            }
        }

        private void enlacesAVL(NodoAVL n)
        {
            if (n != null)
            {
                if (n.Derecha != null)
                {
                    dot = dot + n.Nickname + ":f2->" + n.Derecha.Nickname + ":f1;\n";
                }

                if (n.Izquierda != null)
                {
                    dot = dot + n.Nickname + ":f0->" + n.Izquierda.Nickname + ":f1;\n";
                }

                enlacesAVL(n.Izquierda);
                enlacesAVL(n.Derecha);
            }
        }

        [WebMethod]
        public void InsertarContacto(String usuario, String nickname, String contraseña, String correo)
        {
            NodoArbol n = arbol.Buscar(usuario,arbol.Raiz);
            if (n != null)
            {
                if (arbol.Buscar(nickname, arbol.Raiz) != null)
                {
                    n.Contactos.Insertar(arbol.Buscar(nickname, arbol.Raiz));
                }else
                {
                    n.Contactos.Insertar(nickname, contraseña, correo);
                }
            }
        }

        [WebMethod]
        public void insertarArbolB(int x, int y, String unidadAtacante, int resultado, String unidadDañada, String emisor, String receptor, String fecha, String tiempoRestante, int numero)
        {
            historial.Insertar(x, y, unidadAtacante, resultado, unidadDañada, emisor, receptor, fecha, tiempoRestante, numero);
        }

        public void nodosB(HojaB n)
        {
            if (n != null)
            {
                dot = dot + n.Nodos[0].Id + "[label=\"<f0>";
                int j = 1;
                for(int i = 0; i < n.Nodos.Length; i++)
                {
                    if (n.Nodos[i] != null)
                    {
                        dot = dot + "|<f" + j.ToString() + "> Ataco: " + n.Nodos[i].UnidadAtacante
                        + "\\n Recibio: " + n.Nodos[i].UnidadDañada + "\\n Coordenadas(X,Y): (" + (Convert.ToChar(n.Nodos[i].X)).ToString()
                        + "," + n.Nodos[i].Y.ToString() + ")\\n Numero: " + n.Nodos[i].Numero.ToString();
                        j++;
                        dot = dot + "|<f" + j.ToString() + ">";
                        j++;
                    }
                    else
                    {
                        break;
                    }
                }

                dot = dot + "\"]\n";

                nodosB(n.Nodos[0].Izquierda);
                for(int i = 0; i < n.Nodos.Length; i++)
                {
                    if (n.Nodos[i] != null)
                    {
                        nodosB(n.Nodos[i].Derecha);
                    }else
                    {
                        break;
                    }
                }
            }
        }

        public void enlacesB(HojaB n)
        {
            if (n != null && n.Nodos[0].Izquierda!=null)
            {
                int j = 0;
                dot = dot + n.Nodos[0].Id + ":f0->" + n.Nodos[0].Izquierda.Nodos[0].Id + ";\n" ;
                j = j + 2;
                for(int i = 0; i < n.Nodos.Length; i++)
                {
                    if (n.Nodos[i] != null)
                    {
                        dot = dot + n.Nodos[0].Id + ":f" + j.ToString() + "->" + n.Nodos[i].Derecha.Nodos[0].Id + ";\n";
                    }else
                    {
                        break;
                    }
                    j = j + 2;
                }

                enlacesB(n.Nodos[0].Izquierda);
                for (int i = 0; i < n.Nodos.Length; i++)
                {
                    if (n.Nodos[i] != null)
                    {
                        enlacesB(n.Nodos[i].Derecha);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        public NodoArbol espejo(NodoArbol n)
        {
            NodoArbol e = null;
            if (n != null)
            {
                e = new NodoArbol(n.NickName, n.Contraseña, n.Correo, n.Conexion);
                e.Der = espejo(n.Izq);
                e.Izq = espejo(n.Der);
            }
            return e;
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
                dot = dot + n.NickName + "[label=\"<f0>|<f1>Nickname: " + n.NickName + "\\n Password: " + n.Contraseña + "\\\n Correo: " + n.Correo + "|<f2>\"]\n";
                NodoLista aux = n.Lista.Cabeza;
                int i = 0;
                while (aux != null)
                {
                    dot = dot + n.NickName + i.ToString() + "[label=\"Oponente: "+aux.Oponente+"\\n Desplegadas: "+aux.Desplegadas.ToString()+"\\n Destruidas: "+aux.Destruidas.ToString()+"\\n Sobrevivientes: "+aux.Sobrevivientes.ToString()+"\"]\n";
                    i++;
                    aux = aux.Siguiente;
                }
                nodosArbol(n.Izq);
                nodosArbol(n.Der);
            }
        }

        [WebMethod]
        public Byte[] MatrizGrafo(int nivel, String nick)
        {
            Matriz m = matriz;
            if (m.Nivel != nivel)
            {
                if (nivel == 0)
                {
                    if (nick.Equals(""))
                    {
                        m = m.Anterior;
                    }
                    else
                    {
                        m = generarNuevaMatriz(nick).Anterior;
                    }
                }else if(nivel >= 2)
                {
                    m = m.Siguiente;
                    while (m != null)
                    {
                        if (m.Nivel == nivel)
                        {
                            break;
                        }
                        m = m.Siguiente;
                    }
                }
            }

            if (m != null)
            {
                dot = "digraph Matriz{\n rankdir=UD;\n node[shape=box];\n {\n rank=min;\n m[label=\"Matriz " +m.Nivel.ToString() + "\"];\n";
                Encabezado column = m.Columnas.Cabeza;
                while (column != null)
                {
                    dot = dot + "Y"+column.Id.ToString()+"[label=\""+Convert.ToChar(column.Id).ToString()+"\",rankdir=LR];\n";
                    column = column.Siguiente;
                }

                dot = dot + "}\n";

                Encabezado f = m.Filas.Cabeza;
                NodoMatriz n;
                while (f != null)
                {
                    dot = dot + "{\n rank=same;\n X" + f.Id.ToString() + "[label=\"" + f.Id.ToString() + "\"]\n";
                    n = f.Acceso;
                    while (n != null)
                    {
                        dot = dot + "F" + n.Fila.ToString() + "_C" + Convert.ToChar(n.Columna).ToString() + "[label=\"Nombre: " + n.Nave.Nombre +"--Vida: "+n.Nave.Vida.ToString()+ "\"]\n";
                        n = n.Derecha;
                    }
                    dot = dot + "}\n";
                    f = f.Siguiente;
                }

                //ENLACES COLUMNAS
                column = m.Columnas.Cabeza;

                if (column != null)
                {
                    dot = dot + "m->Y" + column.Id.ToString()+";\n";
                    while (column.Siguiente != null)
                    {
                        dot = dot + "Y" + column.Id.ToString() + "->Y" + column.Siguiente.Id.ToString() + ";\n";
                        dot = dot + "Y" + column.Siguiente.Id.ToString() + "->Y" + column.Id.ToString() + ";\n";
                        column = column.Siguiente;
                    }

                    column = m.Columnas.Cabeza;
                    while (column != null)
                    {
                        dot = dot + "Y" + column.Id.ToString() + "->F" + column.Acceso.Fila.ToString() + "_C" + Convert.ToChar(column.Id).ToString() + ";\n";
                        column = column.Siguiente;
                    }
                }

                //ENLACES FILAS
                f = m.Filas.Cabeza;
                if (f != null)
                {
                    dot = dot + "m->X" + f.Id.ToString() + "[rankdir=UD];\n";
                    while (f.Siguiente != null)
                    {
                        dot = dot + "X" + f.Id.ToString() + "->X" + f.Siguiente.Id.ToString() + "[rankdir=UD];\n";
                        dot = dot + "X" + f.Siguiente.Id.ToString() + "->X" + f.Id.ToString() + "[rankdir=UD];\n";
                        f = f.Siguiente;
                    }

                    f = m.Filas.Cabeza;
                    while (f != null)
                    {
                        n = f.Acceso;
                        dot = dot + "X" + f.Id.ToString() + "->F" + f.Id.ToString() + "_C" + Convert.ToChar(n.Columna).ToString() + "[constraint=false];\n";
                        while (n.Derecha != null)
                        {
                            dot = dot + "F" + n.Fila.ToString() + "_C" + Convert.ToChar(n.Columna).ToString() + "->F" + n.Derecha.Fila.ToString() + "_C" + Convert.ToChar(n.Derecha.Columna).ToString() + "[constraint=false];\n";
                            dot = dot + "F" + n.Derecha.Fila.ToString() + "_C" + Convert.ToChar(n.Derecha.Columna).ToString() + "->F" + n.Fila.ToString() + "_C" + Convert.ToChar(n.Columna).ToString() + "[constraint=false];\n";
                            n = n.Derecha;
                        }
                        f = f.Siguiente;
                    }
                }

                dot = dot + "}\n";

                TextWriter t = new StreamWriter(@"C:\GrafosEDD\grafoMatriz.dot");
                t.WriteLine(dot);
                t.Close();

            }

            Byte[] a = new Byte[0];

            String comando = "\"C:/Program Files (x86)/Graphviz2.38/bin/dot.exe\" -Tpng C:\\GrafosEDD\\grafoMatriz.dot -o C:\\GrafosEDD\\grafoMatriz.png";
            var procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd.exe", "/c" + comando);
            var proc = new System.Diagnostics.Process { StartInfo = procStartInfo };
            proc.Start();
            proc.WaitForExit();

            FileStream foto = new FileStream("C:\\GrafosEDD\\grafoMatriz.png", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            a = new Byte[foto.Length];
            BinaryReader reader = new BinaryReader(foto);
            a = reader.ReadBytes(Convert.ToInt32(foto.Length));
            foto.Close();

            return a;
        }

        private Matriz generarNuevaMatriz(String nick)
        {
            Matriz m = new Matriz(1);
            if (matriz.Anterior != null)
            {
                Encabezado fila = matriz.Anterior.Filas.Cabeza;
                while (fila != null)
                {
                    NodoMatriz n = fila.Acceso;
                    while (n != null)
                    {
                        if (n.Nave.Nickname.Equals(nick))
                        {
                            m.Insertar(n.Fila, n.Columna, n.Nave.Nombre, nick);
                        }
                        n = n.Derecha;
                    }
                    fila = fila.Siguiente;
                }
            }

            return m;
        }

        [WebMethod]
        public void CerrarSesion(String nickname)
        {
            arbol.Buscar(nickname, arbol.Raiz).Conexion = 0;
            if (jugador1.Equals(nickname))
            {
                jugador1 = "";
            }else if (jugador2.Equals(nickname))
            {
                jugador2 = "";
            }
            if(jugador1.Equals("") && jugador2.Equals(""))
            {
                partidaActiva = false;
                reiniciarMatriz();
                tiempo2 = "";
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
                    if (jugador1.Equals("") || jugador1.Equals(nickname))
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
            partidaActiva = true;
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
