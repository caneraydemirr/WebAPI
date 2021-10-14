using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Data;
using Data.Models;

namespace WebAPI.Controllers
{
    public class OrdersController : ApiController
    {
        OrderDAL orderDAL = new OrderDAL();

        public HttpResponseMessage Get()
        {
            var regions = orderDAL.GetAllOrders();
            return Request.CreateResponse(HttpStatusCode.OK, regions);
        }

        public HttpResponseMessage Get(int id)
        {
            var order = orderDAL.GetOrderById(id);
            if (order == null || order.OrderID == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Kayıt Bulunamadı.");
            }
            return Request.CreateResponse(HttpStatusCode.OK, order);
        }

        public HttpResponseMessage Post(Orders orders)
        {
            var createdOrder = orderDAL.CreateOrder(orders);
            return Request.CreateResponse(HttpStatusCode.Created, createdOrder);
        }

        public HttpResponseMessage Put(int id, Orders orders)
        {
            var region = orderDAL.UpdateOrder(id, orders);
            return Request.CreateResponse(HttpStatusCode.OK, region);
        }

        public HttpResponseMessage Delete(int id)
        {
            bool tut = orderDAL.IsAnyOrder(id);
            if (tut)
            {
                orderDAL.DeleteOrder(id);
                return Request.CreateResponse(HttpStatusCode.OK, tut);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Kayıt Bulunamadı.'" + tut + "'");
        }
    }
}
