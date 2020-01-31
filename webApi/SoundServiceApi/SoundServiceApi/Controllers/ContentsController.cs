using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoundServiceApi.Service;
using DataAccess.Models;
using SoundServiceApi.ViewModel;
using Common.CF_Logger;
using Common;

namespace SoundServiceApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ContentsController : ControllerBase
    {
        private readonly MusicInfoService service = new MusicInfoService();
        private readonly CF_ILogger logger = CF_LoggerFactory.GetCFLogger();
        // GET: api/ContentsList
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                logger.Info(Const.I001(Const.N002));
                return Ok(service.GetAll());
            }
            catch(Exception ex)
            {
                logger.Error(Const.E001, ex);
                return this.NoContent();
            }
        }

        // GET: api/ContentsList/5
        [HttpGet("{artistName}")]
        public IActionResult Get(string _artist)
        {
            try
            {
                logger.Info(Const.I001(Const.N002));
                return Ok(service.GetByArtist(_artist));
            }
            catch (Exception ex)
            {
                logger.Error(Const.E001, ex);
                return this.NoContent();
            }
        }

        // POST: api/ContentsList
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/ContentsList/5
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
