using Data;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class LogsController : ApiController
    {
        LogsDAL logsDAL = new LogsDAL();

        public HttpResponseMessage Get()
        {
            var regions = logsDAL.GetAllLogs();
            return Request.CreateResponse(HttpStatusCode.OK, regions);
        }

        public HttpResponseMessage Get(int id)
        {
            var log = logsDAL.GetlogperById(id);
            if (log == null || log.LogID == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Kayıt Bulunamadı.");
            }
            return Request.CreateResponse(HttpStatusCode.OK, log);
        }

        public HttpResponseMessage Post(Logs logs)
        {
            var createdLog = logsDAL.Createlogper(logs);
            return Request.CreateResponse(HttpStatusCode.Created, createdLog);
        }

        public HttpResponseMessage Put(int id, Logs logs)
        {
            var log = logsDAL.Updatelogper(id, logs);
            return Request.CreateResponse(HttpStatusCode.OK, log);
        }

        public HttpResponseMessage Delete(int id)
        {
            bool tut = logsDAL.IsAnylogper(id);
            if (tut)
            {
                logsDAL.Deletelogper(id);
                return Request.CreateResponse(HttpStatusCode.OK, tut);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Kayıt Bulunamadı.'" + tut + "'");
        }
    }
}
