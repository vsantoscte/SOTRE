using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SOTRE.Domain
{
    public class UsuarioBLL : IBaseBLL<Usuario>
    {
        UsuarioDAO usuarioDAO = null;

        public UsuarioBLL()
        {
            usuarioDAO = new UsuarioDAO();
        }

        public void Inserir(Usuario entidade)
        {
            usuarioDAO.Inserir(entidade);
        }

        public void Atualizar(Usuario entidade)
        {
            usuarioDAO.Atualizar(entidade);
        }

        public void Excluir(int ID)
        {
            Usuario entidade = this.ObterPorID(ID);
            usuarioDAO.Excluir(entidade);
        }

        public Usuario ObterPorID(int ID)
        {
            return usuarioDAO.ObterPorID(ID);
        }

        public IQueryable<Usuario> ObterTodos()
        {
            return usuarioDAO.ObterTodos();
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
