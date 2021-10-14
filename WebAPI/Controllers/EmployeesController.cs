using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataLayer;

namespace WebAPI.Controllers
{
    public class EmployeesController : ApiController
    {
        EmployeeDAL employeesDAL = new EmployeeDAL();

        public HttpResponseMessage Get()
        {
            var employee = employeesDAL.GetAllEmployees();
            return Request.CreateResponse(HttpStatusCode.OK, employee);
        }

        public HttpResponseMessage Get(int id)
        {
            var employee = employeesDAL.GetEmployeeById(id);
            if (employee == null || employee.EmployeeID == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Kayıt Bulunamadı.");
            }
            return Request.CreateResponse(HttpStatusCode.OK, employee);
        }

        public HttpResponseMessage Post(Employees employees)
        {
            var createdEmployee = employeesDAL.CreateEmployee(employees);
            return Request.CreateResponse(HttpStatusCode.Created, createdEmployee);
        }

        public HttpResponseMessage Put(int id, Employees employees)
        {
            var employee = employeesDAL.UpdateEmployee(id, employees);
            return Request.CreateResponse(HttpStatusCode.OK, employee);
        }

        public HttpResponseMessage Delete(int id)
        {
            bool tut = employeesDAL.IsAnyEmployee(id);
            if (tut)
            {
                employeesDAL.DeleteEmployee(id);
                return Request.CreateResponse(HttpStatusCode.OK, tut);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Kayıt Bulunamadı.'" + tut + "'");
        }
    }
}
