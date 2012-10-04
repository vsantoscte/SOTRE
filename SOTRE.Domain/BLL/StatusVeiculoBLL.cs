using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOTRE.Domain.DAO;

namespace SOTRE.Domain.BLL
{
    public class StatusVeiculoBLL : IBaseBLL<Tab_Tipo_Status_Veiculo>
    {

        StatusVeiculoDAO statusVeiculoDAO = null;

        public StatusVeiculoBLL()
        {
            statusVeiculoDAO = new StatusVeiculoDAO();
        }

        public void Inserir(Tab_Tipo_Status_Veiculo entidade)
        {
            statusVeiculoDAO.Inserir(entidade);
        }

        public void Atualizar(Tab_Tipo_Status_Veiculo entidade)
        {
            statusVeiculoDAO.Atualizar(entidade);
        }

        public void Excluir(int ID)
        {
            Tab_Tipo_Status_Veiculo statusVeiculo = this.ObterPorID(ID);
            statusVeiculoDAO.Excluir(statusVeiculo);
        }

        public Tab_Tipo_Status_Veiculo ObterPorID(int ID)
        {
            return statusVeiculoDAO.ObterPorID(ID);
        }

        public IQueryable<Tab_Tipo_Status_Veiculo> ObterTodos()
        {
            return statusVeiculoDAO.ObterTodos();
        }
    }
}
