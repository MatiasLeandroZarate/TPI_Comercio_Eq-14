<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true"
    CodeBehind="GestionCompra.aspx.cs" Inherits="TPC_Comercio_Eq_14.GestionCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container text-center">
        <h1 class="text-primary">Gestión de Compra</h1>
    </div>

    <div style="max-width: 400px; margin-bottom: 10px;">
        <asp:Label ID="lblFiltroProv" runat="server" Text="Buscar proveedor (Razón Social o CUIT):"></asp:Label>
        <asp:TextBox ID="txtFiltroProv" runat="server" CssClass="form-control"
            AutoPostBack="true" OnTextChanged="txtFiltroProv_TextChanged"></asp:TextBox>
    </div>


    <asp:GridView ID="gvProveedores" runat="server" AutoGenerateColumns="False"
        DataKeyNames="IdProveedor" CssClass="table table-sm table-bordered" Width="400px">

        <Columns>
            <asp:TemplateField HeaderText="Elegir">
                <ItemTemplate>
                    <asp:RadioButton ID="rbElegir" runat="server" GroupName="ProveedorGroup"
                        AutoPostBack="true" OnCheckedChanged="rbElegir_CheckedChanged" />
                </ItemTemplate>
                <ItemStyle Width="40px" />
            </asp:TemplateField>

            <asp:BoundField DataField="RazonSocial" HeaderText="Razón Social" />
            <asp:BoundField DataField="CUIT" HeaderText="CUIT" />
        </Columns>

    </asp:GridView>

    <asp:Label ID="lblProveedorSeleccionado" runat="server" Text="" ForeColor="Green" Font-Bold="true"></asp:Label>

    <asp:UpdatePanel ID="updArticulos" runat="server">
        <ContentTemplate>

            <hr />


            <div class="container">
                <asp:GridView ID="gvGestionCompra" runat="server" AutoGenerateColumns="False"
                    CssClass="table table-hover table-sm table-bordered border-primary-subtle"
                    DataKeyNames="IDArticulo,PrecioCompra">

                    <Columns>

                        <asp:BoundField DataField="IDArticulo" HeaderText="IDArt" />
                        <asp:BoundField DataField="Nombre" HeaderText="Artículo" />

                        <asp:BoundField DataField="PrecioCompra" HeaderText="Precio Compra"
                            DataFormatString="{0:N2}" />
                        <asp:BoundField DataField="StockActual" HeaderText="Stock" />

                        <asp:TemplateField HeaderText="Stock Solicitado">
                            <ItemTemplate>
                                <asp:TextBox ID="txtStockSolicitado" runat="server"
                                    CssClass="form-control" TextMode="Number" Min="1" Width="100px"
                                    AutoPostBack="true"
                                    OnTextChanged="txtStockSolicitado_TextChanged" />
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
        <asp:Button Text="Volver" ID="btnVolver" OnClick="btnVolver_Click"
            CssClass="btn btn-secondary mx-2" runat="server" />

        <asp:Button Text="Efectuar Compra" ID="btnComprar" OnClick="btnComprar_Click" CssClass="btn btn-success mx-2" runat="server" />
    </div>
        <asp:Label ID="lblMensaje" runat="server" CssClass="text-warning fw-bold"></asp:Label>

</asp:Content>
