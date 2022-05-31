using System.Collections.Generic;
using de4aber.emilseBilseBingo.Core.Models;

namespace de4aber.emilseBilseBingo.Domain.IRepositories
{
    public interface IPersonRepository
    {
        public List<Person> FindAll();
        Person FindById(int id);
    }
}