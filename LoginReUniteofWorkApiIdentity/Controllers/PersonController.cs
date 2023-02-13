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

            var files = HttpContext.Request.Form.Files;
            string path = Directory.GetCurrentDirectory();


            foreach (var Image in files)
            {
                if (Image != null && Image.Length > 0)
                {
                    var file = Image;
                    // string p = "~/wwwroot/Shared/Uploads/img";
                    // var uploads = System.IO.Path.Combine(p, "Uploads\\img");
                    var uploads = path + "\\wwwroot\\Uploads\\File";


                    if (!Directory.Exists(uploads))
                    {
                        Directory.CreateDirectory(uploads);
                    }


                    if (file.Length > 0)
                    {
                        var supportedTypes = new[] { "jpg", "png", "jpeg", "gif" };
                        var fileExt = System.IO.Path.GetExtension(file.FileName).Substring(1);
                        personDetails.FileName = file.FileName;

                        if (!supportedTypes.Contains(fileExt))
                        {
                            //ErrorMessage = "File Extension Is InValid - Only Upload WORD/PDF/EXCEL/TXT File";
                            //return ErrorMessage;
                        }
                        var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
                        personDetails.FilePath = "\\wwwroot\\Uploads\\File\\" + fileName;
                        using (var fileStream = new System.IO.FileStream(System.IO.Path.Combine(uploads, fileName), FileMode.Create))
                        {
                            //file.ContentType
                            file.CopyToAsync(fileStream);
                            // cm.Logo = fileName;
                            personDetails.UploadFile = System.IO.Path.Combine(uploads, fileName);
                        }


                    }
                }
            }



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
        //[HttpPost]
        //public async Task Post([FromBody] MovieVM[] files)
        //{
        //    foreach (var file in files)
        //    {
        //        var buf = Convert.FromBase64String(file.base64data);
        //        await System.IO.File.WriteAllBytesAsync(env.ContentRootPath + System.IO.Path.DirectorySeparatorChar + Guid.NewGuid().ToString("N") + "-" + file.FileName, buf);
        //    }
        //}




        //image upload in base64 with other parameter
        //[Route("user/PostUserData")]
        //[AllowAnonymous]
        //[HttpPost()]
        //public ReturnObj UploadData(UserData userdata)
        //{
        //    try
        //    {
        //        if (userdata != null)
        //        {
        //            string sPath = "";
        //            var status = InsertUserData(userdata);
        //            sPath = System.Web.Hosting.HostingEnvironment.MapPath("~/image/");
        //            string imagePath = sPath + userdata.PersonId + ".jpeg";
        //            string base64StringData = userdata.Image;
        //            string cleandata = base64StringData.Replace("data:image/png;base64,", "");
        //            byte[] data = System.Convert.FromBase64String(cleandata);
        //            MemoryStream ms = new MemoryStream(data);
        //            System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
        //            if (File.Exists(sPath + Path.GetFileName(userdata.PersonId + ".jpeg")))
        //                status.Message = "Image is already exists";

        //            if (status.Message == "Successfully Added")
        //            {
        //                //save image
        //                img.Save(imagePath, System.Drawing.Imaging.ImageFormat.Jpeg);
        //                return new ReturnObj() { Status = 1, Message = status.Message + " with Recnum Id : " + status.Recnum };
        //            }
        //            else
        //            {
        //                return new ReturnObj() { Status = 0, Message = status.Message };
        //            }

        //        }
        //        else
        //        {
        //            return new ReturnObj() { Status = 0, Message = "Not a valid model" };
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return new ReturnObj() { Status = 0, Message = ex.Message };
        //    }
        //}
        //public System.Drawing.Image Base64StringToImage(string base64String)
        //{
        //    byte[] imageBytes = Convert.FromBase64String(base64String);
        //    var memStream = new MemoryStream(imageBytes, 0, imageBytes.Length);

        //    memStream.Write(imageBytes, 0, imageBytes.Length);
        //    var image = System.Drawing.Image.FromStream(memStream);
        //    return image;
        //}
    }

}

