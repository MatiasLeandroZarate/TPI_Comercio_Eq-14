<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true" CodeBehind="PageMarcas.aspx.cs" Inherits="TPC_Comercio_Eq_14.PageMarcas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container text-center">
        <h1 class="text-primary ">Marcas </h1>
    </div>
    <div class="container">
        <table class="table table-hover table-sm table-bordered border-primary-subtle">
            <thead>
                <tr>
                    <th scope="col">ID</th>
                    <th scope="col">Nombre</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptMarcas" runat="server">
                    <ItemTemplate>
                        <tr>
                            <th scope="row"><%# Eval("IDMarca") %></th>
                            <td><%# Eval("Nombre") %></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
</asp:Content>
