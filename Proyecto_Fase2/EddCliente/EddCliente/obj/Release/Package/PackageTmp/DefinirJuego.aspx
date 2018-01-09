<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DefinirJuego.aspx.cs" Inherits="EddCliente.DefinirJuego" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Definir Juego</title>
    <link href="estilo2.css" rel="stylesheet" />
    <style type="text/css"></style>

</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
        <h1>Parametros de Juego</h1>
    </div>

    <div align="right">
        <asp:Panel CssClass="panel" ID="Panel1" runat="server" Width="430px">
            <div align="center">
                Defina los Parametros de la Partida.
                <br />
                <br />
                Tipo de Partida&nbsp;
                <asp:DropDownList ID="tipoPartida" runat="server" OnSelectedIndexChanged="tipoPartida_SelectedIndexChanged">
                    <asp:ListItem>Normal</asp:ListItem>
                    <asp:ListItem>Base</asp:ListItem>
                    <asp:ListItem>Tiempo</asp:ListItem>
                </asp:DropDownList>
                <br />
                <asp:Label ID="labelTiempo" runat="server" Text="Definir tiempo en minutos"></asp:Label>
&nbsp;&nbsp;<asp:TextBox ID="textTiempo" runat="server" Width="38px"></asp:TextBox>
                <br />
                Cantidad de Unidades por Nivel<br />
                <br />
                <asp:Label ID="Label1" runat="server" Font-Size="12pt" ForeColor="White" Text="Nivel 0"></asp:Label>
                &nbsp;
                <asp:TextBox ID="textNivel0" runat="server" Width="39px"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="Label2" runat="server" Font-Size="12pt" ForeColor="White" Text="Nivel 1"></asp:Label>
                &nbsp;
                <asp:TextBox ID="textNivel1" runat="server" Width="39px"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="Label3" runat="server" Font-Size="12pt" ForeColor="White" Text="Nivel 2"></asp:Label>
                &nbsp;
                <asp:TextBox ID="textNivel2" runat="server" Width="39px"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="Label4" runat="server" Font-Size="12pt" ForeColor="White" Text="Nivel 3"></asp:Label>
                &nbsp;
                <asp:TextBox ID="textNivel3" runat="server" Width="39px"></asp:TextBox>
                <br />
                <br />
                Dimensiones del Tablero<br />
                <br />
                <asp:Label ID="Label5" runat="server" Font-Size="12pt" ForeColor="White" Text="X"></asp:Label>
                &nbsp;
                <asp:TextBox ID="textX" runat="server" Width="39px"></asp:TextBox>
                &nbsp;&nbsp;
                <asp:Label ID="Label6" runat="server" Font-Size="12pt" ForeColor="White" Text="Y"></asp:Label>
                &nbsp;
                <asp:TextBox ID="textY" runat="server" Width="39px"></asp:TextBox>
                <br />
                <br />
                Ordenar el Historial por:<br />
                <asp:DropDownList ID="parametroB" runat="server">
                    <asp:ListItem>Coordenada X</asp:ListItem>
                    <asp:ListItem>Coordenada Y</asp:ListItem>
                    <asp:ListItem>Unidad Atacante</asp:ListItem>
                    <asp:ListItem>Resultado</asp:ListItem>
                    <asp:ListItem>Unidad Dañada</asp:ListItem>
                    <asp:ListItem>Emisor</asp:ListItem>
                    <asp:ListItem>Receptor</asp:ListItem>
                    <asp:ListItem>Fecha</asp:ListItem>
                    <asp:ListItem>Tiempo</asp:ListItem>
                    <asp:ListItem>Numero de Ataque</asp:ListItem>
                </asp:DropDownList>
                &nbsp;
                <asp:TextBox ID="textIndice" runat="server" Width="25px"></asp:TextBox>
                &nbsp;Indice<br />
                <br />
                <asp:Button ID="botonFinalizar" runat="server" Text="Finalizar" OnClick="botonFinalizar_Click" />
                <br />
                <br />
                <asp:Label ID="labelError" runat="server" Font-Size="15pt" ForeColor="Red"></asp:Label>
                <br />
                <br />
            </div>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
