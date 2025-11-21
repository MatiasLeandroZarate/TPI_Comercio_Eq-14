<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true" CodeBehind="PageProveedores.aspx.cs" Inherits="TPC_Comercio_Eq_14.PageProveedores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container text-center">
        <h1 class="text-primary">Proveedores</h1>
    </div>

    <div class="container">
        <asp:GridView ID="gvProveedores" runat="server" AutoGenerateColumns="False" CssClass="table table-hover table-sm table-bordered border-primary-subtle"
            DataKeyNames="IDProveedor">
            <Columns>
                <asp:BoundField DataField="IDProveedor" HeaderText="ID" />
                <asp:BoundField DataField="RazonSocial" HeaderText="Razón Social" />
                <asp:BoundField DataField="CUIT" HeaderText="CUIT" />
                <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="Direccion" HeaderText="Dirección" />
                <asp:CheckBoxField DataField="Activo" HeaderText="Activo" ReadOnly="true" />
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>