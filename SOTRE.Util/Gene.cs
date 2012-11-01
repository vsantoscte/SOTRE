using System;
using SOTRE.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SOTRE.Util
{
    public class Gene
    {
        public int Id_veiculo { get; set; }
        public List<Viagem> dsdViagenss { get; set; }
    }
}
