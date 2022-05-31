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
                SetPerson(ti);
            }
            

            return tileItems;
        }

        public TileItem GetById(int id)
        {
            return SetPerson(_tileItemRepository.FindById(id));
            
        }

        public TileItem Create(TileItem tileItem)
        {
            return SetPerson(_tileItemRepository.Create(tileItem));
        }

        private TileItem SetPerson(TileItem tileItem)
        {
            tileItem.OfPerson = _personRepository.FindById(tileItem.OfPersonId);
            return tileItem;
        }
    }
}