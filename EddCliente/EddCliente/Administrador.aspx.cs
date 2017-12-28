using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            
        }

        protected void botonCerrarSesion_Click(object sender, EventArgs e)
        {
            Label1.Text = ws.devolver();
        }

        protected void botonReporteUsuarios_Click(object sender, EventArgs e)
        {
            string c = Convert.ToBase64String(ws.Usuariosgrafo(), 0, ws.Usuariosgrafo().Length);
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
    }
}