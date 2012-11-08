<%@ Page Title="" Language="C#" MasterPageFile="~/SOTRE.Master" AutoEventWireup="true"
    CodeBehind="CadCliente.aspx.cs" Inherits="SOTRE.Web.CadCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="5px" cellspacing="5px">
        <tr valign="middle" align="center">
            <td colspan="4">
                <h1>
                    <asp:Label ID="lblTitulo" runat="server" Width="600px">Cliente</asp:Label>
                </h1>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblNome" runat="server">Nome:</asp:Label>
            </td>
            <td colspan="3">
                <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblTipo" runat="server">Tipo:</asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddpTipo" runat="server">
                </asp:DropDownList>
            </td>
            <td>
                <asp:Label ID="lblCpf" runat="server">CPF/CNPJ:</asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCpf" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblLogradouro" runat="server">Logradouro:</asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtLogradouro" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="lblNumero" runat="server">Número:</asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNumero" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblComplemento" runat="server">Complemento:</asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtComplemento" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="lblBairro" runat="server">Bairro:</asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtBairro" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblCEP" runat="server">CEP:</asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCEP" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="lblCidade" runat="server">Cidade:</asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCidade" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblTurno" runat="server">Turno:</asp:Label>
            </td>
            <td>
                <asp:CheckBox ID="chkManha" Text="Manhã(6hrs às 12hrs)" runat="server" />
                <asp:CheckBox ID="chkTarde" Text="Tarde(12hrs às 18hrs)" runat="server" />
                <asp:CheckBox ID="chkNoite" Text="Noite(18hrs às 0hrs)" runat="server" />
                <asp:CheckBox ID="chkMadrugada" Text="Madrugada(0hrs às 6hrs)" runat="server" />
            </td>
        </tr>
        <tr>
            <td align="right" colspan="3">
                <asp:Button ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />
            </td>
            <td align="left">
                <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
