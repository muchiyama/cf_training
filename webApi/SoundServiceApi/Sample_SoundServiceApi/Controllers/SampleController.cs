using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample_SoundServiceApi.Models;
using Sample_SoundServiceApi.ViewModel;

namespace Sample_SoundServiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        private readonly SoundServiceApiContext context = new SoundServiceApiContext();
        // GET: api/Sample
        [HttpGet]
        public IEnumerable<ContentViewModel> Get()
        
        {
            return context.MusicInfo.ConvertToViewModel();
        }

        // GET: api/Sample/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Sample
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Sample/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
