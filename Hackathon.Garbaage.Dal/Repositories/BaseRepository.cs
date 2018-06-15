using Hackathon.Garbage.Dal.DbContexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hackathon.Garbage.Dal.Repositories
{
    public class BaseRepository
    {
        protected readonly FloraDbContext _floraDbContext;

        protected BaseRepository(FloraDbContext floraDbContext)
        {
            _floraDbContext = floraDbContext;
        }
    }
}
