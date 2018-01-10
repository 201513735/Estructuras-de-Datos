using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;

namespace EddCliente
{
    public partial class Juego : System.Web.UI.Page
    {
        static ReferenciaServidor.WebServiceSoapClient ws;
        static String nick;
        static int desplegadas, destruidas=0;

        protected void Page_Load(object sender, EventArgs e)
        {
            ws = new ReferenciaServidor.WebServiceSoapClient();
            if (moverX.Items.Count == 0)
            {
                desplegadas = Convert.ToInt32(Session["desplegadas"]);
                nick = Session["nickname"].ToString();
                int x = ws.getDatoInt(4);
                int y = ws.getDatoInt(5);
                for (int i = 0; i < x; i++)
                {
                    moverX.Items.Add(Convert.ToChar(65 + i).ToString());
                    atacarX.Items.Add(Convert.ToChar(65 + i).ToString());
                }

                for(int i = 1; i <= y; i++)
                {
                    moverY.Items.Add(i.ToString());
                    atacarY.Items.Add(i.ToString());
                }
                actualizarTablero();
            }
        }

        protected void botonCerrarSesion_Click(object sender, EventArgs e)
        {
            ws.CerrarSesion(Session["nickname"].ToString());
            Session["nickname"] = "";
            Server.Transfer("Inicio.aspx");
        }

        protected void botonMover_Click(object sender, EventArgs e)
        {
            if (ws.moverUnidad(textUnidad.Text, Convert.ToInt32(Convert.ToChar(moverX.Text)),Convert.ToInt32(moverY.Text), Session["nickname"].ToString() ))
            {
                textConsola.Text = ws.getConsola();
                actualizarTablero();
            }
            else
            {
                textConsola.Text = textConsola.Text + Session["nickname"].ToString() + ": ERROR al mover la unidad " + textUnidad.Text+". \n";
            }
        }

        public void actualizarTablero()
        {
            Byte[] a = ws.MatrizGrafo(0,nick);

            string c = Convert.ToBase64String(a, 0, a.Length);
            Img0.Src = "data:image/jpg;base64," + c;

            a = ws.MatrizGrafo(1, nick);
            c = Convert.ToBase64String(a, 0, a.Length);
            Img1.Src = "data:image/jpg;base64," + c;

            a = ws.MatrizGrafo(2, nick);
            c = Convert.ToBase64String(a, 0, a.Length);
            Img2.Src = "data:image/jpg;base64," + c;

            a = ws.MatrizGrafo(3, nick);
            c = Convert.ToBase64String(a, 0, a.Length);
            Img3.Src = "data:image/jpg;base64," + c;

        }

        protected void botonAtacar_Click(object sender, EventArgs e)
        {
            String r = ws.atacarUnidad(textUnidad.Text, Convert.ToInt32(Convert.ToChar(atacarX.Text)), Convert.ToInt32(atacarY.Text), Session["nickname"].ToString(), nivel.SelectedIndex);
            if (r.Equals("error"))
            {
                textConsola.Text = textConsola.Text + Session["nickname"].ToString() + ": ERROR al atacar con la unidad " + textUnidad.Text + ". \n";
            }
            else
            {
                String[] array = r.Split(',');
                if (array.Length == 2)
                {
                    textConsola.Text = textConsola.Text + Session["nickname"].ToString() + ": " + textUnidad.Text + " derribo a " + array[2]+". \n";
                    destruidas++;
                    textConsola.Text = ws.getConsola();
                    if (ws.contarUnidades(ws.getOponente(Session["nickname"].ToString())) == 0)
                    {
                        ws.terminarPartida(Session["nickname"].ToString(), ws.getOponente(Session["nickname"].ToString()), Convert.ToInt32(Session["desplegadas"]), ws.contarUnidades(Session["nickname"].ToString()), Convert.ToInt32(Session["destruidas"]), 1);
                        textConsola.Text = "FELICIDADES GANO LA PARTIDA";
                    }
                }
                else
                {
                    textConsola.Text = ws.getConsola();
                }
                actualizarTablero();
            }

            
        }

        protected void botonActualizar_Click(object sender, EventArgs e)
        {
            actualizarTablero();
            if (ws.getActivo().Equals(nick))
            {
                labelTurno.Text = "Es su Turno";
                botonAtacar.Visible = true;
                botonMover.Visible = true;
                botonTerminarTurno.Visible = true;
            }else if (ws.contarUnidades(nick) == 0)
            {
                ws.terminarPartida(nick, ws.getOponente(Session["nickname"].ToString()), Convert.ToInt32(Session["desplegadas"]), ws.contarUnidades(Session["nickname"].ToString()), Convert.ToInt32(Session["destruidas"]), 0);
                textConsola.Text = "PERDIO LA PARTIDA";
            }
        }

        protected void botonTerminarTurno_Click(object sender, EventArgs e)
        {
            ws.terminarTurno(nick);
            labelTurno.Text = "Turno del oponente. Presione Actualizar para verificar.";
            botonAtacar.Visible = false;
            botonMover.Visible = false;
            botonTerminarTurno.Visible = false;
        }
         
    }
}