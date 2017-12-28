﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EddCliente
{
    public partial class Inicio : System.Web.UI.Page
    {
        ReferenciaServidor.WebServiceSoapClient ws;
        String nickname;

        protected void Page_Load(object sender, EventArgs e)
        {
            ws = new ReferenciaServidor.WebServiceSoapClient();
        }

        protected void botonIniciarSesion_Click(object sender, EventArgs e)
        {
            if (textUsuario.Text.ToLower() == "admin" && textContraseña.Text=="1234")
            {
                nickname = "admin";
                labelPrueba.Text = "administrador";
                Server.Transfer("Administrador.aspx");
            }
            else
            {
                if (ws.IniciarSesion(labelUsuario.Text, labelContraseña.Text))
                {
                    nickname = labelUsuario.Text;
                }
                else
                {
                    labelPrueba.Text = "Usuario o contraseña incorrectos.";
                }
            }
        }

    }
}