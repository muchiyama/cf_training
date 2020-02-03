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
    public class Sample2Controller : ControllerBase
    {
        private readonly SoundServiceApiContext context = new SoundServiceApiContext();

        // GET: api/Sample2
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Sample2/5
        [HttpGet("{fileName}")]
        public AudioViewModel Get(string fileName)
        {
            // audioファイル
            var audio = System.IO.File.ReadAllBytes($"{context.Parameter.FirstOrDefault().RootDir}/{fileName}");
            // DBのレコード
            var record = context.MusicInfo.Where(w => w.FileName.Equals(fileName));
            // DBのレコードをViewModelに詰めてあげる
            var response = context.MusicInfo.Where(w => w.FileName.Equals(fileName)).FirstOrDefault().ConvertToViewModel(audio);
            return response;
        }

        // POST: api/Sample2
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Sample2/5
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
