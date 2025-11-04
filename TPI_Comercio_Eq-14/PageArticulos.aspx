<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true" CodeBehind="PageArticulos.aspx.cs" Inherits="TPC_Comercio_Eq_14.PageArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container text-center">
        <h1 class="text-primary ">Articulos </h1>
    </div>
    <div class="container">
        <table class="table table-hover table-sm table-bordered border-primary-subtle">
            <thead>
                <tr>
                    <th scope="col">ID</th>
                    <th scope="col">Nombre</th>
                    <th scope="col">Descripción</th>
                    <th scope="col">PrecioCompra</th>
                    <th scope="col">PrecioVenta</th>
                    <th scope="col">Stock</th>
                    <th scope="col">IDMarca</th>
                    <th scope="col">IDCategoria</th>
                    <th scope="col">Activo</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptAriculos" runat="server">
                    <ItemTemplate>
                        <tr>
                            <th scope="row"><%# Eval("IDCategoria") %></th>
                            <td><%# Eval("Nombre") %></td>
                            <td><%# Eval("Descripcion") %></td>
                            <td><%# Eval("PrecioCompra") %></td>
                            <td><%# Eval("PrecioVenta") %></td>
                            <td><%# Eval("Stock") %></td>
                            <td><%# Eval("IDMarca") %></td>
                            <td><%# Eval("IDCategoria") %></td>
                            <td><%# Eval("Activo") %></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
</asp:Content>
