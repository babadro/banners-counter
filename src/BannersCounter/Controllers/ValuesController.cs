using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

//https://stackoverflow.com/questions/13901048/how-to-lock-an-asp-net-mvc-action
namespace BannersCounter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private static object Lock = new object();

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public string Post([FromBody] int value)
        {
            lock (Lock)
            {
                var bannerInfo = JsonConvert.DeserializeObject<List<Banner>>(System.IO.File.ReadAllText("banners.json"));

                var banner = bannerInfo.FirstOrDefault(b => b.Id == value);

                if (banner != null)
                {
                    banner.DisplayCount++;
                    System.IO.File.WriteAllText("banners.json", JsonConvert.SerializeObject(bannerInfo));
                }
            }
            
            Thread thread = Thread.CurrentThread;
            
            return thread.ManagedThreadId.ToString();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
