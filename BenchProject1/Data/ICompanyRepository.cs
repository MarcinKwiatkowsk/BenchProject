using BenchProject1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BenchProject1.Data
{
    public interface ICompanyRepository
    {
        public Task<Company> Get(string code);
        public Task<List<Company>> GetAll();
    }
}
