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
                if (fieldEntity.Cordinates != null)
                    _floraDbContext.AddRange(fieldEntity.Cordinates);
                if (fieldEntity.Orders != null)
                    _floraDbContext.AddRange(fieldEntity.Orders);
                _floraDbContext.Add(fieldEntity);
                return _floraDbContext.SaveChanges();
            }
            else
                throw new ArgumentNullException();
        }

        public List<FieldBllModel> GetAll()
        {
            var data = _floraDbContext.
                Fields.
                //Include(x => x.Cordinates).
                //Include(x => x.Orders).
                ToListAsync().Result;
            var fieldIds = data.Select(x => x.Id).Distinct().ToList();
            var cordninates = _floraDbContext.Set<CordinatesEntity>().
                Where(x => fieldIds.Contains(x.FieldId)).
                ToList();
            var orders = _floraDbContext.Orders.
                Where(x => fieldIds.Contains(x.FieldId)).
                ToList();
            foreach(var entry in fieldIds)
            {
                var field = data.FirstOrDefault(x => x.Id == entry);
                if(field != null)
                {
                    var cords = cordninates.Where(x => x.FieldId == entry).Select(x => { x.Field = null; return x; }).ToList();
                    var os = orders.Where(x => x.FieldId == entry).ToList();
                    if (cords != null)
                        field.Cordinates.AddRange(cords);
                    if (os != null)
                        field.Orders.AddRange(os);
                }
            }
            
            var result = _mapper.Map<List<FieldBllModel>>(data);
            return result;
        }
    }
}
