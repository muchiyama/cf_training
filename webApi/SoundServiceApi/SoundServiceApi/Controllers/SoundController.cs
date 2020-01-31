using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Common;
using Common.CF_Logger;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoundServiceApi.Service;
using SoundServiceApi.ViewModel;

namespace SoundServiceApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SoundController : ControllerBase
    {
        private readonly SoundService service = new SoundService();
        private readonly CF_ILogger logger = CF_LoggerFactory.GetCFLogger();

        // GET: api/Sound
        [HttpGet]
        public IActionResult Get()
        {
            return this.BadRequest(Const.E003);
        }

        // GET: api/Sound/5
        [HttpGet("{_fileName}")]
        public IActionResult Get(string _fileName)
        {
            try
            {
                logger.Info(Const.I001(Const.N003));
                if (String.IsNullOrEmpty(_fileName))
                    return this.BadRequest(Const.E002);
                if (!service.Exist(_fileName))
                    return this.NoContent();

                logger.Info(Const.I002(Const.N003));
                return Ok(service.GetByFileName(_fileName).content);
            }
            catch(Exception ex)
            {
                logger.Error(Const.F001, ex);
                return this.BadRequest(Const.E003);
            }
        }

        // POST: api/Sound
        [HttpPost]
        public IActionResult Post([FromBody] MusicViewModel value)
        {
            try
            {
                logger.Info(Const.I001(Const.N003));
                if (String.IsNullOrEmpty(value.fileName))
                    return this.BadRequest(Const.E002);
                if (!service.Exist(value.fileName))
                    return this.NoContent();
                logger.Info(Const.I002(Const.N003));
                return Ok(service.GetByFileName(value.fileName));
            }
            catch(Exception ex)
            {
                logger.Error(Const.E001, ex);
                return this.NoContent();
            }
        }

        // PUT: api/Sound/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            return this.BadRequest(Const.E003);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return this.BadRequest(Const.E003);
        }
    }
}
