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
        private readonly PersonEntityUtils _personEntityUtils = new();

        public PersonRepository(MainDbContext ctx)
        {
            _ctx = ctx;
        }

        public List<Person> FindAll()
        {
            return _ctx.Persons.Select(p => _personEntityUtils.ToPerson(p)).ToList();
        }
    }
}