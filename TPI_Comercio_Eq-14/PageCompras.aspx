<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true" CodeBehind="PageCompras.aspx.cs" Inherits="TPC_Comercio_Eq_14.PageCompras" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container text-center">
        <h1 class="text-primary">Compras</h1>
    </div>
    <hr />
    <div class="container mt-3">
        <div class="row g-3 align-items-end mt-3">

            <div class="col-md-3">
                <label class="form-label">Proveedor o Nº Comprobante</label>
                <asp:TextBox ID="txtFiltroTexto" runat="server" CssClass="form-control" Placeholder="Buscar..."></asp:TextBox>
            </div>

            <div class="col-2">
                <label class="form-label">Fecha Desde</label>
                <asp:TextBox ID="txtFechaDesde" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="col-2">
                <label class="form-label">Fecha Hasta</label>
                <asp:TextBox ID="txtFechaHasta" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
            </div>

        </div>
            <div class="col-md-2 d-flex gap-2 mt-3">
                <asp:Button ID="btnBuscar" runat="server" Text="Filtrar" CssClass="btn btn-primary w-100" OnClick="btnBuscar_Click" />
                <asp:Button ID="btnQuitarFiltros" runat="server" Text="Limpiar" CssClass="btn btn-secondary w-100" OnClick="btnQuitarFiltros_Click" />
            </div>

    </div>

    <hr />

    <div class="container">
        <asp:GridView ID="gvCompras" runat="server" AutoGenerateColumns="False" CssClass="table table-hover table-sm table-bordered border-primary-subtle"
            DataKeyNames="IDCompra">
            <Columns>
                 <asp:TemplateField HeaderText="Elegir">
                    <ItemTemplate>
                        <asp:RadioButton ID="rbElegirCompra" runat="server"
                            GroupName="CompraGroup"
                            AutoPostBack="true"
                            OnCheckedChanged="rbElegirCompra_CheckedChanged" />
                    </ItemTemplate>
                </asp:TemplateField>
               
                <asp:BoundField DataField="IDCompra" HeaderText="ID" />
                <asp:BoundField DataField="RazonSocial" HeaderText="Proveedor" />
                <asp:BoundField DataField="NroComprobante" HeaderText="NroComprobante" />
                <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="Descuentos" HeaderText="Descuentos" DataFormatString="{0:N2}" />
                <asp:BoundField DataField="Subtotal" HeaderText="SubTotal" DataFormatString="{0:N2}" />
                <asp:BoundField DataField="Total" HeaderText="Total" DataFormatString="{0:N2}" />
            </Columns>
        </asp:GridView>
    </div>
     <div class="container">
        <asp:Label ID="lblSeleccion" runat="server" CssClass="fw-bold text-primary"></asp:Label>

        <asp:GridView ID="gvDetalles" runat="server"
            AutoGenerateColumns="False"
            CssClass="table table-sm table-bordered border-primary-subtle mt-3">

            <Columns>
                <asp:BoundField DataField="IDArticulo" HeaderText="ID Artículo" />
                <asp:BoundField DataField="NombreArticulo" HeaderText="Artículo" />
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                <asp:BoundField DataField="PrecioUnitario" HeaderText="Precio Unitario" DataFormatString="{0:N2}" />
                <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" DataFormatString="{0:N2}" />
            </Columns>

        </asp:GridView>
    </div>

</asp:Content>
