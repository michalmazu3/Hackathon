using System;
using System.Collections.Generic;
using System.Text;
using Hackathon.Garbage.Dal.DbContexts;
using Hackathon.Garbage.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.Garbage.Dal.Repositories
{
    public class FieldsRepository : BaseRepository, IFieldsRepository
    {
        public FieldsRepository(
            FloraDbContext floraDbContext
            ) : base(floraDbContext)
        {
        }

        public List<FieldEntity> GetAll()
        {
            var result = _floraDbContext.
                Fields.
                Include(x => x.Cordinates).
                Include(x => x.Orders)
                .ToListAsync().Result;

            return result;
        }
    }
}
