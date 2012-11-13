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

            if (VerificarExistenciaTurno(cliente.id_cliente, 6, 11) > 0)
            {
                chkManha.Checked = true;
            }

            if (VerificarExistenciaTurno(cliente.id_cliente, 12, 17) > 0)
            {
                chkTarde.Checked = true;
            }

            if (VerificarExistenciaTurno(cliente.id_cliente, 18, 23) > 0)
            {
                chkNoite.Checked = true;
            }

            if (VerificarExistenciaTurno(cliente.id_cliente, 0, 5) > 0)
            {
                chkMadrugada.Checked = true;
            }

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

        private int VerificarExistenciaTurno(int idCliente, int horaInicial1, int horaInicial2)
        {
            TurnoClienteBLL turnoClienteBLL = new TurnoClienteBLL();
            TurnoBLL turnoBLL = new TurnoBLL();

            IQueryable<Turno_Cliente> queryTurnoCliente = turnoClienteBLL.ObterTodos();
            IQueryable<Turno> queryTurno = turnoBLL.ObterTodos();

            return (from tc in queryTurnoCliente
                    join t in queryTurno on tc.cd_turno equals t.id_turno
                    select new
                    {
                        ID = t.id_turno,
                        IdCliente = tc.cd_cliente,
                        HoraInicial = t.cd_horaInicial
                    }).Where(w => w.IdCliente == idCliente && w.HoraInicial >= horaInicial1 && w.HoraInicial <= horaInicial2).ToList().Count;
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
            List<Turno_Cliente> lstTurnoCliente = new List<Turno_Cliente>();
            Turno_Cliente turnoCliente = null;
            TurnoClienteBLL turnoClienteBLL = new TurnoClienteBLL();
            List<Turno> lstTurno = new List<Turno>();
            TurnoBLL turnoBLL = new TurnoBLL();

            cliente.nm_nome = this.txtNome.Text;
            cliente.nm_cpf_cnpj = this.txtCpf.Text;
            cliente.cd_tipo = int.Parse(this.ddpTipo.SelectedValue);
            cliente.nm_logradouro = this.txtLogradouro.Text;
            cliente.cd_numero = int.Parse(this.txtNumero.Text);
            cliente.nm_complemento = this.txtComplemento.Text;
            cliente.nm_bairro = this.txtBairro.Text;
            cliente.nm_cep = this.txtCEP.Text;
            cliente.nm_cidade = this.txtCidade.Text;


            IQueryable<Turno> queryTurno = turnoBLL.ObterTodos();

            if (chkManha.Checked)
            {
                lstTurno = queryTurno.Where(w => w.cd_horaInicial >= 6 && w.cd_horaInicial <= 11).ToList<Turno>();

                lstTurnoCliente = PreencherTurnoCliente(lstTurno, lstTurnoCliente);

                lstTurno.Clear();
            }

            if (chkTarde.Checked)
            {
                lstTurno = queryTurno.Where(w => w.cd_horaInicial >= 12 && w.cd_horaInicial <= 17).ToList<Turno>();

                lstTurnoCliente = PreencherTurnoCliente(lstTurno, lstTurnoCliente);

                lstTurno.Clear();
            }

            if (chkNoite.Checked)
            {
                lstTurno = queryTurno.Where(w => w.cd_horaInicial >= 18 && w.cd_horaInicial <= 23).ToList<Turno>();

                lstTurnoCliente = PreencherTurnoCliente(lstTurno, lstTurnoCliente);

                lstTurno.Clear();

            }

            if (chkMadrugada.Checked)
            {

                lstTurno = queryTurno.Where(w => w.cd_horaInicial >= 0 && w.cd_horaInicial <= 5).ToList<Turno>();

                lstTurnoCliente = PreencherTurnoCliente(lstTurno, lstTurnoCliente);

                lstTurno.Clear();
            }

            Cordenada cordenada = Geocodificacao.GetCordenadas(this.FormataStringEndereco());
            cliente.nm_latitude = cordenada.Latitude.ToString();
            cliente.nm_longitude = cordenada.Longitude.ToString();

            IQueryable<Cliente> queryClientes = clienteBLL.ObterTodos();
            List<Cliente> lstCliente = queryClientes.ToList<Cliente>();

            Cordenada novaCordenada = new Cordenada();
            ViagemBLL viagemBLL = new ViagemBLL();

            Viagem viagem = new Viagem();
            List<Turno_Cliente> lstTurnoClienteExcluir = new List<Turno_Cliente>();
            IQueryable<Turno_Cliente> queryTurnoCliente = turnoClienteBLL.ObterTodos();


            if (this.Session["ID"] != null)
            {
                cliente.id_cliente = int.Parse(this.Session["ID"].ToString());
                clienteBLL.Atualizar(cliente);

                lstTurnoClienteExcluir = queryTurnoCliente.Where(w => w.cd_cliente == cliente.id_cliente).ToList<Turno_Cliente>();

                foreach (Turno_Cliente item in lstTurnoClienteExcluir)
                {
                    turnoClienteBLL.Excluir(item.id_turno_cliente);
                }

                foreach (Turno_Cliente item in lstTurnoCliente)
                {
                    item.cd_cliente = cliente.id_cliente;
                    turnoClienteBLL.Inserir(item);
                }


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

                foreach (Turno_Cliente item in lstTurnoCliente)
                {
                    item.cd_cliente = cliente.id_cliente;
                    turnoClienteBLL.Inserir(item);
                }

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

        private List<Turno_Cliente> PreencherTurnoCliente(List<Turno> lstTurno, List<Turno_Cliente> lstTurnoCliente)
        {
            Turno_Cliente turnoCliente = null;

            foreach (Turno item in lstTurno)
            {
                turnoCliente = new Turno_Cliente();

                turnoCliente.cd_turno = item.id_turno;

                lstTurnoCliente.Add(turnoCliente);
            }

            return lstTurnoCliente;
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