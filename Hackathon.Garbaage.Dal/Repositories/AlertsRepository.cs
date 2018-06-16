using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Hackathon.Garbage.Dal.DbContexts;
using Hackathon.Garbage.Dal.Entities;
using Hackathon.Garbage.Dal.Models;

namespace Hackathon.Garbage.Dal.Repositories
{
    public class AlertsRepository : BaseRepository, IAlertsRepository
    {
        private readonly IMapper _mapper;

        public AlertsRepository(FloraDbContext floraDbContext, IMapper mapper) : base(floraDbContext)
        {
            _mapper = mapper;
        }
        public int CreateOrUpdate(AlertBllModel alert)
        {
            if(alert != null)
            {
                var entry = _mapper.Map<AlertsEntity>(alert);
                _floraDbContext.Add(entry);
                return _floraDbContext.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }
    }
}
