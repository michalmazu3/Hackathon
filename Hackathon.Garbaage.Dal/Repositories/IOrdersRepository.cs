using Hackathon.Garbage.Dal.Entities;
using Hackathon.Garbage.Dal.Models;
using System.Collections.Generic;

namespace Hackathon.Garbage.Dal.Repositories
{
    public interface IOrdersRepository
    {
        int CreateOrUpdate(OrderBllModel order);
        List<OrderEntity> GetAll();
    }
}