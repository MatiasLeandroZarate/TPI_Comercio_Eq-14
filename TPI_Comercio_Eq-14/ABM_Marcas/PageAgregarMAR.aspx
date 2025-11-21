<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true" CodeBehind="PageAgregarMAR.aspx.cs" Inherits="TPC_Comercio_Eq_14.ABM_Marcas.PageAgregarMAR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container text-center">
        <h1 class="text-primary">Agregar Marca</h1>
    </div>

    <hr />

    <div class="container">
        <div class="row mb-3">
            <label for="txtNombre" class="col-sm-2 col-form-label">Nombre:</label>
            <div class="col-sm-10">
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
            </div>
        </div>

        <div class="text-center">
            <asp:Button Text="Volver" ID="btnVolver" OnClick="btnVolver_Click" CssClass="btn btn-secondary mx-2" runat="server" />
            <asp:Button Text="Agregar" ID="btnAgregar" OnClick="btnAgregar_Click" CssClass="btn btn-success mx-2" runat="server" />
        </div>
    </div>

</asp:Content>