using BrayanTechnicalTest.ENT.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrayanTechnicalTest.BLL.Interface
{
    public interface ITransaccionesBll
    {
        List<DTOTransacciones> Transacciones();

        List<DTOConversiones> Conversiones();

        DTOTransaccionesSum TransaccionesPorSku(string sku);

    }
}
