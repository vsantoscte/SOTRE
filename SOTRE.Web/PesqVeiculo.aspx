<%@ Page Title="" Language="C#" MasterPageFile="~/SOTRE.Master" AutoEventWireup="true"
    CodeBehind="PesqVeiculo.aspx.cs" Inherits="SOTRE.Web.PesqVeiculo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="5px" cellspacing="5px">
        <tr valign="middle" align="center">
            <td colspan="2">
                <h1>
                    <asp:Label ID="lblTitulo" runat="server" Width="600px">Veículos</asp:Label>
                </h1>
            </td>
        </tr>
        <tr>
            <td style="width: 20px;">
                <asp:ImageButton ID="imgAddVeiculo" runat="server" ImageUrl="~/imgs/add.png" PostBackUrl="~/CadVeiculo.aspx" />
            </td>
            <td align="left">
                <h3>
                    <asp:Label ID="lblAddVeiculo" runat="server">Adicionar Veículo</asp:Label>
                </h3>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:UpdatePanel ID="upCadastroVeiculo" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:GridView ID="grvVeiculo" runat="server" SkinID="SORTRE">
                            <Columns>
                                <asp:BoundField HeaderText="Nome" DataField="nome" HeaderStyle-Width="40%" />
                                <asp:BoundField HeaderText="Status" DataField="status" HeaderStyle-Width="30%" />
                                <asp:BoundField HeaderText="Capacidade(Kg)" DataField="capacidade" HeaderStyle-Width="20%" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgEditar" runat="server" ImageUrl="~/imgs/edit.png" PostBackUrl='<%# string.Format("CadVeiculo.aspx?ID={0}",Eval("ID")) %>'/>
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
    </table>
</asp:Content>
