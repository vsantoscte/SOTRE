<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SOS.Web.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>SOTRE - Sistema Otimizador para Traçar Rotas de Entregas</title>
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <meta name="author" content="Victor Milton Lédo dos Santos" />
    <link href="Styles/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function maximize() {
            var margem = ((screen.height - 750) / 2);
            document.getElementById('principal').style.height = ((screen.height - 290) - margem) + 'px';
            document.getElementById('principal').style.marginTop = margem + 'px';
        } 
    </script>
</head>
<body id="duascolunas" onload="maximize()">
    <div id="tudo">
        <div id="topo">
            <h1>
                TOPO</h1>
        </div>
        <div id="principal" style="width: 795px; margin-left: 0px; vertical-align: middle;
            text-align: center;">
            <div style="background-image: url('imgs/loginbox.png'); width: 325px; height: 250px;
                background-repeat: no-repeat; margin-left: 237.5px; margin-top: 100px;">
                <form id="form1" runat="server">
                <table style="padding-top: 65px; padding-left: 54px">
                    <tr>
                        <td>
                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                            </asp:ScriptManager>
                            <asp:Login ID="loginSOTRE" runat="server" TitleText="Efetue o seu Login" Font-Size="10pt"
                                UserNameLabelText="Usuário:" PasswordLabelText="Senha:" LoginButtonText="Logar"
                                LoginButtonStyle-BackColor="white" LoginButtonStyle-BorderColor="Black" DisplayRememberMe="False"
                                BackColor="White" FailureText="Usuario e/ou senha inválidos." BorderColor="#CCCC99"
                                DestinationPageUrl="~/Index.aspx" BorderStyle="Solid" Font-Names="Verdana" OnAuthenticate="loginSOTRE_Authenticate">
                                <LoginButtonStyle BackColor="White" BorderColor="Black"></LoginButtonStyle>
                                <TitleTextStyle BackColor="Black" Font-Bold="True" ForeColor="#FFFFFF" />
                            </asp:Login>
                        </td>
                    </tr>
                </table>
                </form>
            </div>
        </div>
        <div id="rodape">
            <p>
                Desenvolvido por Victor Milton Lédo dos Santos</p>
        </div>
    </div>
</body>
</html>
