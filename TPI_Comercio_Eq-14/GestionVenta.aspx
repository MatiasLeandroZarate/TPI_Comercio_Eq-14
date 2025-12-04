<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true"
    CodeBehind="GestionVenta.aspx.cs" Inherits="TPC_Comercio_Eq_14.GestionVenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container text-center">
        <h1 class="text-primary">Gestión de Venta</h1>
    </div>

    <div style="max-width: 400px; margin-bottom: 10px;">
        <asp:Label ID="lblFiltroCliente" runat="server" Text="Buscar cliente (Nombre, Apellido o DNI):"></asp:Label>
        <asp:TextBox ID="txtFiltroCliente" runat="server" CssClass="form-control"
            AutoPostBack="true" OnTextChanged="txtFiltroCliente_TextChanged"></asp:TextBox>
    </div>


    <asp:GridView ID="gvClientes" runat="server" AutoGenerateColumns="False"
        DataKeyNames="IdCliente" CssClass="table table-sm table-bordered" Width="400px">

        <Columns>
            <asp:TemplateField HeaderText="Elegir">
                <ItemTemplate>
                    <asp:RadioButton ID="rbElegir" runat="server" GroupName="ClienteGroup"
                        AutoPostBack="true" OnCheckedChanged="rbElegir_CheckedChanged" />
                </ItemTemplate>
                <ItemStyle Width="40px" />
            </asp:TemplateField>

            <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="DNI" HeaderText="DNI" />
        </Columns>

    </asp:GridView>

    <asp:Label ID="lblClienteSeleccionado" runat="server" Text="" ForeColor="Green" Font-Bold="true"></asp:Label>

    <asp:UpdatePanel ID="updArticulos" runat="server">
        <ContentTemplate>

            <hr />


            <div class="container">
                <asp:GridView ID="gvGestionVenta" runat="server" AutoGenerateColumns="False"
                    CssClass="table table-hover table-sm table-bordered border-primary-subtle"
                    DataKeyNames="IDArticulo,PrecioVenta,StockActual">

                    <Columns>

                        <asp:BoundField DataField="IDArticulo" HeaderText="IDArt" />
                        <asp:BoundField DataField="Nombre" HeaderText="Artículo" />

                        <asp:BoundField DataField="PrecioVenta" HeaderText="Precio Venta"
                            DataFormatString="{0:N2}" />
                        <asp:BoundField DataField="StockActual" HeaderText="Stock" />

                        <asp:TemplateField HeaderText="Cantidad">
                            <ItemTemplate>
                                <asp:TextBox ID="txtCantidad" runat="server"
                                    CssClass="form-control" TextMode="Number" Min="1" Width="100px"
                                    AutoPostBack="true"
                                    OnTextChanged="txtCantidad_TextChanged" />
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

        <asp:Button Text="Efectuar Venta" ID="btnVenta" OnClick="btnVenta_Click" CssClass="btn btn-success mx-2" runat="server" />
    </div>
        <asp:Label ID="lblMensaje" runat="server" CssClass="text-warning fw-bold"></asp:Label>

</asp:Content>
