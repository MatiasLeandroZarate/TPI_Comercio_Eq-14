<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true" CodeBehind="PageUsuarios.aspx.cs" Inherits="TPC_Comercio_Eq_14.PageUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container text-center">
        <h1 class="text-primary">Usuarios</h1>
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
                <asp:GridView ID="gvUsuarios" runat="server" AutoGenerateColumns="False" CssClass="table table-hover table-sm table-bordered border-primary-subtle"
                    DataKeyNames="IDUsuario" OnRowDataBound="gvUsuarios_RowDataBound" >
                    
                    <Columns>
                        <asp:TemplateField HeaderText="Selec.">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSeleccion" runat="server" AutoPostBack="true" OnCheckedChanged="chkSeleccion_CheckedChanged" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="IDUsuario" HeaderText="ID" />
                        <asp:BoundField DataField="Rol" HeaderText="Rol" />
                        <asp:BoundField DataField="Email" HeaderText="Email" />
                        <asp:CheckBoxField DataField="Activo" HeaderText="Activo" ReadOnly="true" />
                    </Columns>

                </asp:GridView>

                <asp:Panel ID="pnlConfirmarPassword" runat="server" Visible="false" CssClass="border p-3 mt-3 bg-light">

                    <h5>Confirmar contraseña del usuario seleccionado</h5>

                    <div class="mb-2">
                        <asp:TextBox ID="txtConfirmarPassword" runat="server" 
                                     CssClass="form-control" 
                                     TextMode="Password"
                                     placeholder="Ingrese la contraseña del usuario" />
                    </div>

                    <asp:Label ID="lblErrorPassword" runat="server" CssClass="text-danger" Visible="false"></asp:Label>

                    <div class="mt-2">
                        <asp:Button ID="btnConfirmarPassword" runat="server" 
                                    Text="Confirmar" 
                                    CssClass="btn btn-primary"
                                    OnClick="btnConfirmarPassword_Click" />

                        <asp:Button ID="btnCancelarPassword" runat="server" 
                                    Text="Cancelar" 
                                    CssClass="btn btn-secondary ms-2"
                                    OnClick="btnCancelarPassword_Click" />
                    </div>

                </asp:Panel>

                <div class="text-center mt-3">
                    <asp:Button Text="Agregar" ID="btnAgregar" OnClick="btnAgregar_Click" CssClass="btn btn-success mx-2" runat="server" />
                    <asp:Button Text="Modificar" ID="btnModificar" OnClick="btnModificar_Click" CssClass="btn btn-warning mx-2" runat="server" />
                    <asp:Button Text="Eliminar" ID="btnEliminar" OnClick="btnEliminar_Click" CssClass="btn btn-danger mx-2" runat="server" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>