using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;

namespace SOTRE.Domain
{
    internal class BaseDAO<T> : IBaseDAO<T> where T : class
    {
        #region Membros de IBaseDAO<T>

        /// <summary>
        /// Método Genérico para o Inserir 
        /// </summary>
        /// <typeparam name="T">Tipagem da Classe</typeparam>
        /// <param name="entidade">Objeto a ser Inserido no Banco</param>
        /// <param name="dataContext">Conntexto</param>
        public void Inserir(T entidade, DataContext dataContext)
        {
            try
            {
                using (dataContext)
                {
                    Table<T> table = dataContext.GetTable<T>();
                    table.InsertOnSubmit(entidade);
                    dataContext.SubmitChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Método Genérico para Atualizar um Registro
        /// </summary>
        /// <typeparam name="T">Tipagem da Classe</typeparam>
        /// <param name="entidade">Objeto a ser Atualizado no Banco</param>
        /// <param name="dataContext">Conntexto</param>
        public void Atualizar(T entidade, DataContext dataContext)
        {
            try
            {
                using (dataContext)
            {
                Table<T> tabela = dataContext.GetTable<T>();

                T original = tabela.FirstOrDefault(e => e == entidade);

                if (original != null)
                {
                    var model = new AttributeMappingSource().GetModel(dataContext.GetType());
                    MetaTable tbl = model.GetTable(typeof(T));
                    foreach (var dm in tbl.RowType.DataMembers)
                    {
                        PropertyInfo p1 = original.GetType().GetProperty(dm.MappedName);
                        PropertyInfo p2 = entidade.GetType().GetProperty(dm.MappedName);
                        try
                        {
                            if (p1.PropertyType.ToString() != "System.DateTime")
                            {
                                p1.SetValue(original, p2.GetValue(entidade, null), null);
                            }
                            else
                            {
                                string dtStr = p2.GetValue(entidade, null).ToString();
                                DateTime dt = Convert.ToDateTime(dtStr);
                                System.Diagnostics.Trace.WriteLine(dt.Year);
                                if (dt.Year > 1)
                                {
                                    p1.SetValue(original, p2.GetValue(entidade, null), null);
                                }
                            }
                        }
                        catch
                        {
                            System.Diagnostics.Trace.WriteLine(dm.MappedName);
                        }
                    }
                }

                dataContext.SubmitChanges();
            }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        /// <summary>
        /// Excluir Objeto Entidade
        /// </summary>
        /// <typeparam name="T">Tipagem da Classe</typeparam>
        /// <param name="entidade">Objeto a ser Excluido</param>
        /// <param name="dataContext">Conntexto</param>
        public void Excluir(T entidade, DataContext dataContext)
        {
            try
            {
                using (dataContext)
                {
                    Table<T> tabela = dataContext.GetTable<T>();
                    T original = tabela.FirstOrDefault(e => e == entidade);
                    if (original != null)
                    {
                        tabela.DeleteOnSubmit(original);
                        dataContext.SubmitChanges();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Método Genérico Obter por PK
        /// </summary>
        /// <typeparam name="T">Tipagem da Classe</typeparam>
        /// <param name="ID">ID do Objeto usado como filtro</param>
        /// <param name="dataContext">Conntexto</param>
        /// <returns>Objeto com ID</returns>
        public T ObterPorID(int ID, DataContext dataContext)
        {
            try
            {
                using (dataContext)
                {
                    var tabela = dataContext.GetTable<T>();

                    MetaModel modelMap = tabela.Context.Mapping;
                    ReadOnlyCollection<MetaDataMember> dataMembers = modelMap.GetMetaType(typeof(T)).DataMembers;

                    string pk = (dataMembers.Single<MetaDataMember>(m => m.IsPrimaryKey)).Name;

                    return tabela.SingleOrDefault<T>(delegate(T t)
                    {
                        String membroID = t.GetType().GetProperty(pk).GetValue(t, null).ToString();

                        return membroID.ToString() == ID.ToString();
                    });
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Método Genérico Obter Todos
        /// </summary>
        /// <typeparam name="T">Tipagem da Classe</typeparam>
        /// <param name="dataContext">Contexto</param>
        /// <returns>Lista com Todos os Objetos</returns>
        public IQueryable<T> ObterTodos(DataContext dataContext)
        {
            try
            {
                using (dataContext)
                {
                    var tabela = dataContext.GetTable<T>().ToList<T>();
                    return tabela.AsQueryable<T>();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion
    }
}
