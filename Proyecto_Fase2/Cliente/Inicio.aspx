<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="EddCliente.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Inicio</title>
    <link href="estilo.css" rel="stylesheet" />
</head>
<body background="http://192.168.1.8/Imagenes/Fondo">
    <form id="form1" runat="server">
    <div align="center">
        <h1>Iniciar Sesion</h1>
    </div>

    <div align="right">
        <asp:Panel CssClass="panel" ID="Panel1" runat="server" Width="407px">
            <div align="center">
                 <br />
                    &nbsp;&nbsp;
                    <asp:Label ID="labelUsuario" runat="server" Text="Nickname  "></asp:Label>
                    <asp:TextBox ID="textUsuario" runat="server" Width="100px"></asp:TextBox>
                    <asp:Label ID="labelContraseña" runat="server" Text="Contraseña"></asp:Label>
                    <asp:TextBox ID="textContraseña" runat="server" Width="100px" TextMode="Password"></asp:TextBox>
                    <br />
                   <br />
                <asp:Button ID="botonIniciarSesion" runat="server" Text="Iniciar Sesion" OnClick="botonIniciarSesion_Click" />
                    <br />
                    <br />
                    <asp:Label ID="labelRegistro" runat="server" Text="Ingrese sus datos para iniciar sesion"></asp:Label>
                    <br />
                    <br />

                <asp:Label ID="labelPrueba" runat="server" Font-Size="13pt" ForeColor="Red"></asp:Label>
            </div>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
