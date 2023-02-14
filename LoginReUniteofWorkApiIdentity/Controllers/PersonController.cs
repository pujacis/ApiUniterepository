using InterfaceEntity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace LoginReUniteofWorkApiIdentity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        public readonly ITaskpersonService _personService;
        public PersonController(ITaskpersonService productService)
        {
            _personService = productService;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetPersonList()
        {
            var personDetailsList = await _personService.GetAllpersons();
            if (personDetailsList == null)
            {
                return NotFound();
            }
            return Ok(personDetailsList);
        }

       
        [HttpGet("{productId}")]
        public async Task<IActionResult> GetPersonById(int personid)
        {
            var persontDetails = await _personService.GetPersonById(personid);

            if (persontDetails != null)
            {
                return Ok(persontDetails);
            }
            else
            {
                return BadRequest();
            }
        }

     
        [HttpPost]
        public async Task<IActionResult> CreatePerson(TaskPerson personDetails)
            {         


            var ispersonCreated = await _personService.CreatePerson(personDetails);

            if (ispersonCreated)
            {
                return Ok(ispersonCreated);
            }
            else
            {
                return BadRequest();
            }
        }

     
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(TaskPerson personDetails)
        {
            if (personDetails != null)
            {
                var ispersonCreated = await _personService.UpdatePerson(personDetails);
                if (ispersonCreated)
                {
                    return Ok(ispersonCreated);
                }
                return BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }

     
        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProduct(int personid)
        {
            var ispersontCreated = await _personService.DeletePerson(personid);

            if (ispersontCreated)
            {
                return Ok(ispersontCreated);
            }
            else
            {
                return BadRequest();
            }
        }
        
    }

}

