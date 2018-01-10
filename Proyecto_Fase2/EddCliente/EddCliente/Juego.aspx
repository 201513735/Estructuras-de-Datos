<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Juego.aspx.cs" Inherits="EddCliente.Juego" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Juego</title>
    <link href="estilo2.css" rel="stylesheet" />
    <style type="text/css">       
        #Img0 {
            height: 250px;
            width: 350px;
        }
        #Img1 {
            height: 250px;
            width: 350px;
        }
        #Img2 {
            height: 250px;
            width: 350px;
        }
        #Img3 {
             height: 250px;
            width: 350px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div align="right">
            <asp:Panel CssClass="panel" ID="Panel1" runat="server" Width="430px">
                <div align="center">
                     
                    <h1>Partida Actual</h1>
                    <asp:Label ID="labelTurno" runat="server"></asp:Label>
                    <br />
                    <asp:Button ID="botonCerrarSesion" runat="server" Text="Cerrar Sesion" OnClick="botonCerrarSesion_Click" />
                    <br />
                    Nombre de la Unidad
                    <asp:TextBox ID="textUnidad" runat="server"></asp:TextBox>
                    <br />
                    <br />
                    Mover a:<br /> Columna&nbsp;
                    <asp:DropDownList ID="moverX" runat="server">
                    </asp:DropDownList>
                    &nbsp;&nbsp; Fila&nbsp;&nbsp;
                    <asp:DropDownList ID="moverY" runat="server">
                    </asp:DropDownList>
                    &nbsp;&nbsp;
                    <asp:Button ID="botonMover" runat="server" Text="Mover" OnClick="botonMover_Click" />
                    <br />
                    <br />
                    Atacar a:<br /> Columna&nbsp;
                    <asp:DropDownList ID="atacarX" runat="server">
                    </asp:DropDownList>
                    &nbsp; Fila&nbsp;
                    <asp:DropDownList ID="atacarY" runat="server">
                    </asp:DropDownList>
                    <br />
                    Nivel&nbsp;&nbsp;
                    <asp:DropDownList ID="nivel" runat="server">
                        <asp:ListItem>Submarino</asp:ListItem>
                        <asp:ListItem>Barcos</asp:ListItem>
                        <asp:ListItem>Aviones</asp:ListItem>
                        <asp:ListItem>Satelites</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;
                    <asp:Button ID="botonAtacar" runat="server" Text="Atacar" OnClick="botonAtacar_Click" />
                    <br />
                    <asp:Button ID="botonTerminarTurno" runat="server" Text="Terminar Turno" OnClick="botonTerminarTurno_Click" />
                    <br />
                    <asp:Button ID="botonActualizar" runat="server" OnClick="botonActualizar_Click" Text="Actualizar" />
                    <br />
                    Consola:<br />
                    <asp:TextBox ID="textConsola" TextMode="MultiLine" runat="server" Height="260px" Width="377px"></asp:TextBox>
                </div>
            </asp:Panel>
            <asp:Panel CssClass="panel1" ID="Panel2" runat="server">
                <div align="center">
                     Nivel Submarino
                    <br />
                    <img id="Img0" runat="server" align="center" class="img-rounded" alt="Cinque Terre" />
                </div>
            </asp:Panel>
            <asp:Panel CssClass="panel2" ID="Panel3" runat="server">
                <div align="center">
                     Nivel Barcos
                     <br />
                    <img id="Img1" runat="server" align="center" class="img-rounded" alt="Cinque Terre" />
                </div>
            </asp:Panel>
            <asp:Panel CssClass="panel3" ID="Panel4" runat="server">
                <div align="center">
                     Nivel Aviones
                    <br />
                    <img id="Img2" runat="server" align="center" class="img-rounded" alt="Cinque Terre" />
                </div>
            </asp:Panel>
            <asp:Panel CssClass="panel4" ID="Panel5" runat="server">
                <div align="center">
                     Nivel Satelites
                    <br />
                    <img id="Img3" runat="server" align="center" class="img-rounded" alt="Cinque Terre" />
                </div>
            </asp:Panel>
        </div>

    </form>
</body>
</html>
