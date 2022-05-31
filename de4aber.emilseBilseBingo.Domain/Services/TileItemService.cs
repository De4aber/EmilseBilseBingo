using System;
using System.Collections.Generic;
using System.Linq;
using de4aber.emilseBilseBingo.Core.IServices;
using de4aber.emilseBilseBingo.Core.Models;
using de4aber.emilseBilseBingo.Domain.IRepositories;

namespace de4aber.emilseBilseBingo.Domain.Services
{
    public class TileItemService : ITileItemService
    {

        private readonly ITileItemRepository _tileItemRepository;
        private readonly IPersonRepository _personRepository;

        public TileItemService(ITileItemRepository tileItemRepository, IPersonRepository personRepository)
        {
            _tileItemRepository = tileItemRepository;
            _personRepository = personRepository;
        }

        public List<TileItem> GetAll()
        {
            var tileItems =  _tileItemRepository.FindAll();
            
            foreach (TileItem ti in tileItems)
            {
                Console.WriteLine("Of person with Id = " + ti.OfPersonId);
                ti.OfPerson = _personRepository.FindById(ti.OfPersonId);
            }
            

            return tileItems;
        }

        public TileItem Create(TileItem tileItem)
        {
            return _tileItemRepository.Create(tileItem);
        }
    }
}