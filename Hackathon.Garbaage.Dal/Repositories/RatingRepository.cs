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
    public class RatingRepository : BaseRepository, IRatingRepository
    {
        private readonly IMapper _mapper;

        public RatingRepository(FloraDbContext floraDbContext, IMapper mapper) : base(floraDbContext)
        {
            _mapper = mapper;
        }

        public int CreateOrUpdate(RatingBllModel rating)
        {
            if (rating != null)
            {
                var field = _floraDbContext.Fields.FirstOrDefault(x => rating.FieldId == x.Id || rating.Field.Name.Equals(x.Name));
                if(field == null)
                {
                    throw new KeyNotFoundException();
                }
                else
                {
                    rating.FieldId = field.Id;
                    return Create(rating);
                }
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }
        private int Create(RatingBllModel rating)
        {
            return _floraDbContext.SaveChanges();
        }
        private int Update(RatingBllModel rating, RatingEntity entity)
        {
            return _floraDbContext.SaveChanges();
        }
    }
}
