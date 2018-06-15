using System;
using System.Collections.Generic;
using System.Text;
using Hackathon.Garbage.Dal.DbContexts;
using Hackathon.Garbage.Dal.Entities;
using Hackathon.Garbage.Dal.Models;

namespace Hackathon.Garbage.Dal.Repositories
{
    public class ExecutiveRepository : BaseRepository, IExecutiveRepository
    {
        public  ExecutiveRepository(FloraDbContext floraDbContext) : base(floraDbContext)
        {
        }
        public int CreateOrUpdate(ExecutiveBllModel executive)
        {
            return -1;
        }
    }
}
