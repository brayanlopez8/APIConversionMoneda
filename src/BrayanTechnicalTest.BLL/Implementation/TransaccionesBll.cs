using BrayanTechnicalTest.BLL.Utitlity;
using BrayanTechnicalTest.ENT.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using BrayanTechnicalTest.BLL.Interface;

namespace BrayanTechnicalTest.BLL.Implementation
{
    public class TransaccionesBll : ITransaccionesBll
    {
        private string UrlServiceTransaction = ConfigurationManager.AppSettings["ServiceTransactions"];
        private string UrlServiceRates = ConfigurationManager.AppSettings["ServicesRates"];
        private string cachekeyConversiones = "CacheConversiones";
        private string cachekeyTransacciones = "CacheTransacciones";
        private int CacheMinutes = Convert.ToInt32(ConfigurationManager.AppSettings["CacheMinutes"]);
        private int CacheHour = Convert.ToInt32(ConfigurationManager.AppSettings["CacheHour"]);
        private List<DTOConversiones> _dTOConversiones = null; 
        private List<DTOTransacciones> _dTOTransacciones = null;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public TransaccionesBll()
        {
            try
            {

                try
                {
                    this._dTOConversiones = RestUtitity.CallService<List<DTOConversiones>>(UrlServiceRates, string.Empty, null, "GET", string.Empty, string.Empty);
                    CacheManager<List<DTOConversiones>>.TryAddToCache(cachekeyConversiones, _dTOConversiones, CacheHour, CacheMinutes);
                }
                catch (Exception ex)
                {
                    log.Error(ex.ToString());
                    _dTOConversiones = CacheManager<List<DTOConversiones>>.TryGetFromCache(cachekeyConversiones);
                }

                try
                {
                    this._dTOTransacciones = RestUtitity.CallService<List<DTOTransacciones>>(UrlServiceTransaction,
                                    string.Empty, null, "GET", string.Empty, string.Empty);
                    CacheManager<List<DTOTransacciones>>.TryAddToCache(cachekeyTransacciones, _dTOTransacciones, CacheHour, CacheMinutes);
                }
                catch (Exception ex)
                {
                    log.Error(ex.ToString());
                    _dTOTransacciones = CacheManager<List<DTOTransacciones>>.TryGetFromCache(cachekeyTransacciones);
                }
                
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
                throw;
            }
            
        }

        public List<DTOConversiones> Conversiones()
        {
            if (_dTOConversiones != null)
            {
                return _dTOConversiones;
            }
            else
            {
                return null;
            }
        }

        public DTOTransaccionesSum TransaccionesPorSku(string sku)
        {
            if (_dTOConversiones != null)
            {
                return RetornarMonedaPorDefecto(_dTOTransacciones.Where(c => c.sku == sku).ToList(), ConfigurationManager.AppSettings["MondedaPorDefecto"]);
            }
            else
            {
                return null;
            }

        }

        public List<DTOTransacciones> Transacciones()
        {
            if (_dTOConversiones != null)
            {
                return _dTOTransacciones;
            }
            else
            {
                return null;
            }

        }

        private DTOTransaccionesSum RetornarMonedaPorDefecto(List<DTOTransacciones> transacciones, string MonedaPorDefecto)
        {
            DTOTransaccionesSum dTOTransacciones = new DTOTransaccionesSum();
            dTOTransacciones.DTOTransacciones = new List<DTOTransacciones>();

            try
            {
                dTOTransacciones.DTOTransacciones.AddRange(transacciones.Where(c => c.currency == MonedaPorDefecto).ToList());
                transacciones = transacciones.Where(c => c.currency != MonedaPorDefecto).ToList();

                var CurrencyDefecto = _dTOConversiones.Where(c => c.to == MonedaPorDefecto).Select(c => c.from).ToList();
                var ItemConversionDirecta = transacciones.Where(c => CurrencyDefecto.Contains(c.currency)).ToList();
                if (ItemConversionDirecta.Count > 0)
                {
                    foreach (var item2 in ItemConversionDirecta)
                    {
                        double rate = _dTOConversiones.Where(c => c.from == item2.currency && c.to == MonedaPorDefecto).Select(c => c.rate).FirstOrDefault();
                        DTOTransacciones tran = new DTOTransacciones();
                        tran.currency = MonedaPorDefecto;
                        tran.amount = Math.Round(item2.amount * rate,2);
                        tran.sku = item2.sku;
                        dTOTransacciones.DTOTransacciones.Add(tran);
                    }
                }

                var ItemConversionInDirecta = transacciones.Where(c => !CurrencyDefecto.Contains(c.currency)).ToList();

                if (ItemConversionInDirecta.Count > 0)
                {
                    foreach (var item3 in ItemConversionInDirecta)
                    {
                        while (item3.currency != MonedaPorDefecto)
                        {
                            var nuevaConv = _dTOConversiones.Where(c => c.from == item3.currency).ToList();
                            if (nuevaConv.Count > 0)
                            {
                                int ToDefecto = nuevaConv.Where(c => c.to == MonedaPorDefecto).Count();
                                if (ToDefecto > 0)
                                {
                                    var def = nuevaConv.Where(c => c.to == MonedaPorDefecto).FirstOrDefault();
                                    item3.currency = def.to;
                                    item3.amount = Math.Round(item3.amount * def.rate,2);
                                }
                                else
                                {
                                    var predeterminada = nuevaConv[0];
                                    item3.currency = predeterminada.to;
                                    item3.amount = Math.Round(item3.amount * predeterminada.rate,2);
                                }
                            }
                        }
                        dTOTransacciones.DTOTransacciones.Add(item3);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
                throw;
            }


            return dTOTransacciones;
        }

    }
}
