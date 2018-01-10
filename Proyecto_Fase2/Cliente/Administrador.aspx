<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Administrador.aspx.cs" Inherits="EddCliente.Administrador" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin</title>
    <link href="estilo.css" rel="stylesheet" />
    <style type="text/css">
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
            <p>
                <asp:Button ID="botonLimpiarArbol" runat="server" OnClick="botonLimpiarArbol_Click" Text="Limpiar Arbol" />
&nbsp;&nbsp;&nbsp;
                <asp:Button ID="botonLimpiarMatriz" runat="server" OnClick="botonLimpiarMatriz_Click" Text="Limpiar Matriz" />
            </p>
    </div>

    <div align="center">
    
        <asp:Panel CssClass="panel" ID="Panel1" runat="server" Width="800px">
            Carga Masiva de Datos<br />
            <asp:FileUpload ID="fileJugadores" runat="server" />
            <br />
            <br />
            <asp:Button ID="botonCargarJugadores" runat="server" Text="Cargar Jugadores" Width="150px" OnClick="botonCargarJugadores_Click" />
            <br />
            <asp:Button ID="botonCargarJuegos" runat="server" Text="Cargar Partidas" Width="150px" OnClick="botonCargarJuegos_Click" />
            <br />
            <asp:Button ID="botonCargarTablero" runat="server" Text="Cargar Tablero" Width="150px" OnClick="botonCargarTablero_Click" />
            <br />
            <asp:Button ID="botonCargarHistorial" runat="server" Text="Cargar Historial" Width="150px" OnClick="botonCargarHistorial_Click" />
            <br />
            <asp:Button ID="botonCargarContactos" runat="server" OnClick="botonCargarContactos_Click" Text="Cargar Contactos" Width="149px" />
            <br />
            <asp:Label ID="labelArchivo" runat="server" ForeColor="Black"></asp:Label>
            <br />
            <br />
            Usuarios<br />&nbsp;<asp:Label ID="Label1" runat="server" ForeColor="Black" Text="Nickname  "></asp:Label>
            &nbsp;<asp:TextBox ID="textUsuario" runat="server"></asp:TextBox>
&nbsp;<asp:Label ID="Label6" runat="server" ForeColor="Black" Text="Nickname Secundario"></asp:Label>
            &nbsp;&nbsp;<asp:TextBox ID="textNuevoNickname" runat="server"></asp:TextBox>
            &nbsp;<br /> <asp:Label ID="Label2" runat="server" ForeColor="Black" Text="Contraseña"></asp:Label>
&nbsp;&nbsp;<asp:TextBox ID="textContraseña" runat="server"></asp:TextBox>
&nbsp;<asp:Label ID="Label3" runat="server" ForeColor="Black" Text="Correo"></asp:Label>
            &nbsp;&nbsp;<asp:TextBox ID="textCorreo" runat="server" Width="186px"></asp:TextBox>
            &nbsp;<br /> <asp:Button ID="botonInsertarUsuario" runat="server" Text="Insertar" OnClick="botonInsertarUsuario_Click" />

            &nbsp;
            <asp:Button ID="botonEliminarUsuario" runat="server" Text="Eliminar" OnClick="botonEliminarUsuario_Click" />

            &nbsp;
            <asp:Button ID="botonModificarUsuario" runat="server" Text="Modificar" OnClick="botonModificarUsuario_Click" />

            &nbsp;
            <asp:Button ID="botonEliminarContacto" runat="server" OnClick="botonEliminarContacto_Click" Text="Eliminar Contacto" />
&nbsp;
            <asp:Button ID="botonAgregarContacto" runat="server" OnClick="botonAgregarContacto_Click" Text="Agregar Contacto" />
            <br />
            <br />
            Reportes Matriz<br />
            <asp:Label ID="Label4" runat="server" Text="Nivel" ForeColor="Black"></asp:Label>

            &nbsp;
            <asp:TextBox ID="textNivelMatriz" runat="server" Width="36px"></asp:TextBox>

            &nbsp;
            <br />
            <asp:Button ID="botonReporteMatriz" runat="server" Text="Sobrevivientes" Width="122px" OnClick="botonReporteMatriz_Click" />

            &nbsp;<br /> Reportes Usuarios<br /> &nbsp;&nbsp;
            <asp:Button ID="botonReporteUsuarios" runat="server" Text="Generar" OnClick="botonReporteUsuarios_Click" />

            &nbsp;
            <asp:Button ID="botonEspejoUsuarios" runat="server" OnClick="botonEspejoUsuarios_Click" Text="Espejo" />
            &nbsp;
            <asp:Button ID="botonContactos" runat="server" OnClick="botonContactos_Click" Text="Contactos" />
&nbsp;
            <asp:Button ID="botonGenerarHash" runat="server" Text="Tabla Hash" OnClick="botonGenerarHash_Click" />
            <br />
            <asp:Button ID="botonTopEliminados" runat="server" OnClick="botonTopEliminados_Click" Text="Top Eliminados" />
            &nbsp;
            <asp:Button ID="botonTopContactos" runat="server" OnClick="botonTopContactos_Click" Text="Top Contactos" />
            <br />
            Historial
            <br />
            <asp:Button ID="botonReporteB" runat="server" Text="Generar Arbol" OnClick="botonReporteB_Click" />
            <br />
            <br />

        </asp:Panel>
        
        <br />
            <img id="imagenGrafo" runat="server" align="center" class="img-rounded" alt="Cinque Terre" />
        <br />
    </div>
        
    </form>
</body>
</html>
