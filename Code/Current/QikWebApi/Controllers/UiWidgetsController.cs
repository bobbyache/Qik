using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Qik.UiWidgets;

namespace QikWebApi.Controllers
{
    [ApiController]
    [Route("api/ui-widgets")]
    public class UiWidgetsController : ControllerBase
    {
        // [HttpGet]
        // public async Task GetScriptWidgets([FromBody] string script)

        [HttpPost("add-photo")]
        // public async Task<ActionResult<List<UiWidget>>> GetScriptWidgets(IFormFile file)
        public async Task<UiWidget[]> GetScriptWidgets(IFormFile file)
        {
            using var reader = new StreamReader(file.OpenReadStream());

            var scriptText = await reader.ReadToEndAsync();

            Qik.UiWidgets.UiWidgetFactory factory = new UiWidgetFactory();
            var widgets = factory.BuildFromScript(scriptText);

            return widgets;

            // Console.WriteLine(file.Name);
            // var user = await userRepository.GetUserByUsernameAsync(User.GetUsername());
            // if (user == null) return NotFound();

            // var result = await photoService.AddPhotoAsync(file);

            // if (result.Error != null) return BadRequest(result.Error.Message);

            // var photo = new Photo
            // {
            //     Url = result.SecureUrl.AbsoluteUri,
            //     PublicId = result.PublicId,
            //     // Is this the first photo? If so, set it to the main photo.
            //     IsMain = user.Photos.Count == 0 ? true : false
            // };

            // user.Photos.Add(photo);

            // //
            // // Create a 201 Created response with some information as to where to find the resource (HATEOS).
            // // ... and we send back the newly created resource url in the Location header.
            // if (await userRepository.SaveAllAsync())
            // {
            //     return CreatedAtAction(nameof(GetUser), new { username = user.Username }, mapper.Map<PhotoDto>(photo));
            // }

            // return BadRequest("Problem adding photo");
        }
    }
}