using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SOTRE.Domain
{
    public interface IBaseDAO<T>
    {
        void Inserir(T entidade);

        void Atualizar(T entidade);

        void Excluir(int ID);

        T ObterPorID<T>(int ID);

        IQueryable<T> ObterTodos();
    }
}
