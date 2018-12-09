using DotnetCore.Core.ApplicationServices.InstitutionServce;
using DotnetCore.Core.DTO.DtoInstitute;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DotnetCore.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public IInstituteService _instituteService;

        public ValuesController(IInstituteService instituteService)
        {
            _instituteService = instituteService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var model = new CreateInstituteDto()
            {
                InstitutionName = "Chetu India Pvt Ltd",
                Address = "Kotla Muburakpur, Aliganj",
                City = "Delhi",
                StateId = 1,
                CountryId = 1,
                ZipCode = "110003",
                IsActive = true
            };
            var result = _instituteService.Create(model);
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            var getInstitute = _instituteService.ListAll();
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
