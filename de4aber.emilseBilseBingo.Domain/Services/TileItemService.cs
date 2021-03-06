using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            var list = _tileItemRepository.FindAll().Result;
            foreach (TileItem tileItem in list)
            {
                SetPerson(tileItem);
            }
            return list;
        }
        
        private static Random random = new Random();

        public List<TileItem> GetAll_Random()
        {
            return GetAll().OrderBy(a => random.Next()).ToList();
        }

        public List<TileItem> GetByPersonId(int id)
        {
            var list = _tileItemRepository.FindByPersonId(id).Result;
            foreach (TileItem tileItem in list)
            {
                SetPerson(tileItem);
            }
            return list;
        }

        public List<TileItem> GetByPersonId_Random(int id)
        {
            return GetByPersonId(id).OrderBy(a => random.Next()).ToList();
        }

        public TileItem GetById(int id)
        {
            var ti = _tileItemRepository.FindById(id).Result;
            return SetPerson(ti);

        }

        private TileItem SetPerson(TileItem ti)
        {
            ti.OfPerson = _personRepository.FindById(ti.OfPersonId).Result;
            return ti;
        }

        public TileItem Create(TileItem tileItem)
        {
            return SetPerson(_tileItemRepository.Create(tileItem).Result);
        }
        
    }
}