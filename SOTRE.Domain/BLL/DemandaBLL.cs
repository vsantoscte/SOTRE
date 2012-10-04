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
        SOTREDataContext contexto = null;

        public DemandaBLL()
        {
            demandaDAO = new DemandaDAO();
            contexto = new SOTREDataContext();
        }

        public void Inserir(Demanda entidade)
        {
            demandaDAO.Inserir(entidade, contexto);
        }

        public void Atualizar(Demanda entidade)
        {
            demandaDAO.Atualizar(entidade, contexto);
        }

        public void Excluir(int ID)
        {
            Demanda demanda = this.ObterPorID(ID);
            demandaDAO.Excluir(demanda, contexto = new SOTREDataContext());
        }

        public Demanda ObterPorID(int ID)
        {
            return demandaDAO.ObterPorID(ID, contexto);
        }

        public IQueryable<Demanda> ObterTodos()
        {
            return demandaDAO.ObterTodos(contexto);
        }
    }
}
