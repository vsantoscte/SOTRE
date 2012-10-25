using System;
using SOTRE.Domain;
using SOTRE.Domain.BLL;
using SOTRE.Util.GoogleMaps;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;


namespace SOTRE.Web
{
    public partial class CadCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.CarregarCompoTipo();

                if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                {
                    this.CarregarTela(int.Parse(Request.QueryString["ID"]));

                    this.Session["ID"] = int.Parse(Request.QueryString["ID"]);
                }
            }
        }

        private void CarregarTela(int ID)
        {
            Cliente cliente = new ClienteBLL().ObterPorID(ID);

            this.txtNome.Text = cliente.nm_nome;
            this.ddpTipo.SelectedValue = cliente.cd_tipo.ToString();
            this.txtCpf.Text = cliente.nm_cpf_cnpj;
            this.txtLogradouro.Text = cliente.nm_logradouro;
            this.txtNumero.Text = cliente.cd_numero.ToString();
            this.txtComplemento.Text = cliente.nm_complemento;
            this.txtBairro.Text = cliente.nm_bairro;
            this.txtCEP.Text = cliente.nm_cep;
            this.txtCidade.Text = cliente.nm_cidade;
        }

        private void CarregarCompoTipo()
        {
            ddpTipo.DataSource = Util.Util.CarregarComboTipoPessoa();
            ddpTipo.DataTextField = "nm_descricao";
            ddpTipo.DataValueField = "id_tipo";
            ddpTipo.DataBind();
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("PesqCliente.aspx");
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            ClienteBLL clienteBLL = new ClienteBLL();

            cliente.nm_nome = this.txtNome.Text;
            cliente.nm_cpf_cnpj = this.txtCpf.Text;
            cliente.cd_tipo = int.Parse(this.ddpTipo.SelectedValue);
            cliente.nm_logradouro = this.txtLogradouro.Text;
            cliente.cd_numero = int.Parse(this.txtNumero.Text);
            cliente.nm_complemento = this.txtComplemento.Text;
            cliente.nm_bairro = this.txtBairro.Text;
            cliente.nm_cep = this.txtCEP.Text;
            cliente.nm_cidade = this.txtCidade.Text;

            Cordenada cordenada = Geocodificacao.GetCordenadas(this.FormataStringEndereco());
            cliente.nm_latitude = cordenada.Latitude.ToString();
            cliente.nm_longitude = cordenada.Longitude.ToString();

            if (this.Session["ID"] != null)
            {
                cliente.id_cliente = int.Parse(this.Session["ID"].ToString());
                clienteBLL.Atualizar(cliente);
            }
            else
            {
                clienteBLL.Inserir(cliente);
            }

            Response.Redirect("PesqCliente.aspx");
        }

        private string FormataStringEndereco()
        {
            StringBuilder strAppend = new StringBuilder();
            strAppend.Append(this.txtLogradouro.Text);

            if (!string.IsNullOrEmpty(this.txtNumero.Text))
            {
                strAppend.Append(", ");
                strAppend.Append(this.txtNumero.Text);
            }

            strAppend.Append(", ");
            strAppend.Append(this.txtBairro.Text);
            strAppend.Append(", ");
            strAppend.Append(this.txtCidade.Text);
            strAppend.Append(" - Bahia, Brasil");

            return strAppend.ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Cordenada c1 = new Cordenada(-12.90441060922158, -38.440848800000026);
            Cordenada c2 = new Cordenada(-13.997361944488656, -42.476439500000026);

            double d = Geocodificacao.DistanceTo(c1, c2);

        }
    }
}