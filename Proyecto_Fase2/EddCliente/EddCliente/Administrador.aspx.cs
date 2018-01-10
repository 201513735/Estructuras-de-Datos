using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EddCliente
{
    public partial class Administrador : System.Web.UI.Page
    {
        ReferenciaServidor.WebServiceSoapClient ws;
        protected void Page_Load(object sender, EventArgs e)
        {
            ws = new ReferenciaServidor.WebServiceSoapClient();
        }

        protected void botonInsertarUsuario_Click(object sender, EventArgs e)
        {
            if (!textUsuario.Text.Equals(""))
            {
                ws.InsertarArbol(textUsuario.Text, textContraseña.Text, textCorreo.Text, 0);
            }
        }

        protected void botonCargarJugadores_Click(object sender, EventArgs e)
        {
            String[] lineas;
            String[] datos;
            if (fileJugadores.HasFile)
            {
                //labelArchivo.Text= System.Text.Encoding.UTF8.GetString(fileJugadores.FileBytes);
                lineas= System.Text.Encoding.UTF8.GetString(fileJugadores.FileBytes).Split(Convert.ToChar(10));
                for(int i = 1; i < lineas.Length; i++)
                {
                    datos = lineas[i].Split(',');
                    if (datos.Length ==4)
                    {
                        ws.InsertarArbol(datos[0],datos[1],datos[2],Convert.ToInt32(datos[3].Trim()));
                    }
                }
            }
            else
            {
                labelArchivo.Text = "Archivo no encontrado.";
            }
        }

        protected void botonCerrarSesion_Click(object sender, EventArgs e)
        {
            Server.Transfer("Inicio.aspx");
        }

        protected void botonReporteUsuarios_Click(object sender, EventArgs e)
        {
            Byte[] a = ws.Usuariosgrafo();

            string c = Convert.ToBase64String(a, 0, a.Length);
            imagenGrafo.Src = "data:image/jpg;base64," + c;
        }

        protected void botonEliminarUsuario_Click(object sender, EventArgs e)
        {
            ws.EliminarUsuario(textUsuario.Text);
        }

        protected void botonModificarUsuario_Click(object sender, EventArgs e)
        {
            ws.ModificarUsuario(textUsuario.Text, textNuevoNickname.Text, textContraseña.Text, textCorreo.Text);
        }

        protected void botonReporteMatriz_Click(object sender, EventArgs e)
        {
            Byte[] a = ws.MatrizGrafo(Convert.ToInt32(textNivelMatriz.Text),"");

            string c = Convert.ToBase64String(a, 0, a.Length);
            imagenGrafo.Src = "data:image/jpg;base64," + c;
        }

        protected void botonCargarJuegos_Click(object sender, EventArgs e)
        {
            String[] lineas;
            String[] datos;
            if (fileJugadores.HasFile)
            {
                //labelArchivo.Text= System.Text.Encoding.UTF8.GetString(fileJugadores.FileBytes);
                lineas = System.Text.Encoding.UTF8.GetString(fileJugadores.FileBytes).Split(Convert.ToChar(10));
                for (int i = 1; i < lineas.Length; i++)
                {
                    datos = lineas[i].Split(',');
                    if (datos.Length == 6)
                    {
                        ws.InsertarJuego(datos[0], datos[1], Convert.ToInt32(datos[2].Trim()), Convert.ToInt32(datos[3].Trim()), Convert.ToInt32(datos[4].Trim()), Convert.ToInt32(datos[5].Trim()));
                    }
                }
            }
            else
            {
                labelArchivo.Text = "Archivo no encontrado.";
            }
        }

        protected void botonCargarTablero_Click(object sender, EventArgs e)
        {
            String[] lineas;
            String[] datos;
            if (fileJugadores.HasFile)
            {
                //labelArchivo.Text= System.Text.Encoding.UTF8.GetString(fileJugadores.FileBytes);
                lineas = System.Text.Encoding.UTF8.GetString(fileJugadores.FileBytes).Split(Convert.ToChar(10));
                for (int i = 1; i < lineas.Length; i++)
                {
                    datos = lineas[i].Split(',');
                    if (datos.Length == 5)
                    {
                        if (Convert.ToInt32(datos[4]) == 1)
                        {
                            ws.InsertarMatriz(Convert.ToInt32(datos[2].Trim()), Convert.ToInt32(Convert.ToChar(datos[1].Trim())), datos[3], datos[0]);
                        }else
                        {

                        }
                    }
                }
            }
            else
            {
                labelArchivo.Text = "Archivo no encontrado.";
            }
        }

        protected void botonLimpiarArbol_Click(object sender, EventArgs e)
        {
            ws.reiniciarArbol();
        }

        protected void botonLimpiarMatriz_Click(object sender, EventArgs e)
        {
            ws.reiniciarMatriz();
        }

        protected void botonEspejoUsuarios_Click(object sender, EventArgs e)
        {
            Byte[] a = ws.espejoArbol();

            string c = Convert.ToBase64String(a, 0, a.Length);
            imagenGrafo.Src = "data:image/jpg;base64," + c;
        }

        protected void botonCargarHistorial_Click(object sender, EventArgs e)
        {
            String[] lineas;
            String[] datos;
            if (fileJugadores.HasFile)
            {
                lineas = System.Text.Encoding.UTF8.GetString(fileJugadores.FileBytes).Split(Convert.ToChar(10));
                for (int i = 1; i < lineas.Length; i++)
                {
                    datos = lineas[i].Split(',');
                    if (datos.Length == 10)
                    {
                        ws.insertarArbolB(Convert.ToInt32(datos[0]), Convert.ToInt32(datos[1]), datos[2], Convert.ToInt32(datos[3]), datos[4], datos[5], datos[6], datos[7], datos[8], Convert.ToInt32(datos[9]));
                    }
                }
            }
            else
            {
                labelArchivo.Text = "Archivo no encontrado.";
            }
        }

        protected void botonReporteB_Click(object sender, EventArgs e)
        {
            Byte[] a= ws.arbolBGrafo();

            string c = Convert.ToBase64String(a, 0, a.Length);
            imagenGrafo.Src = "data:image/jpg;base64," + c;
        }

        protected void botonCargarContactos_Click(object sender, EventArgs e)
        {
            String[] lineas;
            String[] datos;
            if (fileJugadores.HasFile)
            {
                lineas = System.Text.Encoding.UTF8.GetString(fileJugadores.FileBytes).Split(Convert.ToChar(10));
                for (int i = 1; i < lineas.Length; i++)
                {
                    datos = lineas[i].Split(',');
                    if (datos.Length == 4)
                    {
                        ws.InsertarContacto(datos[0], datos[1], datos[2], datos[3]);
                    }
                }
            }
            else
            {
                labelArchivo.Text = "Archivo no encontrado.";
            }
        }

        protected void botonContactos_Click(object sender, EventArgs e)
        {
            Byte[] a = ws.AVLGrafo(textUsuario.Text);

            string c = Convert.ToBase64String(a, 0, a.Length);
            imagenGrafo.Src = "data:image/jpg;base64," + c;
        }

        protected void botonEliminarContacto_Click(object sender, EventArgs e)
        {
            ws.accionContactos("Eliminar", textUsuario.Text, textNuevoNickname.Text, textContraseña.Text, textCorreo.Text);
        }

        protected void botonAgregarContacto_Click(object sender, EventArgs e)
        {
            ws.accionContactos("Agregar", textUsuario.Text, textNuevoNickname.Text, textContraseña.Text, textCorreo.Text);
        }

        protected void botonTopContactos_Click(object sender, EventArgs e)
        {
            Byte[] a = ws.topGrafo("Contactos");

            string c = Convert.ToBase64String(a, 0, a.Length);
            imagenGrafo.Src = "data:image/jpg;base64," + c;
        }

        protected void botonTopEliminados_Click(object sender, EventArgs e)
        {
            Byte[] a = ws.topGrafo("Eliminados");

            string c = Convert.ToBase64String(a, 0, a.Length);
            imagenGrafo.Src = "data:image/jpg;base64," + c;
        }

        protected void botonGenerarHash_Click(object sender, EventArgs e)
        {
            Byte[] a = ws.tablaGrafo();

            string c = Convert.ToBase64String(a, 0, a.Length);
            imagenGrafo.Src = "data:image/jpg;base64," + c;
        }
    }
}