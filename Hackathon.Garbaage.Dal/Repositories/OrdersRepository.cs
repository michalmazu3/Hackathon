using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hackathon.Garbage.Dal.DbContexts;
using Hackathon.Garbage.Dal.Entities;
using Hackathon.Garbage.Dal.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.Garbage.Dal.Repositories
{
    public class OrdersRepository : BaseRepository, IOrdersRepository
    {
        private readonly IExecutiveRepository _executiveRepository;

        public OrdersRepository(
            FloraDbContext floraDbContext,
            IExecutiveRepository executiveRepository
            ) : base(floraDbContext)
        {
            _executiveRepository = executiveRepository;
        }

        public int CreateOrUpdate(OrderBllModel order)
        {
            try
            {
                var field = _floraDbContext.Fields.FirstOrDefault(x => x.Name == order.Field.Name);
                var executive = _floraDbContext.Executives.FirstOrDefault(x => x.Name.Equals(order.Executive.Name));

                if (field == null)
                    throw new KeyNotFoundException();
                if (executive == null)
                    _executiveRepository.CreateOrUpdate(new ExecutiveBllModel { Name = order.Executive.Name },out executive);

                return _floraDbContext.SaveChanges();

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
