<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true"
    CodeBehind="PageArticulos.aspx.cs" Inherits="TPC_Comercio_Eq_14.PageArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container text-center">
        <h1 class="text-primary">Artículos</h1>
    </div>

    <asp:UpdatePanel ID="updArticulos" runat="server">
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
                            <asp:Button ID="btnQuitarSeleccion" runat="server" CssClass="btn btn-secondary" OnClick="btnQuitarSeleccion_Click" Text="Quitar Selección" />
                        </div>

                        <div class="form-check form-switch form-check-reverse ms-auto m-0">
                            <input ID="chkMostrarActivos" runat="server" class="form-check-input" Type="checkbox" OnChange="this.form.submit();" OnServerChange="chkMostrarActivos_ServerChange" />
                            <label Class="form-check-label" For="chkMostrarActivos">Mostrar Activos</label>
                        </div>
                    </div>
                </div>
            </div>

            <hr />
            
            <div class="container">
                <asp:GridView ID="gvArticulos" runat="server" AutoGenerateColumns="False" CssClass="table table-hover table-sm table-bordered border-primary-subtle"
                    DataKeyNames="IDArticulo" OnRowDataBound="gvArticulos_RowDataBound">

                    <Columns>


                        <asp:TemplateField HeaderText="Selec.">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSeleccion" runat="server" AutoPostBack="true" OnCheckedChanged="chkSeleccion_CheckedChanged" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="IDArticulo" HeaderText="ID" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                        <asp:BoundField DataField="PrecioCompra" HeaderText="Precio Compra" DataFormatString="{0:N2}" />
                        <asp:BoundField DataField="PrecioVenta" HeaderText="Precio Venta" DataFormatString="{0:N2}" />
                        <asp:BoundField DataField="Stock" HeaderText="Stock" />
                        <asp:BoundField DataField="IDMarca" HeaderText="ID Marca" />
                        <asp:BoundField DataField="IDCategoria" HeaderText="ID Categoría" />
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
