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

        public ProdutoBLL()
        {
            produtoDAO = new ProdutoDAO();
        }

        public void Inserir(Produto entidade)
        {
            produtoDAO.Inserir(entidade);
        }

        public void Atualizar(Produto entidade)
        {
            produtoDAO.Atualizar(entidade);
        }

        public void Excluir(int ID)
        {
            Produto produto = this.ObterPorID(ID);
            produtoDAO.Excluir(produto);
        }

        public Produto ObterPorID(int ID)
        {
            return produtoDAO.ObterPorID(ID);
        }

        public IQueryable<Produto> ObterTodos()
        {
            return produtoDAO.ObterTodos();
        }
    }
}
