using BrayanTechnicalTest.BLL.Interface;
using BrayanTechnicalTest.ENT.DTO;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace BrayanTechnicalTest.API.Controllers
{
    /// <summary>
    /// Api para la creacion de arboles binarios y su posterior busqueda de ancestro commun cercano de dos números
    /// </summary>
    public class TransaccionesController : ApiController
    {
        private ITransaccionesBll _transaccionesBll;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public TransaccionesController(ITransaccionesBll transaccionesBll)
        {
            this._transaccionesBll = transaccionesBll;
        }
 

        /// <summary>
        /// Listado de conversiones
        /// </summary>
        /// <returns>Lista de conversiones</returns>
        [HttpGet]
        [Route("api/GetConversiones")]
        public List<DTOConversiones> GetConversiones()
        {
            try
            {
                return _transaccionesBll.Conversiones();
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
                throw;
            }
        }

        /// <summary>
        /// Listado de transacciones
        /// </summary>
        /// <returns>Lista de conversiones</returns>
        [HttpGet]
        [Route("api/GetTransacciones")]
        public List<DTOTransacciones> GetTransacciones()
        {
            try
            {
                return _transaccionesBll.Transacciones();
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
                throw;
            }
        }

        /// <summary>
        /// Listado de transacciones por sku de la moneda por defecto configurada ejemplo EUR
        /// </summary>
        /// <returns>Lista de conversiones</returns>
        [HttpGet]
        [Route("api/GetTransaccionesSku")]
        public DTOTransaccionesSum GetTransaccionesBySKU(string sku)
        {
            try
            {
                return _transaccionesBll.TransaccionesPorSku(sku);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message,ex);
                throw;
            }
        }



    }
}
