<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true"
    CodeBehind="GestionCompra.aspx.cs" Inherits="TPC_Comercio_Eq_14.GestionCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container text-center">
        <h1 class="text-primary">Gestión de Compra</h1>
    </div>

    <asp:UpdatePanel ID="updArticulos" runat="server">
        <ContentTemplate>

            <div class="container">
                <div class="row justify-content-start">
                    <asp:Label Text="Filtrar:" runat="server" />
                    <div class="col-6">
                        <asp:TextBox runat="server" ID="txtFiltro" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtFiltro_TextChanged" />
                    </div>
                    <div class="col-4">
                        <asp:Button ID="btnQuitarFiltro" runat="server" CssClass="btn btn-secondary mx-2" OnClick="btnQuitarFiltro_Click" Text="Quitar Filtro" />
                    </div>
                </div>
            </div>

            <hr />

            <div class="container">
                <asp:GridView ID="gvGestionCompra" runat="server" AutoGenerateColumns="False" CssClass="table table-hover table-sm table-bordered border-primary-subtle" DataKeyNames="IDArticulo,PrecioCompra">

                    <Columns>

                        <asp:BoundField DataField="IDArticulo" HeaderText="IDArt" />
                        <asp:BoundField DataField="Nombre" HeaderText="Artículo" />

                        <asp:BoundField DataField="PrecioCompra" HeaderText="Precio Compra" DataFormatString="{0:N2}" />
                        <asp:BoundField DataField="StockActual" HeaderText="Stock" />

                        <asp:TemplateField HeaderText="Stock Solicitado">
                            <ItemTemplate>
                                <asp:TextBox ID="txtStockSolicitado" runat="server" CssClass="form-control" TextMode="Number" Min="1" Width="100px" AutoPostBack="true" OnTextChanged="txtStockSolicitado_TextChanged" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Subtotal">
                            <ItemTemplate>
                                <asp:Label ID="lblSubtotal" runat="server" Text="0.00"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Total">
                            <ItemTemplate>
                                <asp:Label ID="lblTotal" runat="server" Text="0.00"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>

                </asp:GridView>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>

    <div class="text-center mt-3">
        <asp:Button Text="Volver" ID="btnVolver" OnClick="btnVolver_Click" CssClass="btn btn-secondary mx-2" runat="server" />

        <asp:Button Text="Efectuar Compra" ID="btnComprar" OnClick="btnComprar_Click" CssClass="btn btn-success mx-2" runat="server" />
    </div>

</asp:Content>