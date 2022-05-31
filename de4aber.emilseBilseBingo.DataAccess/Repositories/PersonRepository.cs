using System;
using System.Collections.Generic;
using System.Linq;
using de4aber.emilseBilseBingo.Core.Models;
using de4aber.emilseBilseBingo.DataAcess.Entities;
using de4aber.emilseBilseBingo.Domain.IRepositories;

namespace de4aber.emilseBilseBingo.DataAcess.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly MainDbContext _ctx;

        public PersonRepository(MainDbContext ctx)
        {
            _ctx = ctx;
        }

        public List<Person> FindAll()
        {
            return _ctx.Persons.Select(p => p.ToPerson()).ToList();
        }

        public Person FindById(int id)
        {
            var person = _ctx.Persons.First(p => p.Id == id).ToPerson();
            return person;
        }
    }
}