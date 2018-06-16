using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Hackathon.Garbage.Dal.DbContexts;
using Hackathon.Garbage.Dal.Entities;
using Hackathon.Garbage.Dal.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.Garbage.Dal.Repositories
{
    public class OrdersRepository : BaseRepository, IOrdersRepository
    {
        private readonly IExecutiveRepository _executiveRepository;
        private readonly IMapper _mapper;

        public OrdersRepository(
            FloraDbContext floraDbContext,
            IExecutiveRepository executiveRepository,
            IMapper mapper
            ) : base(floraDbContext)
        {
            _executiveRepository = executiveRepository;
            _mapper = mapper;
        }

        public int CreateOrUpdate(OrderBllModel order)
        {
            try
            {
                var field = _floraDbContext.Fields.FirstOrDefault(x => x.Id == order.FieldId || x.Name == order.Field.Name);
                var executive = _floraDbContext.Executives.FirstOrDefault(x => x.Id == order.ExecutiveId || x.Name.Equals(order.Executive.Name));

                if (field == null)
                    throw new KeyNotFoundException();
                if (executive == null)
                    _executiveRepository.CreateOrUpdate(new ExecutiveBllModel { Name = order.Executive.Name },out executive);

                var entity = _mapper.Map<ExecutiveEntity>(order);
                order.FieldId = field.Id;
                order.ExecutiveId = executive.Id;
                _floraDbContext.Add(entity);

                return _floraDbContext.SaveChanges();

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
