<%@ Page Title="" Language="C#" MasterPageFile="~/SOTRE.Master" AutoEventWireup="true"
    CodeBehind="CadPedido.aspx.cs" Inherits="SOTRE.Web.CadPedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="5px" cellspacing="5px">
        <tr valign="middle" align="center">
            <td colspan="2">
                <h1>
                    <asp:Label ID="lblTitulo" runat="server" Width="600px">Pedido</asp:Label>
                </h1>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblCliente" runat="server">Cliente:</asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlCliente" runat="server">
                </asp:DropDownList>
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
            <td colspan="2">
                <asp:Label ID="lblItemPedidos" Font-Bold="true" runat="server">Itens do Pedido:</asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblProduto" runat="server">Produtos:</asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlProdutos" runat="server">
                </asp:DropDownList>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblqtd" runat="server">Quantidate:</asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtqtd" runat="server"></asp:TextBox>
                <asp:ImageButton ID="imgAddProduto" runat="server" Width="20px" ImageUrl="~/imgs/add.png"
                     onclick="imgAddProduto_Click" />
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:UpdatePanel ID="upCadastroPedido" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:GridView ID="grvPedido" runat="server" SkinID="SORTRE">
                            <Columns>
                                <asp:BoundField HeaderText="Produto" DataField="Nome_Produto" HeaderStyle-Width="40%" />
                                <asp:BoundField HeaderText="Quantidade" DataField="Quantidade" HeaderStyle-Width="30%" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgDeletar" runat="server" ImageUrl="~/imgs/delete.png" OnClientClick="return confirm('Deseja realmente excluir esse registro?')"
                                            OnClick="imgDeletar_Click" CommandArgument='<%# Eval("ID") %>' />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" Width="10%" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Button ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />
            </td>
            <td align="right">
                <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
