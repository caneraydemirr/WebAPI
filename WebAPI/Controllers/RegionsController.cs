using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class RegionsController : ApiController
    {
        RegionDAL regionDAL = new RegionDAL();

        public HttpResponseMessage Get()
        {
            var regions= regionDAL.GetAllRegions();
            return Request.CreateResponse(HttpStatusCode.OK, regions);
        }

        public HttpResponseMessage Get(int id)
        {
            var region = regionDAL.GetRegionById(id);
            if (region == null || region.RegionID==0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Kayıt Bulunamadı.");
            }
            return Request.CreateResponse(HttpStatusCode.OK, region);
        }

        public HttpResponseMessage Post(Regions regions)
        {
            var createdRegion = regionDAL.CreateRegion(regions);
            return Request.CreateResponse(HttpStatusCode.Created, createdRegion);
        }

        public HttpResponseMessage Put(int id, Regions regions)
        {
            var region = regionDAL.UpdateRegion(id, regions);
            return Request.CreateResponse(HttpStatusCode.OK, region);
        }

        public HttpResponseMessage Delete(int id)
        {
            bool tut = regionDAL.IsAnyRegion(id);
            if (tut)
            {
                regionDAL.DeleteRegion(id);
                return Request.CreateResponse(HttpStatusCode.OK, tut);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Kayıt Bulunamadı.'" + tut + "'");
        }
    }
}
