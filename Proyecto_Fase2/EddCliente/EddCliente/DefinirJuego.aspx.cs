using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EddCliente
{
    public partial class DefinirJuego : System.Web.UI.Page
    {
        ReferenciaServidor.WebServiceSoapClient ws;
        protected void Page_Load(object sender, EventArgs e)
        {
            ws = new ReferenciaServidor.WebServiceSoapClient();
            labelTiempo.Visible = false;
            textTiempo.Visible = false;
        }

        protected void botonFinalizar_Click(object sender, EventArgs e)
        {
            try
            {
                int nivel0 = Convert.ToInt32(textNivel0.Text),
                    nivel1 = Convert.ToInt32(textNivel1.Text),
                    nivel2 = Convert.ToInt32(textNivel2.Text),
                    nivel3 = Convert.ToInt32(textNivel3.Text),
                    X = Convert.ToInt32(textX.Text),
                    Y = Convert.ToInt32(textY.Text);
                String tipo = tipoPartida.Text;
                ws.valoresPartida(nivel0, nivel1, nivel2, nivel3, X, Y, tipo);
                ws.setPartidaActiva(true);
                ws.reiniciarMatriz();
                ws.definirArbolB(Convert.ToInt32(textIndice.Text),parametroB.SelectedIndex+1);
                Server.Transfer("ColocarUnidades.aspx");
            }
            catch (Exception)
            {
                labelError.Text = "Parametros Incorrectos";
                
            }
        }

        protected void tipoPartida_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tipoPartida.Text == "Tiempo")
            {
                labelTiempo.Visible = true;
                textTiempo.Visible = true;
            }
            else
            {
                labelTiempo.Visible = false;
                textTiempo.Visible = false;
                textTiempo.Text = "";
            }
        }
    }
}