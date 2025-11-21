<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true" CodeBehind="PageArticulos.aspx.cs" Inherits="TPC_Comercio_Eq_14.PageArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />

    <div class="container text-center">
        <h1 class="text-primary">Artículos</h1>
    </div>

    <asp:UpdatePanel ID="updArticulos" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-5">
                    <div class="mb-3">
                        <asp:Label Text="Filtrar:" runat="server" />
                        <asp:TextBox runat="server" ID="txtFiltro" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtFiltro_TextChanged" />
                    </div>
                </div>
            </div>

            <div class="container">
               


                         <asp:GridView ID="gvArticulos" runat="server" AutoGenerateColumns="False" CssClass="table table-hover table-sm table-bordered border-primary-subtle"
                    DataKeyNames="IDArticulo">
                    <Columns>
                       
                        <asp:TemplateField HeaderText="Selec.">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSeleccionado" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="IDArticulo" HeaderText="ID" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                        <asp:BoundField DataField="PrecioCompra" HeaderText="PrecioCompra" DataFormatString="{0:N2}" />
                        <asp:BoundField DataField="PrecioVenta" HeaderText="PrecioVenta" DataFormatString="{0:N2}" />
                        <asp:BoundField DataField="Stock" HeaderText="Stock" />
                        <asp:BoundField DataField="IDMarca" HeaderText="IDMarca" />
                        <asp:BoundField DataField="IDCategoria" HeaderText="IDCategoria" />
                        <asp:CheckBoxField DataField="Activo" HeaderText="Activo" ReadOnly="true" />
                    </Columns>
                </asp:GridView>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <div class="text-center mt-3">
        <asp:Button Text="Agregar" ID="btnAgregar" OnClick="btnAgregar_Click" CssClass="btn btn-success mx-2" runat="server" />
        <asp:Button Text="Modificar" ID="btnModificar" OnClick="btnModificar_Click" CssClass="btn btn-warning mx-2" runat="server" />
        <asp:Button Text="Comprar" ID="btnComprar" OnClick="btnComprar_Click" CssClass="btn btn-primary mx-2" runat="server" />
        <asp:Button Text="Vender" ID="btnVender" OnClick="btnVender_Click" CssClass="btn btn-info mx-2" runat="server" />
        <asp:Button Text="Eliminar" ID="btnEliminar" OnClick="btnEliminar_Click" CssClass="btn btn-danger mx-2" runat="server" />
    </div>
</asp:Content>

