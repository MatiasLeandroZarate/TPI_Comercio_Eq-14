<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true" CodeBehind="PageMarcas.aspx.cs" Inherits="TPC_Comercio_Eq_14.PageMarcas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container text-center">
        <h1 class="text-primary">Marcas</h1>
    </div>

    <div class="container">
        <asp:GridView ID="gvMarcas" runat="server" AutoGenerateColumns="False" CssClass="table table-hover table-sm table-bordered border-primary-subtle"
            DataKeyNames="IDMarca">
            <Columns>
                <asp:BoundField DataField="IDMarca" HeaderText="ID" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            </Columns>
        </asp:GridView>

        <div class="text-center mt-3">
            <asp:Button Text="Agregar" ID="btnAgregar" OnClick="btnAgregar_Click" CssClass="btn btn-success mx-2" runat="server" />
            <asp:Button Text="Modificar" ID="btnModificar" OnClick="btnModificar_Click" CssClass="btn btn-warning mx-2" runat="server" />
        </div>
    </div>

</asp:Content>