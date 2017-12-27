using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ModelLibrary;

namespace REST_PrivateProject
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        #region GET U.DB
        [OperationContract] //betyder at en metode definere operation/funktion. Kun metoder med en operationcontract vises i client
        [WebInvoke(
            Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "catches")
            ]
        List<Catch> GetCatches();
        #endregion

        #region GET BY ID U.DB
        [OperationContract]
        [WebInvoke(
                Method = "GET",
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "catch/{id}")
        ]
        Catch GetOneCatch(String id);
        #endregion

        #region POST U.DB
        [OperationContract]
        [WebInvoke(
                Method = "POST",
                RequestFormat = WebMessageFormat.Json,
                //ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "catches")
        ]
        void AddCatch(Catch newCatch);
        #endregion

        #region DELETE U.DB
        [OperationContract]
        [WebInvoke(
                Method = "DELETE",
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "catches?id={id}")
        ]
        Catch DeleteCatch(int id);
        #endregion

        #region PUT U.DB
        [OperationContract]
        [WebInvoke(
                Method = "PUT",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "catches")
        ]
        Catch UpdateCatch(Catch myCatch);
        #endregion

        #region GET DB
        [OperationContract]
        [WebInvoke(
                Method = "GET",
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "catches")
        ]
        List<Catchings> GetCatchesDB();
        #endregion

        #region GET V2 DB
        [OperationContract]
        [WebInvoke(
                Method = "GET",
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "catches2")
        ]
        List<Catchings> GetCatchesv2DB();
        #endregion

        #region GET BY ID DB
        [WebInvoke(
                Method = "GET",
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "catch/{id}")
        ]
        Catchings GetOneCatchDB(String id);
        #endregion 
    }


}
