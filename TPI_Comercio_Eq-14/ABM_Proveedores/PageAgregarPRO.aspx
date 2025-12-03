<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true" CodeBehind="PageAgregarPRO.aspx.cs" Inherits="TPC_Comercio_Eq_14.ABM_Proveedores.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container text-center">
        <h1 class="text-primary ">Agregar Proveedor </h1>
    </div>

    <hr />


    <div class="row mb-3">
        <label for="txtRazonSocial" class="col-sm-2 col-form-label">Razon Social: *</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txtRazonSocial" runat="server" CssClass="form-control" />
        </div>
    </div>

    <div class="row mb-3">
        <label for="txtCUIT" class="col-sm-2 col-form-label">CUIT: *</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txtCUIT" runat="server" CssClass="form-control" />
        </div>
    </div>

    <div class="row mb-3">
        <label for="txtTelefono" class="col-sm-2 col-form-label">Teléfono: *</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" TextMode="Phone" />
        </div>
    </div>

    <div class="row mb-3">
        <label for="txtEmail" class="col-sm-2 col-form-label">Email: *</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" />
        </div>
    </div>

    <div class="row mb-3">
        <label for="txtDireccion" class="col-sm-2 col-form-label">Dirección: *</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" />
        </div>
    </div>


    <div class="text-center">
        <label for="txtCampoObligatorio" class="col-sm-2 col-form-label" style="color: #FF0000">(*) Campo Obligatorio</label>
        <asp:Button Text="Volver" ID="btnVolver" OnClick="btnVolver_Click" CssClass="btn btn-secondary mx-2" runat="server" />
        <asp:Button Text="Agregar" ID="btnAgregar" OnClick="btnAgregar_Click" CssClass="btn btn-success mx-2" runat="server" />
    </div>
    <div class="text-center">
        <asp:Label ID="lblError" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
    </div>

</asp:Content>
