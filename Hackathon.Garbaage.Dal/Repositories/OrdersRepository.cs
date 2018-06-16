using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
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
        private readonly IMapper _mapper;
        private readonly IPhotosRepository _photosRepository;

        public OrdersRepository(
            FloraDbContext floraDbContext,
            IExecutiveRepository executiveRepository,
            IMapper mapper,
            IPhotosRepository photosRepository
            ) : base(floraDbContext)
        {
            _executiveRepository = executiveRepository;
            _mapper = mapper;
            _photosRepository = photosRepository;
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

        public List<OrderEntity> GetAll()
        {

            try
            {
                return _floraDbContext.Orders
                    .Include(s => s.Executive)
                    .Include(v => v.Field)
                    .Include(b=>b.Field).ThenInclude(f=>f.Ratings)
                    .Include(v=>v.Field).ThenInclude(f=>f.Cordinates)
                    .ToList();
            }
            catch (Exception e)
            {

                throw;
            }

        } 
        public Byte[] GetPhotos(int orderId, int index)
        {
            var res =_photosRepository.GetByOrder(orderId);
            var photoPath = res.Skip(index).Take(1).FirstOrDefault();

            Byte[] b = System.IO.File.ReadAllBytes(photoPath);
            return b;
        }



    }
}
