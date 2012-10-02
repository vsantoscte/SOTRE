using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOTRE.Domain.DAO;

namespace SOTRE.Domain.BLL
{
    public class VeiculoBLL: IBaseBLL<Veiculo>
    {

        VeiculoDAO veiculoDAO = null;
        SOTREDataContext contexto = null;

        public VeiculoBLL()
        {
            veiculoDAO = new VeiculoDAO();
            contexto = new SOTREDataContext();
        }

        public void Inserir(Veiculo entidade)
        {
            veiculoDAO.Inserir(entidade, contexto);
        }

        public void Atualizar(Veiculo entidade)
        {
            veiculoDAO.Atualizar(entidade, contexto);
        }

        public void Excluir(int ID)
        {
            Veiculo veiculo = this.ObterPorID(ID);
            veiculoDAO.Excluir(veiculo, contexto);
        }

        public Veiculo ObterPorID(int ID)
        {
            return veiculoDAO.ObterPorID(ID, contexto);
        }

        public IQueryable<Veiculo> ObterTodos()
        {
            return veiculoDAO.ObterTodos(contexto);
        }
    }
}
