<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true"   CodeBehind="PageCategorias.aspx.cs" Inherits="TPC_Comercio_Eq_14.PageCategorias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container text-center">
        <h1 class="text-primary">Categorías</h1>
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

            <hr />

            <div class="container">
                <asp:GridView ID="gvCategorias" runat="server" AutoGenerateColumns="False" CssClass="table table-hover table-sm table-bordered border-primary-subtle" DataKeyNames="IDCategoria" OnRowDataBound="gvCategorias_RowDataBound">

                    <Columns>

                        <asp:TemplateField HeaderText="Sel.">
                            <ItemTemplate>
                                <asp:RadioButton ID="rbSeleccion" runat="server" AutoPostBack="true" OnCheckedChanged="rbSeleccion_CheckedChanged" GroupName="CategoriasSeleccion"/>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="IDCategoria" HeaderText="ID" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />

                    </Columns>

                </asp:GridView>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>

    <div class="text-center mt-3">
        <asp:Button Text="Agregar" ID="btnAgregar"
            CssClass="btn btn-success mx-2"
            OnClick="btnAgregar_Click"
            runat="server" />

        <asp:Button Text="Modificar" ID="btnModificar"
            CssClass="btn btn-warning mx-2"
            OnClick="btnModificar_Click"
            runat="server" />
    </div>

</asp:Content>
