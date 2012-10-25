using System;
using System.Collections.Generic;
using System.Linq;
using SOTRE.Domain;
using SOTRE.Domain.BLL;

namespace SOTRE.Util
{
    public static class Util
    {

        public static List<Tipo_Cliente> CarregarComboTipoPessoa()
        {
            IQueryable<Tipo_Cliente> query = new TipoClienteBLL().ObterTodos();

            List<Tipo_Cliente> lstTipoClienteAux = query.ToList<Tipo_Cliente>();
            List<Tipo_Cliente> lstTipoCliente = new List<Tipo_Cliente>();

            Tipo_Cliente tipoCliente = new Tipo_Cliente();
            tipoCliente.id_tipo = 0;
            tipoCliente.nm_descricao = String.Empty;

            lstTipoCliente.Add(tipoCliente);

            foreach (Tipo_Cliente objTipoCliente in lstTipoClienteAux)
            {
                lstTipoCliente.Add(objTipoCliente);
            }

            return lstTipoCliente;
        }

        public static List<Cliente> CarregarComboCliente()
        {
            IQueryable<Cliente> query = new ClienteBLL().ObterTodos();

            List<Cliente> lstClienteAux = query.ToList<Cliente>();
            List<Cliente> lstCliente = new List<Cliente>();

            Cliente cliente = new Cliente();
            cliente.id_cliente = 0;
            cliente.nm_nome = String.Empty;

            lstCliente.Add(cliente);

            foreach (Cliente objCliente in lstClienteAux)
            {
                lstCliente.Add(objCliente);
            }

            return lstCliente;
        }

        public static List<Status_Pedido> CarregarComboStatus()
        {
            IQueryable<Status_Pedido> query = new StatusPedidoBLL().ObterTodos();

            List<Status_Pedido> lstStatusAux = query.ToList<Status_Pedido>();
            List<Status_Pedido> lstStatus = new List<Status_Pedido>();

            Status_Pedido status = new Status_Pedido();
            status.id_status = 0;
            status.nm_descricao = String.Empty;

            lstStatus.Add(status);

            foreach (Status_Pedido objStatus in lstStatusAux)
            {
                lstStatus.Add(objStatus);
            }

            return lstStatus;
        }

        public static List<Produto> CarregarComboProduto()
        {
            IQueryable<Produto> query = new ProdutoBLL().ObterTodos();

            List<Produto> lstProdutoAux = query.ToList<Produto>();
            List<Produto> lstProduto = new List<Produto>();

            Produto produto = new Produto();
            produto.id_produto = 0;
            produto.nm_nome = String.Empty;

            lstProduto.Add(produto);

            foreach (Produto objProduto in lstProdutoAux)
            {
                lstProduto.Add(objProduto);
            }

            return lstProduto;
        }

        public static List<Status_Veiculo> CarregarComboStatusVeiculo()
        {
            IQueryable<Status_Veiculo> query = new StatusVeiculoBLL().ObterTodos();

            List<Status_Veiculo> lstAux = query.ToList<Status_Veiculo>();
            List<Status_Veiculo> lstStatusVeiculo = new List<Status_Veiculo>();

            Status_Veiculo tipoStatusVeiculo = new Status_Veiculo();
            tipoStatusVeiculo.id_status = 0;
            tipoStatusVeiculo.nm_descricao = "";

            lstStatusVeiculo.Add(tipoStatusVeiculo);

            foreach (Status_Veiculo objStatusVeiculo in lstAux)
            {
                lstStatusVeiculo.Add(objStatusVeiculo);
            }

            return lstStatusVeiculo;
        }

    }

}
