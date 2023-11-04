using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Aprendizado.Models;
using WebAPI_Aprendizado.Persistence;

namespace WebAPI_Aprendizado.Controllers
{
    [Route("api/dev-events")]
    [ApiController]
    public class DevEventsController : ControllerBase
    {


        private readonly DevEventsDbContext _context;
        //ctor
        public DevEventsController(DevEventsDbContext context)
        {
            _context = context;
        }

        //api/dev-events/    GET
        [HttpGet]
        public IActionResult GetAll()
        {
            //var devEvents = _context.DevEvents;
            var devEvent = _context.DevEvents.Where(d => !d.IsDeleted).ToList();

            if (!devEvent.Any())
                return Ok("Nenhum evento cadastrado no momento.");

            return Ok(devEvent);
        }


        //api/dev-events/123123    GET
        [HttpGet("{id}")]
        public IActionResult GetByID(Guid id)
        {
            var devEvent = _context.DevEvents.SingleOrDefault(d => d.Id == id);

            if (devEvent == null)
            {
                //return NotFound("Nenhum evento encontrado com o ID informado.");
                return NotFound(new { mensagemErro = "Nenhum evento encontrado com o ID informado." });


            }

            return Ok(devEvent);
        }




        //CADASTRO
        //api/dev-events/    POST cadastra um novo
        [HttpPost]
        public IActionResult Post(DevEvent devEvent)
        {
            _context.DevEvents.Add(devEvent);
            return CreatedAtAction(nameof(GetByID), new { id = devEvent.Id }, devEvent);
        }





        //UPDATE
        //api/dev-events/123123123 PUT  Atualiza
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, DevEvent devEventInput)
        {
            var devEvent = _context.DevEvents.SingleOrDefault(d => d.Id == id);

            if (devEvent == null)
            {
                return NotFound();
            }

            //return Ok(devEvents);

            devEvent.Update(devEventInput.Title, devEventInput.Description, devEventInput.StartDate, devEventInput.EndDate);

            return NoContent();

        }



        //UPDATE DO ISDELETE
        //api/dev-events/123123123 PUT  Atualiza somente o IsDeleted
        [HttpPut("updatedeleted/{id}")]
        public IActionResult UpdateDeleted(Guid id)
        {
            var devEvent = _context.DevEvents.SingleOrDefault(d => d.Id == id);

            if (devEvent == null)
            {
                return NotFound(new { mensagemErro = "Nenhum evento encontrado com o ID informado." });
            }


            if (devEvent.IsDeleted)
            {
                //devEvent.IsDeleted = false;
                devEvent.UpdateDeleted(true); //Atualiza apenas o IsDeleted
                //_context.SaveChanges(); // Salve as mudanças no banco de dados
                return Ok(devEvent);

            }
            else
            {
                return BadRequest("Alteração não necessária, pois o Evento já consta como ativado.");
            }

            //return Ok(devEvents);

            //devEvent.Update(devEventInput.Title, devEventInput.Description, devEventInput.StartDate, devEventInput.EndDate);

            //return NoContent();

        }







        //api/dev-events/123123123 DELETE apaga
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var devEvent = _context.DevEvents.SingleOrDefault(d => d.Id == id);

            if (devEvent == null)
            {
                return NotFound();
            }

            //return Ok(devEvents);

            devEvent.Delete();


            return NoContent();

        }



    }




}
