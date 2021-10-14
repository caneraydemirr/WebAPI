using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class DenemeController : ApiController
    {
        private string[] sehirler = new string[] { "Istanbul", "Bursa", "Ankara" };

        public string[] Get()
        {
            return sehirler;
        }

        public string Get(int id)
        {
            return sehirler[id];
        }
    }
}
