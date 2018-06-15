﻿using System;
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

        public List<FieldEntity> GetAll()
        {
            var result = _floraDbContext.
                Fields./*
                Include(x => x.Cordinates).
                Include(x => x.Orders).*/
                ToListAsync().Result;

            return result;
        }
    }
}
