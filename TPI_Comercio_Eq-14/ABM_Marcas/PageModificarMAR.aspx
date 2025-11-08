<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="PageModificarMAR.aspx.cs" Inherits="TPC_Comercio_Eq_14.ABM_Marcas.PageModificarMAR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container text-center">
        <h1 class="text-primary ">Modificar Marca</h1>
    </div>

    <hr />

    <div class="container">
        <div>
            <div class="row mb-3">
                <label for="txtIDMarca" class="col-sm-2 col-form-label">ID Marca:</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtIDMarca" runat="server" CssClass="form-control" TextMode="Number"  AutoPostBack="true" OnTextChanged="txtIDMarca_TextChanged" />
                </div>
            </div>

            <div class="row mb-3">
                <label for="txtNombre" class="col-sm-2 col-form-label">Nombre:</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
                </div>
            </div>
        </div>
        <div class="text-center">
            <asp:Button Text="Volver" ID="btnVolver" OnClick="btnVolver_Click" CssClass="btn btn-primary mx-2" runat="server" />
            <asp:Button Text="Modificar" ID="btnModificar" OnClick="btnModificar_Click" CssClass="btn btn-primary mx-2" runat="server" />
        </div>
    </div>


</asp:Content>
