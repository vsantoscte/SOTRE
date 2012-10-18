<%@ Page Title="" Language="C#" MasterPageFile="~/SOTRE.Master" AutoEventWireup="true"
    CodeBehind="CadUsuario.aspx.cs" Inherits="SOTRE.Web.CadUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="5px" cellspacing="5px">
        <tr valign="middle" align="center">
            <td colspan="2">
                <h1>
                    <asp:Label ID="lblTitulo" runat="server" Width="600px">Usuários</asp:Label>
                </h1>
            </td>
        </tr>
        <tr>
            <td style="width: 30px;">
                <asp:Label ID="lblNome" runat="server" Font-Size="Medium">Nome</asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNome" runat="server" MaxLength="100" Width="500px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblCpf" runat="server" Font-Size="Medium">CPF</asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCpf" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblLogin" runat="server" Font-Size="Medium">Login</asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCadLogin" runat="server" MaxLength="20"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblSenha" runat="server" Font-Size="Medium">Senha</asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCadSenha" TextMode="Password" runat="server" MaxLength="15"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="right">
                <table>
                    <tr>
                        <td  align="left">
                            <asp:Button ID="Button1" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />
                        </td>
                        <td  align="right">
                            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
