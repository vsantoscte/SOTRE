using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace SOTRE.Domain
{
    public interface IBaseDAO<T>
    {
        void Inserir(T entidade, DataContext dataContext);

        void Atualizar(T entidade, DataContext dataContext);

        void Excluir(T entidade, DataContext dataContext);

        T ObterPorID(int ID, DataContext dataContext);

        IList<T> ObterTodos(DataContext dataContext);
    }
}
