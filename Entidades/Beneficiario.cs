using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Beneficiario
    {
        public long Id { get; set; }

        public virtual Cliente Cliente { get; set; }

        public long IdCliente { get; set; }
    }
}
