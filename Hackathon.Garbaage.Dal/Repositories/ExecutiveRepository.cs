using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Hackathon.Garbage.Dal.DbContexts;
using Hackathon.Garbage.Dal.Entities;
using Hackathon.Garbage.Dal.Models;

namespace Hackathon.Garbage.Dal.Repositories
{
    public class ExecutiveRepository : BaseRepository, IExecutiveRepository
    {
        private readonly IMapper _mapper;

        public ExecutiveRepository(
            FloraDbContext floraDbContext,
            IMapper mapper
            ) : base(floraDbContext)
        {
            _mapper = mapper;
        }
        public int CreateOrUpdate(ExecutiveBllModel executive, out ExecutiveEntity executiveEntity)
        {
            executiveEntity = _floraDbContext.Executives.
                FirstOrDefault(x => x.Name.Equals(executive.Name) || x.Id == executive.Id);
            if (executiveEntity != null)
            {
                if (executive.Id == executiveEntity.Id)
                {
                    if (executive.Name.Equals(executiveEntity.Name))
                        return 0;
                    else
                    {
                        executiveEntity.Name = executive.Name;
                        _floraDbContext.Update(executiveEntity);
                        return _floraDbContext.SaveChanges();
                    }
                }
                else
                {
                    if (executive.Name.Equals(executiveEntity.Name))
                        return 0;
                    else
                    {
                        return Add(executive, out executiveEntity);
                    }
                }
            }
            else
            {
                return Add(executive, out executiveEntity);
            }
        }
        public int CreateOrUpdate(ExecutiveBllModel executive)
        {
            ExecutiveEntity tmp;
            return CreateOrUpdate(executive, out tmp);
        }
        private int Add(ExecutiveBllModel executive, out ExecutiveEntity res)
        {
            var entry = new ExecutiveEntity { Name = executive.Name };
            var result = _floraDbContext.Add(entry);
            var state = _floraDbContext.SaveChanges();
            res = result.Entity;
            return state;
        }

    }
}
