using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace SOTRE.Domain
{
    public interface IBaseBLL<T> where T : class
    {
        void Inserir(T entidade);

        void Atualizar(T entidade);

        void Excluir(int ID);

        T ObterPorID(int ID);

        IQueryable<T> ObterTodos();
    }
}
