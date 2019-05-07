using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrayanTechnicalTest.ENT.DTO
{
    public class DTOTransaccionesSum
    {
        public double Total { get { return Math.Round(DTOTransacciones.Sum(c => c.amount),2); } }
        public List<DTOTransacciones> DTOTransacciones { get; set; }

       
    }
}
