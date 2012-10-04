using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SOTRE.Domain.DAO
{
    internal class PedidoDAO : BaseDAO<Pedido>
    {
        public Pedido RetornarUltimoPedido(SOTREDataContext contexto)
        {
            return new Pedido();
        }
    }
}
