<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true" CodeBehind="PageClientes.aspx.cs" Inherits="TPC_Comercio_Eq_14.PageClientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container text-center">
        <h1 class="text-primary">Clientes</h1>
    </div>

    <div class="container">
        <asp:GridView ID="gvClientes" runat="server" AutoGenerateColumns="False" CssClass="table table-hover table-sm table-bordered border-primary-subtle"
            DataKeyNames="IDCliente">
            <Columns>
                <asp:BoundField DataField="IDCliente" HeaderText="ID" />
                <asp:BoundField DataField="DNI" HeaderText="DNI" />
                <asp:BoundField DataField="CUIT" HeaderText="CUIT" />
                <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="Direccion" HeaderText="Dirección" />
                <asp:CheckBoxField DataField="Activo" HeaderText="Activo" ReadOnly="true" />
            </Columns>
        </asp:GridView>

        <div class="text-center mt-3">
            <asp:Button Text="Agregar" ID="btnAgregar" OnClick="btnAgregar_Click" CssClass="btn btn-success mx-2" runat="server" />
            <asp:Button Text="Modificar" ID="btnModificar" OnClick="btnModificar_Click" CssClass="btn btn-warning mx-2" runat="server" />
            <asp:Button Text="Eliminar" ID="btnEliminar" OnClick="btnEliminar_Click" CssClass="btn btn-danger mx-2" runat="server" />
        </div>
    </div>

</asp:Content>