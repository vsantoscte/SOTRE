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
            tipoCliente.nm_descricao_tipo = String.Empty;

            lstTipoCliente.Add(tipoCliente);

            foreach (Tipo_Cliente objTipoCliente in lstTipoClienteAux)
            {
                lstTipoCliente.Add(objTipoCliente);
            }

            return lstTipoCliente;
        }

        public static List<Tab_Tipo_Status_Veiculo> CarregarComboStatusVeiculo()
        {
            IQueryable<Tab_Tipo_Status_Veiculo> query = new StatusVeiculoBLL().ObterTodos();

            List<Tab_Tipo_Status_Veiculo> lstAux = query.ToList<Tab_Tipo_Status_Veiculo>();
            List<Tab_Tipo_Status_Veiculo> lstStatusVeiculo = new List<Tab_Tipo_Status_Veiculo>();

            Tab_Tipo_Status_Veiculo tipoStatusVeiculo = new Tab_Tipo_Status_Veiculo();
            tipoStatusVeiculo.id_status = 0;
            tipoStatusVeiculo.nm_descricao = "";

            lstStatusVeiculo.Add(tipoStatusVeiculo);

            foreach (Tab_Tipo_Status_Veiculo objStatusVeiculo in lstAux)
            {
                lstStatusVeiculo.Add(objStatusVeiculo);
            }

            return lstStatusVeiculo;
        }

    }
}
