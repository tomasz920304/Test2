using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using KampaniaAPI.Manager;
using KampaniaProjekt.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace KampaniaProjekt.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KampaniaController : ControllerBase
    {
        public readonly IKampaniaRepository kampaniaRepository;

        public KampaniaController(IKampaniaRepository kampaniaRepository)
        {
            this.kampaniaRepository = kampaniaRepository;
        }

        [HttpGet]
        public ActionResult<List<Kampania>> Get()
        {
            var kampaniaList = kampaniaRepository.List();
            return Ok(kampaniaList);
        }

        [HttpGet("{id}")]
        public ActionResult<Kampania> Get(int id)
        {
            try
            {
                var _kampania = kampaniaRepository.Get(id);
                return Ok(_kampania);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Kampania kampania)
        {
            try
            {
                kampaniaRepository.Create(kampania);
                return Created("Kampania", null);
            }
            catch
            {
                return NotFound();
            }  
        }

        [HttpPut]
        public ActionResult Put([FromBody] Kampania kampania)
        {
            try
            {
                kampaniaRepository.Edit(kampania);
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                kampaniaRepository.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet("koszt")]
        public ActionResult<string> GetKoszt()
        {
            try
            {
                var _koszt = kampaniaRepository.Koszt();
                return Ok(_koszt);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
