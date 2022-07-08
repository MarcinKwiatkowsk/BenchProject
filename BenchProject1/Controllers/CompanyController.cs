using BenchProject1.Data;
using BenchProject1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BenchProject1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository _repository;

        public CompanyController(ICompanyRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
            return Ok(await _repository.GetAll());
        }
        [HttpGet]
        [Route("{code}")]
        public async Task<IActionResult> GetCompany(string code)
        {
           var company = await _repository.Get(code);

            if (company.Equals(null))
            {
                return StatusCode(404, "No companies were found matching the given code");
            }

           return Ok(company);
        }
    }
}
