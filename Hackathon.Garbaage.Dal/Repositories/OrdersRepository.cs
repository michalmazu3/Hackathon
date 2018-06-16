using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hackathon.Garbage.Dal.DbContexts;
using Hackathon.Garbage.Dal.Entities;
using Hackathon.Garbage.Dal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
                var field = _floraDbContext.Fields.FirstOrDefault(x => x.Id == order.FieldId);
                var executive = _floraDbContext.Executives.FirstOrDefault(x => x.Id == order.ExecutiveId);

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

        public List<OrderEntity> GetAll()
        {

            try
            {
                return _floraDbContext.Orders
                    .Include(s => s.Executive)
                    .Include(v => v.Field)
                    .Include(v=>v.Field).ThenInclude(f=>f.Cordinates)
                    .ToList();
            }
            catch (Exception e)
            {

                throw;
            }

        } 


    }
}
