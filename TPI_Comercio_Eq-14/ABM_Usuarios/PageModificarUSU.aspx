<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="PageModificarUSU.aspx.cs" Inherits="TPC_Comercio_Eq_14.ABM_Usuarios.PageModificarUSU" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container text-center">
        <h1 class="text-primary ">Agregar Usuario </h1>
    </div>

    <hr />

    <div class="row mb-3">
        <label for="txtIdUsuario" class="col-sm-2 col-form-label">ID Usuario:</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txtIdUsuario" runat="server" CssClass="form-control" ReadOnly="true" Enabled="False" />
        </div>
    </div>

    <div class="row mb-3">
        <label for="ddlRol" class="col-sm-2 col-form-label">Rol: *</label>
        <div class="col-sm-10">
            <asp:DropDownList ID="ddlRol" runat="server" CssClass="form-select">
                <asp:ListItem Text="Seleccione un rol" Value="" />
            </asp:DropDownList>
        </div>
    </div>

    <div class="row mb-3">
        <label for="txtEmail" class="col-sm-2 col-form-label">Email: *</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txtEmail" type="email" CssClass="form-control" aria-describedby="emailHelp" runat="server" ToolTip="Ingrese el Mail" />
        </div>
    </div>

    <div class="row mb-3">
        <label for="txtContra" class="col-sm-2 col-form-label">Contraseña: *</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txtContra" runat="server" CssClass="form-control" TextMode="Password" />
        </div>
    </div>

    <div class="row mb-3">
        <label for="txtRepetirContra" class="col-sm-2 col-form-label">Repetir Contraseña: *</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txtRepetirContra" runat="server" CssClass="form-control" TextMode="Password" />
        </div>
    </div>

    <div class="row mb-3">
        <label for="ddlActivo" class="col-sm-2 col-form-label">Activo: *</label>
        <div class="col-sm-10">
            <asp:DropDownList ID="ddlActivo" runat="server" CssClass="form-select"></asp:DropDownList>
        </div>
    </div>

    <div class="row mb-3">
        <asp:CheckBox ID="chkVerContraseña" runat="server" AutoPostBack="true"
        Text="Mostrar contraseña" OnCheckedChange="VerContraseña" />
    </div>


    <div class="text-center">
        <label for="txtCampoObligatorio" class="col-sm-2 col-form-label" style="color: #FF0000">(*) Campo Obligatorio</label>
        <asp:Button Text="Volver" ID="btnVolver" OnClick="btnVolver_Click" CssClass="btn btn-secondary mx-2" runat="server" />
        <asp:Button Text="Modificar" ID="btnModificar" OnClick="btnModificar_Click" CssClass="btn btn-success mx-2" runat="server" />
    </div>
    <div class="text-center">
        <asp:Label ID="lblError" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
    </div>

</asp:Content>
