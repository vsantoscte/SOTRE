using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOTRE.Domain.DAO;

namespace SOTRE.Domain.BLL
{
    public class VeiculoBLL : IBaseBLL<Veiculo>
    {

        VeiculoDAO veiculoDAO = null;

        public VeiculoBLL()
        {
            veiculoDAO = new VeiculoDAO();
        }

        public void Inserir(Veiculo entidade)
        {
            veiculoDAO.Inserir(entidade);
        }

        public void Atualizar(Veiculo entidade)
        {
            veiculoDAO.Atualizar(entidade);
        }

        public void Excluir(int ID)
        {
            Veiculo veiculo = this.ObterPorID(ID);
            veiculoDAO.Excluir(veiculo);
        }

        public Veiculo ObterPorID(int ID)
        {
            return veiculoDAO.ObterPorID(ID);
        }

        public IQueryable<Veiculo> ObterTodos()
        {
            return veiculoDAO.ObterTodos();
        }
    }
}
