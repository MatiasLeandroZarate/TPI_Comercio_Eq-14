<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true" CodeBehind="PageModificarCAT.aspx.cs" Inherits="TPC_Comercio_Eq_14.ABM_Categorias.PageModificarCAT" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container text-center">
        <h1 class="text-primary ">Agregar Marca </h1>
    </div>

    <hr />

    <div class="container">
        <div>
            <div class="row mb-3">
                <label for="txtIDCategoria" class="col-sm-2 col-form-label">ID Categoría:</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtIDCategoria" runat="server" CssClass="form-control" TextMode="Number"  AutoPostBack="true" OnTextChanged="txtIDCategoria_TextChanged" />
                </div>
            </div>
            <div class="row mb-3">
                <label for="txtNombre" class="col-sm-2 col-form-label">Nombre:</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
                </div>
            </div>
            <div class="row mb-3">
                <label for="txtDescripcion" class="col-sm-2 col-form-label">Descripcion:</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" />
                </div>
            </div>
        </div>
        <div class="text-center">
            <asp:Button Text="Volver" ID="btnVolver" OnClick="btnVolver_Click" CssClass="btn btn-primary mx-2" runat="server" />
            <asp:Button Text="Modificar" ID="btnModificar" OnClick="btnModificar_Click" CssClass="btn btn-primary mx-2" runat="server" />
        </div>
    </div>

</asp:Content>
