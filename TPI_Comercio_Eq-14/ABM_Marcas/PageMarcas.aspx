<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true" CodeBehind="PageMarcas.aspx.cs" Inherits="TPC_Comercio_Eq_14.PageMarcas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container text-center">
        <h1 class="text-primary">Marcas</h1>
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
