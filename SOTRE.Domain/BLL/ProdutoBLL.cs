using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOTRE.Domain.DAO;

namespace SOTRE.Domain.BLL
{
    public class ProdutoBLL : IBaseBLL<Produto>
    {

        ProdutoDAO produtoDAO = null;
        SOTREDataContext contexto = null;

        public ProdutoBLL()
        {
            produtoDAO = new ProdutoDAO();
            contexto = new SOTREDataContext();
        }

        public void Inserir(Produto entidade)
        {
            produtoDAO.Inserir(entidade, contexto);
        }

        public void Atualizar(Produto entidade)
        {
            produtoDAO.Atualizar(entidade, contexto);
        }

        public void Excluir(int ID)
        {
            Produto produto = this.ObterPorID(ID);
            produtoDAO.Excluir(produto, contexto = new SOTREDataContext());
        }

        public Produto ObterPorID(int ID)
        {
            return produtoDAO.ObterPorID(ID, contexto);
        }

        public IQueryable<Produto> ObterTodos()
        {
            return produtoDAO.ObterTodos(contexto);
        }
    }
}
