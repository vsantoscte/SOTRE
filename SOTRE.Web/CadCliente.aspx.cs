using System;
using SOTRE.Domain;
using SOTRE.Domain.BLL;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using SOTRE.Util.GoogleMaps;


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

            IQueryable<Cliente> queryClientes = clienteBLL.ObterTodos();
            List<Cliente> lstCliente = queryClientes.ToList<Cliente>();

            Cordenada novaCordenada = new Cordenada();
            ViagemBLL viagemBLL = new ViagemBLL();

            Viagem viagem = new Viagem();

            if (this.Session["ID"] != null)
            {
                cliente.id_cliente = int.Parse(this.Session["ID"].ToString());
                clienteBLL.Atualizar(cliente);

                foreach (Cliente objCliente in lstCliente)
                {
                    novaCordenada.Latitude = Convert.ToDouble(objCliente.nm_latitude);
                    novaCordenada.Longitude = Util.Util.ConverterCordenadasToDouble(objCliente.nm_longitude.Replace(",", "."));

                    if (!((cordenada.Latitude == novaCordenada.Latitude) && (cordenada.Longitude == novaCordenada.Longitude)))
                    {
                        viagem = Geocodificacao.ObterDistanciaEDuracao(cordenada, novaCordenada);
                        viagem.cd_partida = int.Parse(this.Session["ID"].ToString());
                        viagem.cd_destino = objCliente.id_cliente;

                        viagemBLL.Inserir(viagem);

                        viagem = Geocodificacao.ObterDistanciaEDuracao(novaCordenada, cordenada);
                        viagem.cd_partida = objCliente.id_cliente;
                        viagem.cd_destino = int.Parse(this.Session["ID"].ToString());

                        viagemBLL.Inserir(viagem);
                    }
                }
            }
            else
            {
                clienteBLL.Inserir(cliente);

                cliente = clienteBLL.ObterTodos().Where(w => w.nm_cpf_cnpj == cliente.nm_cpf_cnpj).ToList<Cliente>()[0];

                foreach (Cliente objCliente in lstCliente)
                {
                    novaCordenada.Latitude = Convert.ToDouble(objCliente.nm_latitude);
                    novaCordenada.Longitude = Util.Util.ConverterCordenadasToDouble(objCliente.nm_longitude.Replace(",", "."));

                    if (!((cordenada.Latitude == novaCordenada.Latitude) && (cordenada.Longitude == novaCordenada.Longitude)))
                    {
                        viagem = Geocodificacao.ObterDistanciaEDuracao(cordenada, novaCordenada);
                        viagem.cd_partida = cliente.id_cliente;
                        viagem.cd_destino = objCliente.id_cliente;

                        viagemBLL.Inserir(viagem);

                        viagem = Geocodificacao.ObterDistanciaEDuracao(novaCordenada, cordenada);
                        viagem.cd_partida = objCliente.id_cliente;
                        viagem.cd_destino = cliente.id_cliente;

                        viagemBLL.Inserir(viagem);
                    }
                }
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
    }
}