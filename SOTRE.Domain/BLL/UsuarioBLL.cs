using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SOTRE.Domain
{
    public class UsuarioBLL : IBaseBLL<Usuario>
    {
        UsuarioDAO usuarioDAO = null;
        SOTREDataContext context = null;

        public UsuarioBLL()
        {
            usuarioDAO = new UsuarioDAO();
            context = new SOTREDataContext();
        }

        public void Inserir(Usuario entidade)
        {
            usuarioDAO.Inserir(entidade, context);
        }

        public void Atualizar(Usuario entidade)
        {
            usuarioDAO.Atualizar(entidade, context);
        }

        public void Excluir(int ID)
        {
            Usuario entidade = this.ObterPorID(ID);
            usuarioDAO.Excluir(entidade, context = new SOTREDataContext());
        }

        public Usuario ObterPorID(int ID)
        {
            return usuarioDAO.ObterPorID(ID, context);
        }

        public IQueryable<Usuario> ObterTodos()
        {
            return usuarioDAO.ObterTodos(context);
        }


        /// <summary>
        /// Método Usado Para Obter Usuario para a Autenticação
        /// </summary>
        /// <param name="entidade">Objeto com o Valor do login e senha</param>
        /// <returns>Usuario obtido como retorno da consulta</returns>
        public Boolean UsuarioAutenticar(Usuario entidade)
        {
            Usuario usuario = usuarioDAO.UsuarioAutenticar(entidade);

            if (usuario != null)
            {
                return true;
            }

            return false;
        }
    }
}
