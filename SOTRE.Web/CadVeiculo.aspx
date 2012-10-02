<%@ Page Title="" Language="C#" MasterPageFile="~/SOTRE.Master" AutoEventWireup="true"
    CodeBehind="CadVeiculo.aspx.cs" Inherits="SOTRE.Web.CadVeiculo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="5px" cellspacing="5px">
        <tr valign="middle" align="center">
            <td colspan="2">
                <h1>
                    <asp:Label ID="lblTitulo" runat="server" Width="600px">Veículo</asp:Label>
                </h1>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblNome" runat="server">Nome:</asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblStatus" runat="server">Status:</asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlStatus" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblCapacidade" runat="server">Capacidade:</asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCapacidade" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Button ID="btnVoltar" runat="server" Text="Voltar" 
                    onclick="btnVoltar_Click" />
            </td>
            <td align="right">
                <asp:Button ID="btnSalvar" runat="server" Text="Salvar" 
                    onclick="btnSalvar_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
