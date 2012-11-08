using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOTRE.Domain.DAO;

namespace SOTRE.Domain.BLL
{
    public class TurnoClienteBLL : IBaseBLL<Turno_Cliente>
    {
        TurnoClienteDAO turnoClienteDAO = null;

        public TurnoClienteBLL()
        {
            turnoClienteDAO = new TurnoClienteDAO();
        }

        public void Inserir(Turno_Cliente entidade)
        {
            turnoClienteDAO.Inserir(entidade);
        }

        public void Atualizar(Turno_Cliente entidade)
        {
            turnoClienteDAO.Atualizar(entidade);
        }

        public void Excluir(int ID)
        {
            Turno_Cliente turnoCliente = turnoClienteDAO.ObterPorID(ID);
            turnoClienteDAO.Excluir(turnoCliente);
        }

        public Turno_Cliente ObterPorID(int ID)
        {
            return turnoClienteDAO.ObterPorID(ID);
        }

        public IQueryable<Turno_Cliente> ObterTodos()
        {
            return turnoClienteDAO.ObterTodos();
        }
    }
}
