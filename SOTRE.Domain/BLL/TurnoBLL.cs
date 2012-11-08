using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOTRE.Domain.DAO;

namespace SOTRE.Domain.BLL
{
    public class TurnoBLL : IBaseBLL<Turno>
    {
        TurnoDAO turnoDAO = null;

        public TurnoBLL()
        {
            turnoDAO = new TurnoDAO();
        }

        public void Inserir(Turno entidade)
        {
            turnoDAO.Inserir(entidade);
        }

        public void Atualizar(Turno entidade)
        {
            turnoDAO.Atualizar(entidade);
        }

        public void Excluir(int ID)
        {
            Turno turno = turnoDAO.ObterPorID(ID);
            turnoDAO.Excluir(turno);
        }

        public Turno ObterPorID(int ID)
        {
            return turnoDAO.ObterPorID(ID);
        }

        public IQueryable<Turno> ObterTodos()
        {
            return turnoDAO.ObterTodos();
        }
    }

}
