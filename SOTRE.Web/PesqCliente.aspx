<%@ Page Title="" Language="C#" MasterPageFile="~/SOTRE.Master" AutoEventWireup="true"
    CodeBehind="PesqCliente.aspx.cs" Inherits="SOTRE.Web.PesqCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="5px" cellspacing="5px">
        <tr valign="middle" align="center">
            <td colspan="2">
                <h1>
                    <asp:Label ID="lblTitulo" runat="server" Width="600px">Clientes</asp:Label>
                </h1>
            </td>
        </tr>
        <tr>
            <td style="width: 20px;">
                <asp:ImageButton ID="imgAddCliente" runat="server" ImageUrl="~/imgs/add.png" PostBackUrl="~/CadCliente.aspx" />
            </td>
            <td align="left">
                <h3>
                    <asp:Label ID="lblAddCliente" runat="server">Adicionar Cliente</asp:Label>
                </h3>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:UpdatePanel ID="upCadastroCliente" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:GridView ID="grvCliente" runat="server" SkinID="SORTRE">
                            <Columns>
                                <asp:BoundField HeaderText="CPF/CNPJ" DataField="cpf_cnpj" HeaderStyle-Width="20%">
                                    <HeaderStyle Width="20%" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Tipo" DataField="tipo" HeaderStyle-Width="10%">
                                    <HeaderStyle Width="10%" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Nome" DataField="nome" HeaderStyle-Width="35%">
                                    <HeaderStyle Width="35%" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Bairro" DataField="bairro" HeaderStyle-Width="15%">
                                    <HeaderStyle Width="15%" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="CEP" DataField="cep" HeaderStyle-Width="10%">
                                    <HeaderStyle Width="10%" />
                                </asp:BoundField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgEditar" runat="server" ImageUrl="~/imgs/edit.png" PostBackUrl='<%# string.Format("CadCliente.aspx?ID={0}",Eval("ID")) %>' />
                                        <asp:ImageButton ID="imgDeletar" runat="server" ImageUrl="~/imgs/delete.png" CommandArgument='<%# Eval("ID") %>'
                                            OnClientClick="return confirm('Deseja realmente excluir esse registro?')" OnClick="imgDeletar_Click" />
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
    </table>
</asp:Content>
