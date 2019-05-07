using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace BrayanTechnicalTest.BLL.ConfigAutomapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration ConfifurationAutomapper()
        {
            var config = new MapperConfiguration(cfg => {

                //cfg.CreateMap<DTOVisado, Visado>();
                //cfg.CreateMap<DTOTransactionPSE, TransactionPSE>();
                //cfg.CreateMap<DTODataInnvo, DataInnvo>();
                //cfg.CreateMap<DTODataFacebook, DataFacebook>();
                //cfg.CreateMap<DTOVisadoReg, DTOVisado>();
                //cfg.CreateMap<DTOOpenMillAccount, DTOUser>();
                //cfg.CreateMap<DTORegistroMillenial, RegistroMillenial>();
                //cfg.CreateMap<DTORegistroEmprendedor, RegistroEmprendedor>();
                //cfg.CreateMap<OpenEmpAccount, DTOUser>();
                //cfg.CreateMap<OpenEmpAccount, RegistroEmprendedor>();
                //cfg.CreateMap<DTOInnvoOperation, InnvoOperation>();
                //cfg.CreateMap<DTOPreInnvoOperation, PreInnvoOperation>();
                //cfg.CreateMap<DTOUser, User>();
                //cfg.CreateMap<DTODataBrowser, DataBrowser>();
                //cfg.CreateMap<DTOCreatePayment, CreatePayment>();
                //cfg.CreateMap<DTODataInnvo, DataInnvo>();
                //cfg.CreateMap<DTOv11_ResultadoTransaccion, v11_ResultadoTransaccion>();
                //cfg.CreateMap<DTOParametrosAdicionales, ParametrosAdicionales>();
                //cfg.CreateMap<DTOInnvoValidarPatron, InnvoValidarPatron>();
            });

            return config;
        }
    }
}
