using Microsoft.AspNetCore.Mvc;
using PersonManagementApp.Business.Dto;
using PersonManagementApp.Business.Interfaces;

namespace PersonManagementApp.API.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPeople()
        {
            var people = await _personService.GetAllPeopleAllRoleAsync();
            Thread.Sleep(2000);
            return Ok(people);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePerson([FromBody] PersonCreateModel personCreateModel)
        {
            if (await _personService.CreatePerson(personCreateModel))
            {
                return Ok("Created new person successfully!");
            }

            return BadRequest();
        }
    }
}
