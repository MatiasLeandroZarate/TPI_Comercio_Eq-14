<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="PageAgregarART.aspx.cs" Inherits="TPC_Comercio_Eq_14.PageAgregarART" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="container text-center">
        <h1 class="text-primary ">Agregar Artículo </h1>
    </div>
    
    <hr />

    <div class="container">
        <div>
            <div class="row mb-3">
            <label for="txtNombre" class="col-sm-2 col-form-label">Nombre:</label>
            <div class="col-sm-10">
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
            </div>
        </div>

        <div class="row mb-3">
            <label for="txtDescripcion" class="col-sm-2 col-form-label">Descripción:</label>
            <div class="col-sm-10">
                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="1" />
            </div>
        </div>

        <div class="row mb-3">
            <label for="txtPrecioCompra" class="col-sm-2 col-form-label">Precio Compra:</label>
            <div class="col-sm-10">
                <asp:TextBox ID="txtPrecioCompra" runat="server" CssClass="form-control" TextMode="Number" />
            </div>
        </div>

        <div class="row mb-3">
            <label for="txtPrecioVenta" class="col-sm-2 col-form-label">Precio Venta:</label>
            <div class="col-sm-10">
                <asp:TextBox ID="txtPrecioVenta" runat="server" CssClass="form-control" TextMode="Number" />
            </div>
        </div>

        <div class="row mb-3">
            <label for="txtStock" class="col-sm-2 col-form-label">Stock:</label>
            <div class="col-sm-10">
                <asp:TextBox ID="txtStock" runat="server" CssClass="form-control" TextMode="Number" />
            </div>
        </div>

        <div class="row mb-3">
            <label for="ddlMarca" class="col-sm-2 col-form-label">Marca:</label>
            <div class="col-sm-10">
                <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-select">
                    <asp:ListItem Text="Seleccione una marca" Value="" />
                </asp:DropDownList>
            </div>
        </div>

        <div class="row mb-3">
            <label for="ddlCategoria" class="col-sm-2 col-form-label">Categoría:</label>
            <div class="col-sm-10">
                <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-select">
                    <asp:ListItem Text="Seleccione una categoría" Value="" />
                </asp:DropDownList>
            </div>
        </div>
        </div>
        <div class="text-center">
            <asp:Button Text="Volver" ID="btnVolver" OnClick="btnVolver_Click" CssClass="btn btn-primary mx-2" runat="server" />
            <asp:Button Text="Aceptar" ID="btnAceptar" OnClick="btnAceptar_Click" CssClass="btn btn-primary mx-2" runat="server" />
        </div>
    </div>

</asp:Content>
