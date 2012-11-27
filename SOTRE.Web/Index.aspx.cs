using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SOTRE.Domain.BLL;
using SOTRE.Domain.BE;

namespace SOTRE.Web
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            AlgoritimoGenetico alg = new AlgoritimoGenetico();

            List<Individuo> lst = alg.CriarPopulacaoInicial();

            foreach (Individuo item in lst)
            {
                alg.AvaliarQualidadeIndividuo(item);
            }

            List<Individuo> novaLista = alg.Elitismo(lst);

            foreach (Individuo item in novaLista)
            {
                lst.Remove(item);
            }

            List<Individuo> lstCR = alg.GerenciarCruzamentos(lst, novaLista);

            lstCR = alg.GerenciarMutacao(lstCR);

            foreach (Individuo item in lstCR)
            {
                alg.AvaliarQualidadeIndividuo(item);
            }

            lstCR = lstCR.OrderBy(o => o.nota).ToList<Individuo>();

        }
    }
}