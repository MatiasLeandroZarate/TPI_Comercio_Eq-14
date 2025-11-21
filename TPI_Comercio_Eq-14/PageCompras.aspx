<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true" CodeBehind="PageCompras.aspx.cs" Inherits="TPC_Comercio_Eq_14.PageCompras" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container text-center">
        <h1 class="text-primary">Compras</h1>
    </div>

    <div class="container">
        <asp:GridView ID="gvCompras" runat="server" AutoGenerateColumns="False" CssClass="table table-hover table-sm table-bordered border-primary-subtle"
            DataKeyNames="IDCompra">
            <Columns>
                <asp:BoundField DataField="IDCompra" HeaderText="ID" />
                <asp:BoundField DataField="IDProveedor" HeaderText="IDProveedor" />
                <asp:BoundField DataField="NroComprobante" HeaderText="NroComprobante" />
                <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="Descuentos" HeaderText="Descuentos" DataFormatString="{0:N2}" />
                <asp:BoundField DataField="Subtotal" HeaderText="SubTotal" DataFormatString="{0:N2}" />
                <asp:BoundField DataField="Total" HeaderText="Total" DataFormatString="{0:N2}" />
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>