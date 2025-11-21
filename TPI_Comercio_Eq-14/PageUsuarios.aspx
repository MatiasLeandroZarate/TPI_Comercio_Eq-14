<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true" CodeBehind="PageUsuarios.aspx.cs" Inherits="TPC_Comercio_Eq_14.PageUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container text-center">
        <h1 class="text-primary">Usuarios</h1>
    </div>

    <div class="container">
        <asp:GridView ID="gvUsuarios" runat="server" AutoGenerateColumns="False" CssClass="table table-hover table-sm table-bordered border-primary-subtle"
            DataKeyNames="IDUsuario">
            <Columns>
                <asp:BoundField DataField="IDUsuario" HeaderText="ID" />
                <asp:BoundField DataField="Rol" HeaderText="Rol" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>