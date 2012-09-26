using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace SOTRE.Domain
{
    internal interface IBaseDAO<T> where T : class
    {
        void Inserir(T entidade, DataContext dataContext);

        void Atualizar(T entidade, DataContext dataContext);

        void Excluir(T entidade, DataContext dataContext);

        T ObterPorID(int ID, DataContext dataContext);

        IQueryable<T> ObterTodos(DataContext dataContext);
    }
}
