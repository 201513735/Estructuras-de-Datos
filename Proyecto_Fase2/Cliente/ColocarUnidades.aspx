<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ColocarUnidades.aspx.cs" Inherits="EddCliente.ColocarUnidades" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Colocar Unidades</title>
    <link href="estilo2.css" rel="stylesheet" />
    <style type="text/css"></style>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
        <h1>Colocar Unidades</h1>
    </div>
    <div align="right">
        <asp:Panel CssClass="panel" ID="Panel1" runat="server" Width="430px">
            <div align="center">
                Unidades Disponibles por Nivel<br />
                <asp:Label ID="labelUnidades" runat="server"></asp:Label>
                <br /> 
                <br />
                Seleccione el tipo de Unidad y<br /> &nbsp;la Posicion donde la Colocará.<br /> &nbsp;
                <asp:DropDownList ID="unidad" runat="server">
                    <asp:ListItem>Submarino</asp:ListItem>
                    <asp:ListItem>Fragata</asp:ListItem>
                    <asp:ListItem>Crucero</asp:ListItem>
                    <asp:ListItem>Helicoptero</asp:ListItem>
                    <asp:ListItem>Bombardero</asp:ListItem>
                    <asp:ListItem>Caza</asp:ListItem>
                    <asp:ListItem>Neosatelite</asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />
                Columna&nbsp;
                <asp:DropDownList ID="coordenadaX" runat="server">
                </asp:DropDownList>
                &nbsp;&nbsp;&nbsp; Fila&nbsp;
                <asp:DropDownList ID="coordenadaY" runat="server">
                </asp:DropDownList>
                <br />
                <br />
                <asp:Button ID="agregarUnidad" runat="server" OnClick="agregarUnidad_Click" Text="Agregar" />
                <br />
                <asp:Label ID="labelError" runat="server" ForeColor="Red"></asp:Label>
                <br />
                <br />
                <asp:Button ID="botonJugar" runat="server" OnClick="botonJugar_Click" Text="Jugar" />
                <br />
                <asp:Panel ID="panelBase" runat="server">
                    Coordenadas Base<br /> X&nbsp;&nbsp;
                    <asp:DropDownList ID="baseX" runat="server">
                    </asp:DropDownList>
                    &nbsp;&nbsp; Y&nbsp;&nbsp;
                    <asp:DropDownList ID="baseY" runat="server">
                    </asp:DropDownList>
                </asp:Panel>
                <asp:Panel ID="panelTiempo" runat="server">
                    Defina el Tiempo de
                    <br />
                    Duracion en Minutos<br />
                    <asp:TextBox ID="textTiempo" runat="server" Width="67px"></asp:TextBox>
                </asp:Panel>
                <br />
            </div>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
