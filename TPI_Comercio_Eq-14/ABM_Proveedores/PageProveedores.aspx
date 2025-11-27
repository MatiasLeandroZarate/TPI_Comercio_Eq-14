<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true" CodeBehind="PageProveedores.aspx.cs" Inherits="TPC_Comercio_Eq_14.PageProveedores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container text-center">
        <h1 class="text-primary">Proveedores</h1>
    </div>
    <asp:UpdatePanel ID="updProveedores" runat="server">
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

            <hr/>
            
            <div class="container">
                <asp:GridView ID="gvProveedores" runat="server" AutoGenerateColumns="False" CssClass="table table-hover table-sm table-bordered border-primary-subtle"
                    DataKeyNames="IDProveedor" OnRowDataBound="gvProveedores_RowDataBound" >
                    <Columns>

                        <asp:TemplateField HeaderText="Selec.">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSeleccion" runat="server" AutoPostBack="true" OnCheckedChanged="chkSeleccion_CheckedChanged" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="IDProveedor" HeaderText="ID" />
                        <asp:BoundField DataField="RazonSocial" HeaderText="Razón Social" />
                        <asp:BoundField DataField="CUIT" HeaderText="CUIT" />
                        <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                        <asp:BoundField DataField="Email" HeaderText="Email" />
                        <asp:BoundField DataField="Direccion" HeaderText="Dirección" />
                        <asp:CheckBoxField DataField="Activo" HeaderText="Activo" ReadOnly="true" />
                    </Columns>
                </asp:GridView>
                <div class="text-center mt-3">
                    <asp:Button Text="Agregar" ID="btnAgregar" OnClick="btnAgregar_Click" CssClass="btn btn-success mx-2" runat="server" />
                    <asp:Button Text="Modificar" ID="btnModificar" OnClick="btnModificar_Click" CssClass="btn btn-warning mx-2" runat="server" />
                    <asp:Button Text="Eliminar" ID="btnEliminar" OnClick="btnEliminar_Click" CssClass="btn btn-danger mx-2" runat="server" />
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
