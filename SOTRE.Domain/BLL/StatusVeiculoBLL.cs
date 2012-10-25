using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOTRE.Domain.DAO;

namespace SOTRE.Domain.BLL
{
    public class StatusVeiculoBLL : IBaseBLL<Status_Veiculo>
    {

        StatusVeiculoDAO statusVeiculoDAO = null;

        public StatusVeiculoBLL()
        {
            statusVeiculoDAO = new StatusVeiculoDAO();
        }

        public void Inserir(Status_Veiculo entidade)
        {
            statusVeiculoDAO.Inserir(entidade);
        }

        public void Atualizar(Status_Veiculo entidade)
        {
            statusVeiculoDAO.Atualizar(entidade);
        }

        public void Excluir(int ID)
        {
            Status_Veiculo statusVeiculo = this.ObterPorID(ID);
            statusVeiculoDAO.Excluir(statusVeiculo);
        }

        public Status_Veiculo ObterPorID(int ID)
        {
            return statusVeiculoDAO.ObterPorID(ID);
        }

        public IQueryable<Status_Veiculo> ObterTodos()
        {
            return statusVeiculoDAO.ObterTodos();
        }
    }
}
