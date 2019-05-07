using BrayanTechnicalTest.BLL.Implementation;
using BrayanTechnicalTest.BLL.Interface;
using BrayanTechnicalTest.BLL.Utitlity;
using BrayanTechnicalTest.ENT.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //var r = RestUtitity.CallService("http://quiet-stone-2094.herokuapp.com/transactions.json");
                //var result = RestUtitity.CallService<IList<DTOTransacciones>>("http://quiet-stone-2094.herokuapp.com/transactions.json", string.Empty,
                //                null, "GET", string.Empty, string.Empty
                //                );

                ITransaccionesBll trs = new TransaccionesBll();

                var t = trs.Transacciones();
                //trs.TransaccionesPorSku("");
                var c = trs.Conversiones();

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
