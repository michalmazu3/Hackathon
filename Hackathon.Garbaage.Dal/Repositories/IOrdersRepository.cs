using Hackathon.Garbage.Dal.Models;
using System;

namespace Hackathon.Garbage.Dal.Repositories
{
    public interface IOrdersRepository
    {
        int CreateOrUpdate(OrderBllModel order);
        Byte[] GetPhotos(int orderId, int index);
    }
}