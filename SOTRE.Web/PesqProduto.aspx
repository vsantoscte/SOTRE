<%@ Page Title="" Language="C#" MasterPageFile="~/SOTRE.Master" AutoEventWireup="true"
    CodeBehind="PesqProduto.aspx.cs" Inherits="SOTRE.Web.PesqProduto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="5px" cellspacing="5px">
        <tr valign="middle" align="center">
            <td colspan="2">
                <h1>
                    <asp:Label ID="lblTitulo" runat="server" Width="600px">Produtos</asp:Label>
                </h1>
            </td>
        </tr>
        <tr>
            <td style="width: 20px;">
                <asp:ImageButton ID="imgAddProduto" runat="server" ImageUrl="~/imgs/add.png" PostBackUrl="~/CadProduto.aspx"/>
            </td>
            <td align="left">
                <h3>
                    <asp:Label ID="lblAdcionarProduto" runat="server">Adicionar Produto</asp:Label>
                </h3>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:UpdatePanel ID="upCadastroProduto" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:GridView ID="grvProduto" runat="server" SkinID="SORTRE">
                            <Columns>
                                <asp:BoundField HeaderText="Nome" DataField="nome" HeaderStyle-Width="20%" />
                                <asp:BoundField HeaderText="Duração Descarga(min)" DataField="descarga" HeaderStyle-Width="20%" />
                                <asp:BoundField HeaderText="Capacidade Ocupada(kg)" DataField="capacidade" HeaderStyle-Width="20%" />
                                <asp:BoundField HeaderText="Descrição" DataField="descricao" HeaderStyle-Width="30%" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgEditar" runat="server" PostBackUrl='<%# string.Format("CadProduto.aspx?ID={0}", Eval("ID")) %>'
                                            ImageUrl="~/imgs/edit.png" />
                                        <asp:ImageButton ID="imgDeletar" runat="server" ImageUrl="~/imgs/delete.png" OnClick="imgDeletar_Click"
                                            OnClientClick="return confirm('Deseja realmente excluir esse registro?')" CommandArgument='<%# Eval("ID") %>' />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" Width="10%" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
