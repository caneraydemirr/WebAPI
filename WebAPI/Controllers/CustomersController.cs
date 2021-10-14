using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataLayer;

namespace WebAPI.Controllers
{
    public class CustomersController : ApiController
    {
        CustomerDAL customerDAL = new CustomerDAL();

        public HttpResponseMessage Get()
        {
            var customers = customerDAL.GetAllCustomers();
            return Request.CreateResponse(HttpStatusCode.OK, customers);
        }

        public HttpResponseMessage Get(string id)
        {
            var customers = customerDAL.GetCustomerById(id);
            if (customers == null || customers.CustomerID == null || customers.CustomerID=="")
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Kayıt Bulunamadı.");
            }
            return Request.CreateResponse(HttpStatusCode.OK, customers);
        }

        public HttpResponseMessage Post(Customers customers)
        {
            var createdCustomer = customerDAL.CreateCustomer(customers);
            return Request.CreateResponse(HttpStatusCode.Created, createdCustomer);
        }

        public HttpResponseMessage Put(string id, Customers customers)
        {
            var customer = customerDAL.UpdateCustomer(id, customers);
            return Request.CreateResponse(HttpStatusCode.OK, customer);
        }

        public HttpResponseMessage Delete(string id)
        {
            bool tut = customerDAL.IsAnyCustomer(id);
            if (tut)
            {
                customerDAL.DeleteCustomer(id);
                return Request.CreateResponse(HttpStatusCode.OK, tut);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Kayıt Bulunamadı.'" + tut + "'");
        }
    }
}
