using System.Collections.Generic;
using System.Threading.Tasks;
using de4aber.emilseBilseBingo.Core.Models;

namespace de4aber.emilseBilseBingo.Domain.IRepositories
{
    public interface IPersonThemeRepository
    {
        public Task<List<PersonTheme>> FindAll();
        Task<PersonTheme> FindById(int id);
        
        Task<PersonTheme?> FindByPersonId(int id);
        Task<PersonTheme> Create(PersonTheme person);
    }
}