using InterfaceEntity.Models;
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

        /// <summary>
        /// Get the list of product
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetProductList()
        {
            var personDetailsList = await _personService.GetAllpersons();
            if (personDetailsList == null)
            {
                return NotFound();
            }
            return Ok(personDetailsList);
        }

        /// <summary>
        /// Get product by id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProductById(int personid)
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

        /// <summary>
        /// Add a new product
        /// </summary>
        /// <param name="productDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateProduct(TaskPerson personDetails)
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

        /// <summary>
        /// Update the product
        /// </summary>
        /// <param name="productDetails"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Delete product by id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
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
        //[HttpPost("AddImage")]
        //public async Task Post([FromBody] MovieVM[] files)
        //{
        //    foreach (var file in files)
        //    {
        //        var buf = Convert.FromBase64String(file.base64data);
        //        await System.IO.File.WriteAllBytesAsync(env.ContentRootPath + System.IO.Path.DirectorySeparatorChar + Guid.NewGuid().ToString("N") + "-" + file.FileName, buf);
        //    }
        //}
    }

}

