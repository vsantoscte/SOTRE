using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOTRE.Domain.DAO;

namespace SOTRE.Domain.BLL
{
    public class DemandaBLL: IBaseBLL<Demanda>
    {

        DemandaDAO demandaDAO = null;

        public DemandaBLL()
        {
            demandaDAO = new DemandaDAO();
        }

        public void Inserir(Demanda entidade)
        {
            demandaDAO.Inserir(entidade);
        }

        public void Atualizar(Demanda entidade)
        {
            demandaDAO.Atualizar(entidade);
        }

        public void Excluir(int ID)
        {
            Demanda demanda = this.ObterPorID(ID);
            demandaDAO.Excluir(demanda);
        }

        public Demanda ObterPorID(int ID)
        {
            return demandaDAO.ObterPorID(ID);
        }

        public IQueryable<Demanda> ObterTodos()
        {
            return demandaDAO.ObterTodos();
        }
    }
}
