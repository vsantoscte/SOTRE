using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace SOTRE.Domain
{
    internal interface IBaseDAO<T> where T : class
    {
        void Inserir(T entidade);

        void Atualizar(T entidade);

        void Excluir(T entidade);

        T ObterPorID(int ID);

        IQueryable<T> ObterTodos();
    }
}
