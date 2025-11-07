<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true" CodeBehind="PageCompras.aspx.cs" Inherits="TPC_Comercio_Eq_14.PageCompras" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container text-center">
    <h1 class="text-primary ">Compras </h1>
</div>
<div class="container">
    <table class="table table-hover table-sm table-bordered border-primary-subtle">
        <thead>
            <tr>
                <th scope="col">ID</th>
                <th scope="col">IDProveedor</th>
                <th scope="col">NroComprobante</th>
                <th scope="col">Fecha</th>
                <th scope="col">Descuentos</th>
                <th scope="col">SubTotal</th>
                <th scope="col">Total</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="rptCompras" runat="server">
                <ItemTemplate>
                    <tr>
                        <th scope="row"><%# Eval("IDCompra") %></th>
                        <td><%# Eval("IDProveedor") %></td>
                        <td><%# Eval("NroComprobante") %></td>
                        <td><%# Eval("Fecha") %></td>
                        <td><%# Eval("Descuentos") %></td>
                        <td><%# Eval("Subtotal") %></td>
                        <td><%# Eval("Total") %></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
</div>
</asp:Content>
