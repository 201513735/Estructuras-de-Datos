using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EddCliente
{
    public partial class ColocarUnidades : System.Web.UI.Page
    {
        static int n0, n1, n2, n3,y,x;
        static int colocada = 0, jugador;
        ReferenciaServidor.WebServiceSoapClient ws= new ReferenciaServidor.WebServiceSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (coordenadaX.Items.Count == 0)
            {
                Session.Add("desplegadas", "0");
                n0 = ws.getDatoInt(0);
                n1 = ws.getDatoInt(1);
                n2 = ws.getDatoInt(2);
                n3 = ws.getDatoInt(3);
                y = ws.getDatoInt(5);
                x = ws.getDatoInt(4);
                jugador = ws.getJugador(Session["nickname"].ToString());

                for (int i = 0; i < x; i++)
                {
                    coordenadaX.Items.Add(Convert.ToChar(65 + i).ToString());
                    baseX.Items.Add(Convert.ToChar(65 + i).ToString());
                }

                int medio = y / 2;
                String nickname = Session["nickname"].ToString();
                if (ws.getJugador(nickname) == 1)
                {
                    for (int i = 1; i <= medio; i++)
                    {
                        coordenadaY.Items.Add(i.ToString());
                        baseY.Items.Add(i.ToString());
                    }
                }
                else
                {
                    for (int i = medio + 1; i <= y; i++)
                    {
                        coordenadaY.Items.Add(i.ToString());
                        baseY.Items.Add(i.ToString());
                    }
                }
            }
            

            if (ws.getTipo().Equals("Base"))
            {
                panelBase.Visible = true;
                panelTiempo.Visible = false;
            }else if (ws.getTipo().Equals("Tiempo"))
            {
                if (ws.getTiempo().Equals(""))
                {
                    panelBase.Visible = false;
                    panelTiempo.Visible = true;
                }
            }else
            {
                panelBase.Visible = false;
                panelTiempo.Visible = false;
            }
        }

        protected void botonJugar_Click(object sender, EventArgs e)
        {
            if (panelTiempo.Visible)
            {
                ws.setTiempo(textTiempo.Text);
            }else if(panelBase.Visible)
            {
                ws.setBase(Convert.ToInt32(baseX.Text), Convert.ToInt32(baseY.Text),ws.getJugador(Session["nickname"].ToString()));
            }
            Server.Transfer("Juego.aspx");
        }

        protected void agregarUnidad_Click(object sender, EventArgs e)
        {
            colocada++;
            jugador = ws.getJugador(Session["nickname"].ToString());
            if (unidad.Text.Equals("Submarino"))
            {
                if (n0 > 0)
                {
                    n0--;
                    Session["desplegadas"] = Convert.ToInt32(Session["desplegadas"]) + 1;
                    ws.InsertarMatriz(Convert.ToInt32(coordenadaY.Text), Convert.ToChar(coordenadaX.Text), jugador.ToString()+unidad.Text+colocada.ToString(), Session["nickname"].ToString());
                    labelError.Text = "";
                }
                else
                {
                    labelError.Text = "No puede Agregar mas unidades en ese nivel.";
                }
            }else if(unidad.Text.Equals("Fragata") || unidad.Text.Equals("Crucero"))
            {
                if (n1 > 0)
                {
                    labelError.Text = "";
                    n1--;
                    Session["desplegadas"] = Convert.ToInt32(Session["desplegadas"]) + 1;
                    ws.InsertarMatriz(Convert.ToInt32(coordenadaY.Text), Convert.ToChar(coordenadaX.Text), jugador.ToString() + unidad.Text + colocada.ToString(), Session["nickname"].ToString());
                }
                else
                {
                    labelError.Text = "No puede Agregar mas unidades en ese nivel.";
                }
            }
            else if(unidad.Text.Equals("Caza") || unidad.Text.Equals("Helicoptero") || unidad.Text.Equals("Bombardero"))
            {
                if (n2 > 0)
                {
                    labelError.Text = "";
                    n2--;
                    Session["desplegadas"] = Convert.ToInt32(Session["desplegadas"]) + 1;
                    ws.InsertarMatriz(Convert.ToInt32(coordenadaY.Text), Convert.ToChar(coordenadaX.Text), jugador.ToString() + unidad.Text + colocada.ToString(), Session["nickname"].ToString());
                }
                else
                {
                    labelError.Text = "No puede Agregar mas unidades en ese nivel.";
                }
            }
            else if (unidad.Text.Equals("Neosatelite"))
            {
                if (n3 > 0)
                {
                    labelError.Text = "";
                    n3--;
                    Session["desplegadas"] = Convert.ToInt32(Session["desplegadas"]) + 1;
                    ws.InsertarMatriz(Convert.ToInt32(coordenadaY.Text), Convert.ToChar(coordenadaX.Text), jugador.ToString() + unidad.Text + colocada.ToString(), Session["nickname"].ToString());
                }
                else
                {
                    labelError.Text = "No puede Agregar mas unidades en ese nivel.";
                }
            }

            labelUnidades.Text = "Submarino: " + n0.ToString() + "\n Barcos: " + n1.ToString() + "\n Aviones: " + n2.ToString() + "\n Satelites: " + n3.ToString();
        }
    }
}