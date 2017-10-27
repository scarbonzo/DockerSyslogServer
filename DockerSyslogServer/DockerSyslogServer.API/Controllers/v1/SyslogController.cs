using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DockerSyslogServer.API.Controllers.v1
{
    public class SyslogController : Controller
    {
        string Server = "mongodb://192.168.50.225";
        string Database = "cisco_vg";

        [HttpGet]
        [Route("api/v1/sources")]
        public ActionResult Sources()
        {
            List<string> Collections = new List<string>();

            try
            {
                var client = new MongoClient(Server);
                var db = client.GetDatabase(Database);

                foreach (BsonDocument collection in db.ListCollectionsAsync().Result.ToListAsync<BsonDocument>().Result)
                {
                    string name = collection["name"].AsString;
                    Collections.Add(name);
                }
            }
            catch
            {
                return Unauthorized();
            }

            return Ok(Collections);
        }

        [HttpGet]
        [Route("api/v1/syslogs")]
        public ActionResult Syslogs (string source, DateTime? start, DateTime? end, int resultsize = 50)
        {
            if (start == null)
                start = DateTime.Now.Date;

            if (end == null)
                end = DateTime.Now.Date.AddHours(23).AddMinutes(59).AddSeconds(59);

            List<syslog> results = new List<syslog>();

            try
            {
                var collection = new MongoClient(Server).GetDatabase(Database).GetCollection<syslog>(source);

                results = collection.AsQueryable<syslog>()
                    .Where(d => d.Timestamp > start)
                    .Where(d => d.Timestamp < end)
                    .Take(resultsize)
                    .ToList();

            }
            catch { }

            return Ok(results);
        }
    }

    class syslog
    {
        public MongoDB.Bson.ObjectId _id { get; set; }
        public DateTime Timestamp { get; set; }
        public string Data { get; set; }
    }
}
