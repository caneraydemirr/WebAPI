using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class ShippersController : ApiController
    {
        ShippersDAL shippersDAL = new ShippersDAL();

        public HttpResponseMessage Get()
        {
            var regions = shippersDAL.GetAllShippers();
            return Request.CreateResponse(HttpStatusCode.OK, regions);
        }

        public HttpResponseMessage Get(int id)
        {
            var shipper = shippersDAL.GetShipperById(id);
            if (shipper == null || shipper.ShipperID == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Kayıt Bulunamadı.");
            }
            return Request.CreateResponse(HttpStatusCode.OK, shipper);
        }

        public HttpResponseMessage Post(Shippers shipper)
        {
            var createdShipper = shippersDAL.CreateShipper(shipper);
            return Request.CreateResponse(HttpStatusCode.Created, createdShipper);
        }

        public HttpResponseMessage Put(int id, Shippers shipper)
        {
            var region = shippersDAL.UpdateShipper(id, shipper);
            return Request.CreateResponse(HttpStatusCode.OK, region);
        }

        public HttpResponseMessage Delete(int id)
        {
            bool tut = shippersDAL.IsAnyShipper(id);
            if (tut)
            {
                shippersDAL.DeleteShipper(id);
                return Request.CreateResponse(HttpStatusCode.OK, tut);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Kayıt Bulunamadı.'" + tut + "'");
        }
    }
}
