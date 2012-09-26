using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Collections.ObjectModel;

namespace SOTRE.Domain
{
    public class BaseDAO<T> : IBaseDAO<T>
    {
        #region Membros de IBaseDAO<T>

        public void Inserir(T entidade, DataContext db)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(T entidade)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int ID)
        {
            throw new NotImplementedException();
        }

        public T ObterPorID<T>(int ID, DataContext dataContext) where T : class
        {
            try
            {
                using (dataContext)
                {
                    var tabela = dataContext.GetType<T>();

                    MetaModel modelMap = tabela.Context.Mapping;
                    ReadOnlyCollection<MetaDataMember> dataMembers = modelMap.GetMetaType(typeof(T)).DataMembers;

                    string id = (dataMembers.Single<MetaDataMember>(m => m.IsPrimaryKey)).Name;

                    return tabela.SingleOrDefault<T>(delegate(T t)
                    {
                        String membroID = t.GetType().GetProperty(id).GetValue(t, null).ToString();

                        return membroID.ToString() == id.ToString();
                    });
                }   

            }
            catch (Exception)
            {

                throw;
            }
        }

        public IQueryable<T> ObterTodos()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
