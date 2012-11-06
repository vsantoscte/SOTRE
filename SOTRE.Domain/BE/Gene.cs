using System;
using SOTRE.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SOTRE.Domain.BE
{
    public class Gene
    {
        public Veiculo Veiculo { get; set; }
        public List<Pedido> lstPedido { get; set; }

        public Gene()
        {
            lstPedido = new List<Pedido>();
            Veiculo = new Veiculo();
        }
    }
}
