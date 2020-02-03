using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Common;
using Common.Attribute;
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
        [DependencyInjection(typeof(SoundService))]
        private readonly SoundService service = new SoundService();
        private readonly CF_ILogger logger = CF_LoggerFactory.GetCFLogger();

        // GET: api/Sound
        [HttpGet]
        public IActionResult Get()
        {
            return this.BadRequest(Const.E003);
        }

        // GET: api/Sound/5
        [HttpGet("{fileName}")]
        public IActionResult Get(string fileName)
        {
            try
            {
                logger.Info(Const.I001(Const.N003));
                if (String.IsNullOrEmpty(fileName))
                    return this.BadRequest(Const.E002);
                if (!service.Exist(fileName))
                    return this.NoContent();
                logger.Info(Const.I002(Const.N003));
                return Ok(service.GetByFileName(fileName));
            }
            catch (Exception ex)
            {
                logger.Error(Const.E001, ex);
                return this.NoContent();
            }
        }

        /// <summary>
        /// audioファイルを返す
        /// Jsonの構成 -> { artist: 'アーティスト', title: 'タイトル', content: 'audioファイルのbase64エンコード' }
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        // POST: api/Sound
        [HttpPost]
        public IActionResult Post([FromBody] AudioViewModel value)
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
