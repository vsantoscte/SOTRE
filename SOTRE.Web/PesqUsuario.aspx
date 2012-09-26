<%@ Page Language="C#" MasterPageFile="~/SOTRE.Master" AutoEventWireup="true" CodeBehind="PesqUsuario.aspx.cs"
    Inherits="SOTRE.Web.Cadastro.PesqUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h1>Pesquisar Usuários</h1>
    <table cellpadding="5px" cellspacing="5px">
        <tr valign="middle" align="center">
            <td colspan="2">
                <h1>
                    <asp:Label ID="lblTitulo" runat="server" Width="600px">Usuários</asp:Label>
                </h1>
            </td>
        </tr>
        <tr>
            <td style="width: 20px;">
                <asp:ImageButton ID="imgAddUsuario" runat="server" ImageUrl="~/imgs/add.png" PostBackUrl="~/CadUsuario.aspx" />
            </td>
            <td align="left">
                <h3>
                    <asp:Label ID="lblAdcionarUsuario" runat="server">Adicionar Usuário</asp:Label>
                </h3>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:UpdatePanel ID="upCadastroUsuario" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:GridView ID="grvUsuario" runat="server" SkinID="SORTRE">
                            <Columns>
                                <asp:BoundField HeaderText="Nome" DataField="nome" HeaderStyle-Width="40%" />
                                <asp:BoundField HeaderText="CPF" DataField="cpf" HeaderStyle-Width="25%" />
                                <asp:BoundField HeaderText="Login" DataField="login" HeaderStyle-Width="20%" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgEditar" runat="server" PostBackUrl='<%# string.Format("CadUsuario.aspx?ID={0}", Eval("ID")) %>'
                                            ImageUrl="~/imgs/edit.png" />
                                            <asp:ImageButton ID="imgDeletar" runat="server" ImageUrl="~/imgs/delete.png" OnClick="imgDeletar_Click"
                                            OnClientClick="return confirm('Deseja realmente excluir esse registro?')" CommandArgument='<%# Eval("ID") %>' />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" Width="15%" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
