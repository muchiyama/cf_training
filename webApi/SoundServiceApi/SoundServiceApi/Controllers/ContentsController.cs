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
using Common.Attribute;

namespace SoundServiceApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ContentsController : ControllerBase
    {
        private readonly SoundServiceApiContext _context;
        private readonly MusicInfoService _service;
        private readonly CF_ILogger logger = CF_LoggerFactory.GetCFLogger();

        public ContentsController(SoundServiceApiContext context, MusicInfoService service)
        {
            _context = context;
            _service = service;
        }


        // GET: api/ContentsList
        /// <summary>
        /// サーバー上のコンテンツ一覧を返す
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                logger.Info(Const.I001(Const.N002));
                return Ok(_service.GetAll());
            }
            catch(Exception ex)
            {
                logger.Error(Const.E001, ex);
                return this.NoContent();
            }
        }

        // GET: api/ContentsList/5
        /// <summary>
        /// アーティスト名での検索
        /// </summary>
        /// <param name="_artist"></param>
        /// <returns></returns>
        [HttpGet("{artistName}")]
        public IActionResult Get(string artistName)
        {
            try
            {
                logger.Info(Const.I001(Const.N002));
                return Ok(_service.GetByArtist(artistName));
            }
            catch (Exception ex)
            {
                logger.Error(Const.E001, ex);
                return this.NoContent();
            }
        }

        // POST: api/ContentsList
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            return this.BadRequest(Const.E003);
        }

        // PUT: api/ContentsList/5
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
