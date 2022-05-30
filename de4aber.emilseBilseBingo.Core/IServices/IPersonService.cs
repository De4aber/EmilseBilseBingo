using System.Collections.Generic;
using de4aber.emilseBilseBingo.Core.Models;

namespace de4aber.emilseBilseBingo.Core.IServices
{
    public interface IPersonService
    {
        public List<Person> GetAll();
    }
}