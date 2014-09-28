using aerables.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace aerables.Controllers
{
    public class DevicesController : ApiController
    {
        // GET api/<controller>
        public int Get(string name, string key, string field1=null, int? id=null, decimal? lat=null, decimal? lon=null, string field2=null, string field3=null, string field4=null)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            Device dev = db.Device.Where(x => x.Name.Contains(name) || x.APIKey.Contains(key) || (id.HasValue && x.Device_Id == id.Value)).FirstOrDefault();
            if (dev == null)
            {
                dev = new Device();
                dev.Created_at = DateTime.Now;
                dev.Device_Id = id.HasValue ? id.Value : new Random().Next(10000, 99999);
                dev.Field1 = field1;
                dev.Field2 = field2 ?? "";
                dev.Field3 = field3 ?? "";
                dev.Field4 = field4 ?? "";
                dev.Id = Guid.NewGuid();
                dev.Last_entry = "";
                dev.Latitude = lat.HasValue ? lat.Value : 0.0m;
                dev.Longitude = lon.HasValue ? lon.Value : 0.0m;
                dev.Name = name;
                dev.APIKey = key;
                dev.Updated_at = DateTime.Now;
                db.Device.Add(dev);
                db.SaveChanges();
            }
            else
            {

            }

            return -1;
        }

        // GET api/<controller>/5
        public int Get(int id)
        {
            return id;
        }

        // POST api/<controller>
        public int Post([FromBody]string key, int field1, int? field2 = null)
        {
            return -1;
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}
