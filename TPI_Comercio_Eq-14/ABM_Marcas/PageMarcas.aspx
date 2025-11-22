<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true" CodeBehind="PageMarcas.aspx.cs" Inherits="TPC_Comercio_Eq_14.PageMarcas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container text-center">
        <h1 class="text-primary">Marcas</h1>
    </div>
    <asp:UpdatePanel ID="updCategorias" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-5">
                    <div class="mb-3">
                        <asp:Label Text="Filtrar:" runat="server" />
                        <asp:TextBox runat="server" ID="txtFiltro" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtFiltro_TextChanged" />
                    </div>
                </div>
                <div class="col">
                    <asp:Button Text="Quitar Filtro" ID="btnQuitarFiltro" CssClass="btn btn-secondary mt-4" OnClick="btnQuitarFiltro_Click" runat="server" />
                </div>
            </div>
            <div class="container">
                <asp:GridView ID="gvMarcas" runat="server" AutoGenerateColumns="False" CssClass="table table-hover table-sm table-bordered border-primary-subtle" DataKeyNames="IDMarca" OnrowDataBound="gvMarcas_RowDataBound">
                   
                    <Columns>
                        <asp:TemplateField HeaderText="Sel.">
                            <ItemTemplate>
                                <asp:RadioButton ID="rbSeleccion" runat="server" AutoPostBack="true" OnCheckedChanged="rbSeleccion_CheckedChanged" GroupName="MarcasSeleccion" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="IDMarca" HeaderText="ID" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    </Columns>
                </asp:GridView>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <div class="text-center mt-3">
        <asp:Button Text="Agregar" ID="btnAgregar" OnClick="btnAgregar_Click" CssClass="btn btn-success mx-2" runat="server" />
        <asp:Button Text="Modificar" ID="btnModificar" OnClick="btnModificar_Click" CssClass="btn btn-warning mx-2" runat="server" />
    </div>

</asp:Content>
