using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpeedLord.Interfaces.Repositories;
using SpeedLord.Dto;

namespace SpeedLord.Repositories.Fake
{
    public class FakeRealmRepository : IRealmRepository
    {
        private readonly IEnumerable<Realm> _allRealms;

        public FakeRealmRepository()
        {
            _allRealms = new List<Realm>
                             {
                                 new Realm {Name = "Dev Realm", Id = 1}
                             };
        }

        public Dto.Realm GetRealmById(int id)
        {
            if(_allRealms.All(r=> r.Id != id))
                throw new ArgumentException(string.Format("Id {0} not found", id));

            return _allRealms.First(r => r.Id == id);
        }

        public IEnumerable<Dto.Realm> GetAllRealms()
        {
            return _allRealms;
        }
    }
}
