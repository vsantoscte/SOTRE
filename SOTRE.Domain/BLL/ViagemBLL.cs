using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOTRE.Domain.DAO;

namespace SOTRE.Domain.BLL
{
    public class ViagemBLL : IBaseBLL<Viagem>
    {
        ViagemDAO viagemDAO = null;

        public ViagemBLL()
        {
            viagemDAO = new ViagemDAO();
        }

        public void Inserir(Viagem entidade)
        {
            viagemDAO.Inserir(entidade);
        }

        public void Atualizar(Viagem entidade)
        {
            viagemDAO.Atualizar(entidade);
        }

        public void Excluir(int ID)
        {
            Viagem viagem = viagemDAO.ObterPorID(ID);
            viagemDAO.Excluir(viagem);
        }

        public Viagem ObterPorID(int ID)
        {
            return viagemDAO.ObterPorID(ID);
        }

        public IQueryable<Viagem> ObterTodos()
        {
            return viagemDAO.ObterTodos();
        }
    }
}
