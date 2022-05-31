using System.Collections.Generic;
using System.Threading.Tasks;
using de4aber.emilseBilseBingo.Core.Models;

namespace de4aber.emilseBilseBingo.Domain.IRepositories
{
    public interface IPersonRepository
    {
        public Task<List<Person>> FindAll();
        Task<Person> FindById(int id);
        Task<Person> Create(Person person);
    }
}