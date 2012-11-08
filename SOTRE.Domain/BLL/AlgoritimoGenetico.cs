using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOTRE.Domain.BE;
using System.Web;

namespace SOTRE.Domain.BLL
{
    public class AlgoritimoGenetico
    {
        VeiculoBLL veiculoBLL = new VeiculoBLL();
        ViagemBLL viagemBLL = new ViagemBLL();
        PedidoBLL pedidoBLL = new PedidoBLL();

        public void AvaliarQualidadeIndividuo(Individuo individuo)
        {
            bool boolCapacidade = true;

            foreach (Gene item in individuo.Cromossomos)
            {
                //Verifica se a capacidade do veiculo está correta
                if (!(VerificaCompatibilidadeCapacidade(item.lstPedido, item.Veiculo.capacidade)))
                {
                    boolCapacidade = false;
                }


            }
        }

        private bool VerificaCompatibilidadeCapacidade(List<Pedido> lstPedido, double capacidadeVeiculo)
        {
            double espacoOcupadoPedido = 0;

            foreach (var objeto in lstPedido)
            {
                espacoOcupadoPedido += pedidoBLL.CalculaPesoTotalPedido(objeto.id_pedido);
            }

            if (capacidadeVeiculo < espacoOcupadoPedido)
            {
                return true;
            }

            return false; 
        }

        #region Métodos Poupulação Inicial

        public List<Individuo> CriarPopulacaoInicial()
        {
            List<Veiculo> lstVeiculos = veiculoBLL.ObterTodos().Where(w => w.cd_status == 1).ToList<Veiculo>();
            List<Pedido> lstPedidos = pedidoBLL.ObterTodos().Where(w => w.cd_status == 2).ToList<Pedido>();
            List<Individuo> populacao = new List<Individuo>();
            int tamanhoPopulacao = 0;
            Individuo individuo = null;
            Gene objGene = null;
            Random random = new Random();
            int sorteado = 0;
            int numeroRotas;
            Pedido pedido = null;
            HttpApplicationState session = HttpContext.Current.Application;
            Veiculo veiculo = new Veiculo();

            List<Veiculo> lstVeiculoAux = new List<Veiculo>();
            List<Pedido> lstPedidoAux = new List<Pedido>();

            int compatibilidade = lstPedidos.Count % lstVeiculos.Count;
            int numeroVeiculos = lstVeiculos.Count;

            if (!((compatibilidade == 0) && (lstVeiculos.Count <= lstPedidos.Count)))
            {
                for (int y = 0; y < compatibilidade; y++)
                {
                    pedido = ExcolherPiorPedido(lstPedidos);
                    lstPedidoAux.Add(pedido);
                    lstPedidos.Remove(pedido);
                }

                session.Set("pedidosExcluidos", lstPedidoAux);
            }
            else if (!((compatibilidade == 0) && (lstVeiculos.Count > lstPedidos.Count)))
            {
                compatibilidade = lstVeiculos.Count - lstPedidos.Count;

                for (int w = 0; w < compatibilidade; w++)
                {
                    veiculo = ExcolherPiorCarro(lstVeiculos);
                    lstVeiculos.Remove(veiculo);
                }

            }

            tamanhoPopulacao = (lstVeiculos.Count * 10);

            for (int i = 0; i < tamanhoPopulacao; i++)
            {
                individuo = new Individuo();

                lstPedidoAux.Clear();

                foreach (Pedido item in lstPedidos)
                {
                    lstPedidoAux.Add(item);
                }

                lstVeiculoAux.Clear();

                foreach (Veiculo item in lstVeiculos)
                {
                    lstVeiculoAux.Add(item);
                }

                for (int j = 0; j < numeroVeiculos; j++)
                {
                    objGene = new Gene();

                    sorteado = random.Next(0, (lstVeiculoAux.Count - 1));

                    objGene.Veiculo = lstVeiculoAux[sorteado];
                    lstVeiculoAux.Remove(lstVeiculoAux[sorteado]);

                    numeroRotas = lstPedidos.Count / lstVeiculos.Count;

                    for (int x = 0; x < numeroRotas; x++)
                    {
                        sorteado = random.Next(0, (lstPedidoAux.Count - 1));

                        objGene.lstPedido.Add(lstPedidoAux[sorteado]);
                        lstPedidoAux.Remove(lstPedidoAux[sorteado]);
                    }

                    individuo.Cromossomos.Add(objGene);
                }

                populacao.Add(individuo);
            }

            return populacao;
        }

        private Veiculo ExcolherPiorCarro(List<Veiculo> lstVeiculos)
        {
            Veiculo veiculo = lstVeiculos[0];

            foreach (Veiculo item in lstVeiculos)
            {
                if (item.capacidade < veiculo.capacidade)
                {
                    veiculo = item;
                }
            }

            return veiculo;
        }

        private Pedido ExcolherPiorPedido(List<Pedido> lstPedidos)
        {
            Pedido pedido = null;
            int origem = 15;
            Int64 maiorDistancia = 0;

            IQueryable<Viagem> query = viagemBLL.ObterTodos();

            foreach (Pedido item in lstPedidos)
            {
                Int64 distancia = query.Where(w => (w.cd_partida == origem) && (w.cd_destino == item.cd_cliente)).ToList<Viagem>().First().cd_distancia;

                if (maiorDistancia < distancia)
                {
                    pedido = item;
                    maiorDistancia = distancia;
                }
            }

            return pedido;
        }

        #endregion
    }
}
