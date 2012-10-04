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
        SOTREDataContext contexto = null;

        public StatusVeiculoBLL()
        {
            statusVeiculoDAO = new StatusVeiculoDAO();
            contexto = new SOTREDataContext();
        }

        public void Inserir(Tab_Tipo_Status_Veiculo entidade)
        {
            statusVeiculoDAO.Inserir(entidade, contexto);
        }

        public void Atualizar(Tab_Tipo_Status_Veiculo entidade)
        {
            statusVeiculoDAO.Atualizar(entidade, contexto);
        }

        public void Excluir(int ID)
        {
            Tab_Tipo_Status_Veiculo statusVeiculo = this.ObterPorID(ID);
            statusVeiculoDAO.Excluir(statusVeiculo, contexto = new SOTREDataContext());
        }

        public Tab_Tipo_Status_Veiculo ObterPorID(int ID)
        {
            return statusVeiculoDAO.ObterPorID(ID, contexto);
        }

        public IQueryable<Tab_Tipo_Status_Veiculo> ObterTodos()
        {
            return statusVeiculoDAO.ObterTodos(contexto);
        }
    }
}
