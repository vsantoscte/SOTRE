﻿using System;
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
    public abstract class BaseDAO<T> : IBaseDAO<T>
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
                    dataContext.GetTable<T>().InsertAllOnSubmit<T>(entidade); 
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
            using (dataContext)
            {
                Table<T> tabela = dataContext.GetTable<T>;
                T original = tabela.FirstOrDefault(e => e.ToString() == entidade.ToString());
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
                dataContext.Dispose();
                return original;
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
                Type tType = entidade.GetType();
                Object newObj = Activator.CreateInstance(tType, new object[0]);

                PropertyDescriptorCollection originalProps = TypeDescriptor.GetProperties(entidade);

                foreach (PropertyDescriptor currentProp in originalProps)
                {
                    if (currentProp.Attributes[typeof(System.Data.Linq.Mapping.ColumnAttribute)] != null)
                    {
                        object val = currentProp.GetValue(entidade);
                        currentProp.SetValue(newObj, val);
                    }
                }

                using (dataContext)
                {
                    var table = dataContext.GetTable<T>();
                    table.Attach((T)newObj, true);
                    table.DeleteOnSubmit((T)newObj);
                    dataContext.SubmitChanges();
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

        /// <summary>
        /// Método Genérico Obter Todos
        /// </summary>
        /// <typeparam name="T">Tipagem da Classe</typeparam>
        /// <param name="dataContext">Contexto</param>
        /// <returns>Lista com Todos os Objetos</returns>
        public IList<T> ObterTodos(DataContext dataContext) 
        {
            try
            {
                using (dataContext)
                {
                    var tabela = dataContext.GetTable<T>().ToList<T>();
                    return tabela;
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
