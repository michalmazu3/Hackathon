using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Hackathon.Garbage.Dal.DbContexts;
using Hackathon.Garbage.Dal.Entities;
using Hackathon.Garbage.Dal.Models;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.Garbage.Dal.Repositories
{
    public class FieldsRepository : BaseRepository, IFieldsRepository
    {
        private readonly IMapper _mapper;

        public FieldsRepository(
            FloraDbContext floraDbContext,
            IMapper mapper
            ) : base(floraDbContext)
        {
            _mapper = mapper;
        }

        public int CreateOrUpdate(FieldEntity fieldEntity)
        {
            if (fieldEntity != null)
            {
                try
                {
                    if (fieldEntity.Cordinates != null)
                        _floraDbContext.AddRange(fieldEntity.Cordinates);
                    if (fieldEntity.Orders != null)
                        _floraDbContext.AddRange(fieldEntity.Orders);
                    _floraDbContext.Add(fieldEntity);
                    return _floraDbContext.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            else
                throw new ArgumentNullException();
        }

        public List<FieldBllModel> GetAll()
        {
            try
            {
                var data = _floraDbContext.
                        Fields.
                        Include(x => x.Cordinates).
                        Include(x => x.Orders).
                        ThenInclude(x => x.Executive).
                        Include(x => x.Ratings).
                        ToListAsync().Result;
                /*data = data.Select(x =>
                        {
                            if (x.Cordinates != null)
                                x.Cordinates = x.Cordinates.Select(y => { y.Field = null; return y; }).ToList();
                            if (x.Orders != null)
                                x.Orders = x.Orders.Select(y => { y.Field = null; if (y.Executive != null) y.Executive.Orders = null; return y; }).ToList();
                            if (x.Ratings != null)
                                x.Ratings = x.Ratings.Select(y => { y.Field = null; return y; }).ToList();
                            return x;
                        }).
                        ToList();*/
                
                var result = _mapper.Map<List<FieldBllModel>>(data);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
