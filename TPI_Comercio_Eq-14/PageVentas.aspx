<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true" CodeBehind="PageVentas.aspx.cs" Inherits="TPC_Comercio_Eq_14.PageVentas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container text-center">
        <h1 class="text-primary">Ventas</h1>
    </div>

    <div class="container">
        <asp:GridView ID="gvVentas" runat="server" AutoGenerateColumns="False" CssClass="table table-hover table-sm table-bordered border-primary-subtle"
            DataKeyNames="IDVenta">
            <Columns>
                <asp:BoundField DataField="IDVenta" HeaderText="ID" />
                <asp:BoundField DataField="Cliente" HeaderText="Cliente" />
                <asp:BoundField DataField="NroComprobante" HeaderText="NroComprobante" />
                <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="Descuentos" HeaderText="Descuentos" DataFormatString="{0:N2}" />
                <asp:BoundField DataField="Subtotal" HeaderText="SubTotal" DataFormatString="{0:N2}" />
                <asp:BoundField DataField="Total" HeaderText="Total" DataFormatString="{0:N2}" />
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>

