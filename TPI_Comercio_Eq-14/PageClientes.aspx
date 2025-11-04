<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true" CodeBehind="PageClientes.aspx.cs" Inherits="TPC_Comercio_Eq_14.PageClientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container text-center">
    <h1 class="text-primary ">Clientes </h1>
</div>
<div class="container">
    <table class="table table-hover table-sm table-bordered border-primary-subtle">
        <thead>
            <tr>
                <th scope="col">ID</th>
                <th scope="col">DNI</th>
                <th scope="col">CUIT</th>
                <th scope="col">Apellido</th>
                <th scope="col">Nombre</th>
                <th scope="col">Telefono</th>
                <th scope="col">Email</th>
                <th scope="col">Direccion</th>
                <th scope="col">Activo</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="rptClientes" runat="server">
                <ItemTemplate>
                    <tr>
                        <th scope="row"><%# Eval("IDCliente") %></th>
                        <td><%# Eval("DNI") %></td>
                        <td><%# Eval("CUIT") %></td>
                        <td><%# Eval("Apellido") %></td>
                        <td><%# Eval("Nombre") %></td>
                        <td><%# Eval("Telefono") %></td>
                        <td><%# Eval("Email") %></td>
                        <td><%# Eval("Direccion") %></td>
                        <td><%# Eval("Activo") %></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
</div>

</asp:Content>
