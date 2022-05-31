using System.Collections.Generic;
using System.Threading.Tasks;
using de4aber.emilseBilseBingo.Core.Models;

namespace de4aber.emilseBilseBingo.Domain.IRepositories
{
    public interface IPersonRepository
    {
        public Task<List<Person>> FindAll();
        Person FindById(int id);
        Person Create(Person person);
    }
}