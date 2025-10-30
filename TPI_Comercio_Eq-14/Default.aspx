<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPC_Comercio_Eq_14.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container text-center">
        <h1>TP I - Proyecto Web Integrador - Equipo 14A</h1>
        <h2>Ingrese el Usuario</h2>


        <div class="row justify-content-center">

            <div class="col-4">
                <label for="IngresarMail" class="form-label">Email:</label>
                <asp:TextBox type="email" CssClass="form-control" ID="txtEmail" aria-describedby="emailHelp" runat="server" ToolTip="Ingrese el Mail" />

                <br />

                <label for="Ingresarpass" class="form-label">Contraseña:</label>
                <asp:TextBox ID="txtContraseña" runat="server" CssClass="form-control" TextMode="Password" />

                <asp:CheckBox ID="chkVerContraseña" runat="server" AutoPostBack="true"
                    Text="Mostrar contraseña" OnCheckedChange="VerContraseña" />
                <br />
                <asp:Button Text="Ingresar" ID="btnSiguiente" CssClass="btn btn-primary"
                    OnClick="btnSiguiente_Click" runat="server" />
            </div>
            <br />
        </div>
        
    </div>

</asp:Content>
