<%@ Page Title="" Language="C#" MasterPageFile="~/SOTRE.Master" AutoEventWireup="true"
    CodeBehind="PesqPedido.aspx.cs" Inherits="SOTRE.Web.PesqPedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="5px" cellspacing="5px">
        <tr valign="middle" align="center">
            <td colspan="2">
                <h1>
                    <asp:Label ID="lblTitulo" runat="server" Width="600px">Pedidos</asp:Label>
                </h1>
            </td>
        </tr>
        <tr>
            <td style="width: 20px;">
                <asp:ImageButton ID="imgAddPedido" runat="server" ImageUrl="~/imgs/add.png" PostBackUrl="~/CadPedido.aspx" />
            </td>
            <td align="left">
                <h3>
                    <asp:Label ID="lblAddPedido" runat="server">Adicionar Pedido</asp:Label>
                </h3>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:UpdatePanel ID="upCadastroPedido" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:GridView ID="grvPedido" runat="server" SkinID="SORTRE">
                            <Columns>
                            <asp:BoundField HeaderText="Nome Cliente" DataField="Cliente" 
                                    HeaderStyle-Width="30%" >
                                <HeaderStyle Width="30%" />
                                </asp:BoundField>
                            <asp:BoundField HeaderText="Espaço Ocupado Total(kg)" DataField="Espaco" 
                                    HeaderStyle-Width="30%" >
                                <HeaderStyle Width="30%" />
                                </asp:BoundField>
                            <asp:BoundField HeaderText="Status" DataField="Status" HeaderStyle-Width="30%" >
                                <HeaderStyle Width="30%" />
                                </asp:BoundField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgEditar" runat="server" ImageUrl="~/imgs/edit.png" 
                                            style="margin-right: 0px" />
                                        <asp:ImageButton ID="imgDeletar" runat="server" ImageUrl="~/imgs/delete.png" 
                                            OnClientClick="return confirm('Deseja realmente excluir esse registro?')" 
                                            onclick="imgDeletar_Click" CommandArgument='<%# Eval("ID") %>' />
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
