<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true"   CodeBehind="PageCategorias.aspx.cs" Inherits="TPC_Comercio_Eq_14.PageCategorias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container text-center">
        <h1 class="text-primary">Categorías</h1>
    </div>

    <asp:UpdatePanel ID="updCategorias" runat="server">
        <ContentTemplate>

            <div class="container">
                <div class="row justify-content-start">
                    <asp:Label Text="Filtrar:" runat="server" />
                    <div class="col-6">
                        <asp:TextBox runat="server" ID="txtFiltro" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtFiltro_TextChanged" Width="550px" />
                    </div>
                    <div class="col-6 d-flex align-items-center">
                        <div>
                            <asp:Button ID="btnQuitarFiltro" runat="server" CssClass="btn btn-secondary me-2" OnClick="btnQuitarFiltro_Click" Text="Quitar Filtro" />
                        </div>
                    </div>
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
