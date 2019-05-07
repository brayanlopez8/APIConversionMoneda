using BrayanTechnicalTest.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrayanTechnicalTest.API.Models
{
    public class registerEnterpreneur
    {
        public registerEnterpreneur()
        {
        }

        public registerEnterpreneur(registerEnterpreneur _callData)
        {
            serviceID               = _callData.serviceID;
            opValidator             = _callData.opValidator;
            PSID                    = _callData.PSID;
            socialNetID             = _callData.socialNetID;
            userToken               = _callData.userToken;
            userPageState           = _callData.userPageState;
            userPageID              = _callData.userPageID;
            userPageToken           = _callData.userPageToken;
            FBAppID                 = _callData.FBAppID;
            FBAppToken              = _callData.FBAppToken;
            userState               = _callData.userState;
            timeStamp_end           = _callData.timeStamp_end;
            transactionID_PWA       = _callData.transactionID_PWA;
            valNombreBolsillo       = _callData.valNombreBolsillo;
            numDepositoApertura     = _callData.numDepositoApertura;
            caracterAceptacion      = _callData.caracterAceptacion;
            codMsgRespuesta         = _callData.codMsgRespuesta;
            numProducto             = _callData.numProducto;
            valTalon                = _callData.valTalon;
            fecApertura             = _callData.fecApertura;
            valHoraApertura         = _callData.valHoraApertura;
            id_DataOperation        = _callData.id_DataOperation;
            id_TipoOperacionOpId    = _callData.id_TipoOperacionOpId;
            id_User                 = _callData.id_User;
            id_Transaction          = _callData.id_Transaction;
            DataBrowser             = _callData.DataBrowser;
            DataInnvo               = _callData.DataInnvo;
            DataOperation           = _callData.DataOperation;
            InnvoValidarPatron      = _callData.InnvoValidarPatron;
            TipoOperacion           = _callData.TipoOperacion;
            Transaction             = _callData.Transaction;
            User                    = _callData.User;
        }

        public string serviceID             { get; set; }

        public string opValidator           { get; set; }

        public int? PSID                    { get; set; }

        public string socialNetID           { get; set; }

        public string userToken             { get; set; }

        public bool? userPageState          { get; set; }

        public int? userPageID              { get; set; }

        public string userPageToken         { get; set; }

        public int? FBAppID                 { get; set; }

        public string FBAppToken            { get; set; }

        public bool? userState              { get; set; }

        public DateTime? timeStamp_end      { get; set; }

        public string transactionID_PWA     { get; set; }

        public string valNombreBolsillo     { get; set; }

        public int? numDepositoApertura     { get; set; }

        public string caracterAceptacion    { get; set; }

        public string codMsgRespuesta       { get; set; }

        public int? numProducto             { get; set; }

        public string valTalon              { get; set; }

        public DateTime? fecApertura        { get; set; }

        public TimeSpan? valHoraApertura    { get; set; }

        public int? id_DataOperation        { get; set; }

        public int? id_TipoOperacionOpId    { get; set; }

        public int? id_User                 { get; set; }

        public int? id_Transaction          { get; set; }

        public ICollection<DataBrowser> DataBrowser                 { get; set; }

        public ICollection<DataInnvo> DataInnvo                     { get; set; }

        public DataOperation DataOperation                          { get; set; }

        public ICollection<InnvoValidarPatron> InnvoValidarPatron   { get; set; }

        public TipoOperacion TipoOperacion                          { get; set; }

        public Transaction Transaction                              { get; set; }

        public User User                                            { get; set; }
    }
}