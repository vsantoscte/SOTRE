using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SOTRE.Domain.BE
{
    public class Individuo
    {
        public List<Gene> Cromossomos { get; set; }

        public Individuo()
        {
            Cromossomos = new List<Gene>();
        }
    }
}
