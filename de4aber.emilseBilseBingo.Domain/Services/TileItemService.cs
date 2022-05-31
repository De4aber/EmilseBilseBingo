using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public TileItem GetById(int id)
        {
            throw new NotImplementedException();
            
        }

        public TileItem Create(TileItem tileItem)
        {
            throw new NotImplementedException();
        }
        
    }
}