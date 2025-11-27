<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true" CodeBehind="PageAgregarCLI.aspx.cs" Inherits="TPC_Comercio_Eq_14.ABM_Clientes.PageAgregarCLI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container text-center">
        <h1 class="text-primary ">Agregar Cliente </h1>
    </div>

    <hr />

    <div class="container">
        <div>
            <div class="row mb-3">
                <label for="txtDNI" class="col-sm-2 col-form-label">DNI:</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtDNI" runat="server" CssClass="form-control" TextMode="Number"/>
                </div>
            </div>

            <div class="row mb-3">
                <label for="txtCUIT" class="col-sm-2 col-form-label">CUIT:</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtCUIT" runat="server" CssClass="form-control" TextMode="Number"/>
                </div>
            </div>

            <div class="row mb-3">
                <label for="txtApellido" class="col-sm-2 col-form-label">Apellido:</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"/>
                </div>
            </div>

            <div class="row mb-3">
                <label for="txtNombre" class="col-sm-2 col-form-label">Nombre:</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"/>
                </div>
            </div>

            <div class="row mb-3">
                <label for="txtTelefono" class="col-sm-2 col-form-label">Telefono:</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control"/>
                </div>
            </div>

            <div class="row mb-3">
                <label for="txtEmail" class="col-sm-2 col-form-label">Email:</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"/>
                </div>
            </div>

            <div class="row mb-3">
                <label for="txtDireccion" class="col-sm-2 col-form-label">Direccion:</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control"/>
                </div>
            </div>
            
        </div>
        <div class="text-center">
            <asp:Button Text="Volver" ID="btnVolver" OnClick="btnVolver_Click" CssClass="btn btn-secondary mx-2" runat="server" />
            <asp:Button Text="Agregar" ID="btnAgregar" OnClick="btnAgregar_Click" CssClass="btn btn-success mx-2" runat="server" />
        </div>
    </div>

</asp:Content>
