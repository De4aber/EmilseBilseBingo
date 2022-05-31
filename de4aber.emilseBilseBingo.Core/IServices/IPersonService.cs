using System.Collections.Generic;
using System.Threading.Tasks;
using de4aber.emilseBilseBingo.Core.Models;

namespace de4aber.emilseBilseBingo.Core.IServices
{
    public interface IPersonService
    {
        public Task<List<Person>> GetAll();

        public Task<Person> FindById(int id);

        public Task<Person> Create(Person person);
    }
}