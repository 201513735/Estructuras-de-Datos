<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Administrador.aspx.cs" Inherits="EddCliente.Administrador" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin</title>
    <link href="estilo.css" rel="stylesheet" />
    <style type="text/css">
        #imagenGrafo {
            height: 485px;
            width: 807px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
        <h1>Sesión Administrador</h1>
    </div>
        <div align="center">
            <p>
                <asp:Button ID="botonCerrarSesion" runat="server" Text="Cerrar Sesion" OnClick="botonCerrarSesion_Click" />
            </p>
    </div>

    <div align="center">
    
        <asp:Panel CssClass="panel" ID="Panel1" runat="server" Width="526px">
            Carga Masiva de Datos<br />
            <asp:Button ID="botonCargarJugadores" runat="server" Text="Cargar Jugadores" Width="150px" OnClick="botonCargarJugadores_Click" />
            <br />
            <asp:Button ID="botonCargarJuegos" runat="server" Text="Cargar Partidas" Width="150px" />
            <br />
            <asp:Button ID="botonCargarTablero" runat="server" Text="Cargar Tablero" Width="150px" />
            <br />
            <br />
            Usuarios<br />&nbsp;<asp:Label ID="Label1" runat="server" ForeColor="Black" Text="Nickname  "></asp:Label>
            &nbsp;<asp:TextBox ID="textUsuario" runat="server"></asp:TextBox>
&nbsp;<asp:Label ID="Label6" runat="server" ForeColor="Black" Text="Nuevo Nickname"></asp:Label>
            &nbsp;&nbsp;<asp:TextBox ID="textNuevoNickname" runat="server"></asp:TextBox>
            &nbsp;<asp:Label ID="Label2" runat="server" ForeColor="Black" Text="Contraseña"></asp:Label>
&nbsp;&nbsp;<asp:TextBox ID="textContraseña" runat="server"></asp:TextBox>
&nbsp;<asp:Label ID="Label3" runat="server" ForeColor="Black" Text="Correo"></asp:Label>
            &nbsp;&nbsp;<asp:TextBox ID="textCorreo" runat="server" Width="186px"></asp:TextBox>
            &nbsp;<br /> <asp:Button ID="botonInsertarUsuario" runat="server" Text="Insertar" OnClick="botonInsertarUsuario_Click" />

            &nbsp;
            <asp:Button ID="botonEliminarUsuario" runat="server" Text="Eliminar" OnClick="botonEliminarUsuario_Click" />

            &nbsp;
            <asp:Button ID="botonModificarUsuario" runat="server" Text="Modificar" OnClick="botonModificarUsuario_Click" />

            <br />
            <br />
            Reportes<br />
            <asp:Label ID="Label4" runat="server" Text="Nivel" ForeColor="Black"></asp:Label>

            &nbsp;
            <asp:TextBox ID="textNivelMatriz" runat="server" Width="36px"></asp:TextBox>

            &nbsp;
            <asp:Button ID="botonReporteMatriz" runat="server" Text="Generar Reporte" Width="122px" />

            <br />
            <asp:Label ID="Label5" runat="server" ForeColor="Black" Text="Reporte de Usuarios"></asp:Label>
            &nbsp;&nbsp;
            <asp:Button ID="botonReporteUsuarios" runat="server" Text="Generar" OnClick="botonReporteUsuarios_Click" />

        </asp:Panel>
        
        <br />
        <img id="imagenGrafo" runat="server" align="center" class="img-rounded" alt="Cinque Terre" />
        <br />
    </div>
        
    </form>
</body>
</html>
