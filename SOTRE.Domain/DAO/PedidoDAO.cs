using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace SOTRE.Domain.DAO
{
    internal class PedidoDAO : BaseDAO<Pedido>
    {

        public Pedido RetornarUltimoPedido()
        {
            try
            {
                using (SOTREDataContext contexto = new SOTREDataContext())
                {
                    IQueryable<Pedido> query = contexto.Pedidos.ToList<Pedido>().AsQueryable<Pedido>();
                    query = query.OrderBy(q => q.id_pedido);

                    return query.Last<Pedido>();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
