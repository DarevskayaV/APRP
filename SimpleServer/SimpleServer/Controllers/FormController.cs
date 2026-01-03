using Microsoft.AspNetCore.Mvc;
using SimpleServer.Models;

namespace SimpleServer.Controllers
{
    [ApiController]
    [Route("api/person")]
    public class PersonController : ControllerBase
    {
        [HttpPost]
        public IActionResult SavePerson([FromBody] Person person)
        {
            if (person == null ||
                string.IsNullOrEmpty(person.FirstName) ||
                string.IsNullOrEmpty(person.LastName))
            {
                return BadRequest("Ошибка");
            }

            string data = $"{person.FirstName} {person.LastName}\n";
            System.IO.File.AppendAllText("data.txt", data);

            return Ok("OK");
        }
    }
}
