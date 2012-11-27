using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOTRE.Domain.BE;
using System.Web;
using System.Collections;

namespace SOTRE.Domain.BLL
{
    public class AlgoritimoGenetico
    {
        VeiculoBLL veiculoBLL = new VeiculoBLL();
        ViagemBLL viagemBLL = new ViagemBLL();
        PedidoBLL pedidoBLL = new PedidoBLL();

        #region Mutação

        public List<Individuo> GerenciarMutacao(List<Individuo> populacao)
        {
            Random random = new Random();

            int percent = Convert.ToInt32(populacao.Count * 0.05);

            for (int i = 0; i < percent; i++)
            {
                Mutacao(populacao[random.Next(0, (populacao.Count - 1))]);
            }

            return populacao;

        }

        public void Mutacao(Individuo individuo)
        {
            Random random = new Random();
            int posicaoCromossomoA = random.Next(0,(individuo.Cromossomos.Count - 1));
            int posicaoPedidoA = random.Next(0, (individuo.Cromossomos[posicaoCromossomoA].lstPedido.Count - 1));

            int posicaoCromossomoB = random.Next(0, (individuo.Cromossomos.Count - 1));
            int posicaoPedidoB = random.Next(0, (individuo.Cromossomos[posicaoCromossomoB].lstPedido.Count - 1));

            Pedido a = individuo.Cromossomos[posicaoCromossomoA].lstPedido[posicaoPedidoA];
            Pedido b = individuo.Cromossomos[posicaoCromossomoB].lstPedido[posicaoPedidoB];

            individuo.Cromossomos[posicaoCromossomoA].lstPedido[posicaoPedidoA] = b;
            individuo.Cromossomos[posicaoCromossomoB].lstPedido[posicaoPedidoB] = a;
        }

        #endregion


        #region Cruzamento

        public List<Individuo> GerenciarCruzamentos(List<Individuo> populacao, List<Individuo> novaPopulacao)
        {
            Random random = new Random();
            int tamanhoPopulacao = populacao.Count + novaPopulacao.Count;
            Individuo primeiroEscolhido = null;
            Individuo segundoEscolhido = null;
            List<Individuo> retornoCruzamento = null;


            while (novaPopulacao.Count < tamanhoPopulacao)
            {
                primeiroEscolhido = new Individuo();
                segundoEscolhido = new Individuo();
                retornoCruzamento = new List<Individuo>();

                primeiroEscolhido = populacao[random.Next(0, (populacao.Count - 1))];
                segundoEscolhido = populacao[random.Next(0, (populacao.Count - 1))];

                retornoCruzamento = Cruzamentos(primeiroEscolhido, segundoEscolhido);

                foreach (Individuo objIndividuo in retornoCruzamento)
                {
                    novaPopulacao.Add(objIndividuo);
                }

                populacao.Remove(primeiroEscolhido);
                populacao.Remove(segundoEscolhido);
            }

            return novaPopulacao;
        }

        public List<Individuo> Cruzamentos(Individuo individuo1, Individuo individuo2)
        {
            Individuo primeiroAux = new Individuo();
            Individuo segundoAux = new Individuo();
            List<Individuo> lstRetorno = new List<Individuo>();

            individuo1.Cromossomos = individuo1.Cromossomos.OrderBy(o => o.Veiculo.id_veiculo).ToList<Gene>();
            individuo2.Cromossomos = individuo2.Cromossomos.OrderBy(o => o.Veiculo.id_veiculo).ToList<Gene>();

            int tamanhoPedeço = individuo1.Cromossomos.Count / 2;

            for (int i = 0; i < individuo1.Cromossomos.Count; i++)
            {
                if (i < tamanhoPedeço)
                {
                    primeiroAux.Cromossomos.Add(individuo1.Cromossomos[i]);
                    segundoAux.Cromossomos.Add(individuo2.Cromossomos[i]);
                }
                else
                {
                    segundoAux.Cromossomos.Add(individuo1.Cromossomos[i]);
                    primeiroAux.Cromossomos.Add(individuo2.Cromossomos[i]);
                }
            }

            lstRetorno.Add(primeiroAux);
            lstRetorno.Add(segundoAux);

            return lstRetorno;
        }

        #endregion

        #region Elitismo

        public List<Individuo> Elitismo(List<Individuo> populacao)
        {
            int quantidadeElitismo = (int)(0.1 * populacao.Count);
            int contadorElitismo = 0;
            int contadorLista = 0;

            populacao = populacao.OrderBy(o => o.nota).ToList<Individuo>();

            List<Individuo> novaPopupalacao = new List<Individuo>();

            Individuo individuo = null;

            while (contadorElitismo < quantidadeElitismo)
            {
                if (populacao[contadorLista].nota > 1000)
                {
                    individuo = new Individuo();
                    individuo = populacao[contadorLista];

                    novaPopupalacao.Add(individuo);
                    contadorElitismo++;
                }
                contadorLista++;
            }

            return novaPopupalacao;
        }

        #endregion

        #region Métodos da Avaliação dos Indivíduos

        public void AvaliarQualidadeIndividuo(Individuo individuo)
        {
            bool boolCapacidade = true;
            List<Int64> lstDistanciaPercorrida = new List<Int64>();
            IQueryable<Viagem> queryViagens = viagemBLL.ObterTodos();
            int idOrigem = 15;
            int contLstDistancia = 0;
            IQueryable<Turno> queryTurnos = new TurnoBLL().ObterTodos();
            IQueryable<Turno_Cliente> queryTurnosCliente = new TurnoClienteBLL().ObterTodos();

            foreach (Gene item in individuo.Cromossomos)
            {

                //Verifica se a capacidade do veiculo está correta
                if (!(VerificaCompatibilidadeCapacidade(item.lstPedido, item.Veiculo.capacidade)))
                {
                    boolCapacidade = false;
                }

                lstDistanciaPercorrida.Add(new Int64());

                //Obtem e armazena na lista os valores percorridos pelo carro
                for (int i = 0; i < item.lstPedido.Count; i++)
                {

                    if (i == 0)
                    {
                        lstDistanciaPercorrida[contLstDistancia] += queryViagens.Where(w => (w.cd_partida == idOrigem) && (w.cd_destino == item.lstPedido[i].cd_cliente)).ToList<Viagem>()[0].cd_distancia;
                    }
                    else
                    {
                        lstDistanciaPercorrida[contLstDistancia] += queryViagens.Where(w => (w.cd_partida == item.lstPedido[i - 1].cd_cliente) && (w.cd_destino == item.lstPedido[i].cd_cliente)).ToList<Viagem>()[0].cd_distancia;
                    }
                }

                contLstDistancia++;
            }

            double mediaPercorridaKM = 0;

            for (int i = 0; i < lstDistanciaPercorrida.Count; i++)
            {
                mediaPercorridaKM += lstDistanciaPercorrida[i];
            }

            mediaPercorridaKM = (mediaPercorridaKM / lstDistanciaPercorrida.Count) / 1000;

            if (boolCapacidade)
            {
                individuo.nota = 1000 + mediaPercorridaKM;
            }
            else
            {
                individuo.nota = mediaPercorridaKM;
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

        #endregion

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
