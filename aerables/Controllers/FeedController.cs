using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using aerables.Models;

namespace aerables.Controllers
{
    public class FeedController : ApiController
    {
        // GET api/<controller>
        public int Get(string key, int field1, int? field2 = null, int? field3 = null, int? field4 = null)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            ErrorLog error = new ErrorLog();
            error.Id = Guid.NewGuid();
            error.Message = key + " " + field1;
            error.Created_at = DateTime.Now;
            error.CallStack = "GET";
            db.ErrorLog.Add(error);
            db.SaveChanges();


            var dev = db.Device.Where(x => x.APIKey == key).FirstOrDefault();
            if(dev != null)
            {
                Feed f = new Feed();
                f.Id = Guid.NewGuid();
                f.Created_at = DateTime.Now;
                f.Entry_Id = db.Device.Where(x => x.APIKey == key).FirstOrDefault().Measurements.Max(x => x.Entry_Id) + 1;
                f.MeasurementField1 = field1;
                f.MeasurementField2 = field2 ?? 0;
                f.MeasurementField3 = field3 ?? 0;
                f.MeasurementField4 = field4 ?? 0;
                dev.Measurements.Add(f);
                db.SaveChanges();
                return f.Entry_Id;
            }
            else
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
            ApplicationDbContext db = new ApplicationDbContext();

            ErrorLog error = new ErrorLog();
            error.Id = Guid.NewGuid();
            error.Message = key + " " + field1;
            error.Created_at = DateTime.Now;
            error.CallStack = "POST";
            db.ErrorLog.Add(error);
            db.SaveChanges();

            var dev = db.Device.Where(x => x.APIKey == key).FirstOrDefault();
            if (dev != null)
            {
                Feed f = new Feed();
                f.Created_at = DateTime.Now;
                f.Entry_Id = db.Device.Where(x => x.APIKey == key).FirstOrDefault().Measurements.Max(x => x.Entry_Id) + 1;
                f.MeasurementField1 = field1;
                f.MeasurementField2 = field2 ?? 0;
                dev.Measurements.Add(f);
                db.SaveChanges();
                return f.Entry_Id;
            }
            else
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