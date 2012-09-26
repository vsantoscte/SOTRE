using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SOTRE.Domain
{
    public class UsuarioDAO : IBaseDAO<Usuario>
    {

        SOTREDataContext contexto = null;

        public UsuarioDAO()
        {
            contexto = new SOTREDataContext();
        }

        /// <summary>
        /// Método Usado Para Obter Usuario para a Autenticação
        /// </summary>
        /// <param name="entidade">Objeto com o Valor do login e senha</param>
        /// <returns>Usuario obtido como retorno da consulta</returns>
        public Usuario UsuarioAutenticar(Usuario entidade)
        {
            return contexto.Usuario.FirstOrDefault(q => q.nm_login == entidade.nm_login && q.nm_senha == entidade.nm_senha);
        }

        #region Membros do IBaseDAO

        public void Inserir(Usuario entidade)
        {
            contexto.Usuario.InsertOnSubmit(entidade);
            contexto.SubmitChanges();
        }
            
        public void Atualizar(Usuario entidade)
        {
            Usuario usuario = contexto.Usuario.FirstOrDefault(w => w.id_usuario == entidade.id_usuario);

            usuario.nm_cpf = entidade.nm_cpf;
            usuario.nm_login = entidade.nm_login;
            usuario.nm_nome = entidade.nm_nome;
            usuario.nm_senha = entidade.nm_senha;

            contexto.SubmitChanges();
        }

        public void Excluir(int ID)
        {
            contexto.Usuario.DeleteOnSubmit(this.ObterPorID(ID));
            contexto.SubmitChanges();
        }   

        public Usuario ObterPorID(int ID)
        {
            return contexto.Usuario.FirstOrDefault(u => u.id_usuario == ID);
        }

        public IQueryable<Usuario> ObterTodos()
        {
            return contexto.Usuario;
        }

        #endregion
    }
}
