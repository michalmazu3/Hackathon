using Hackathon.Garbage.Dal.Models;

namespace Hackathon.Garbage.Dal.Repositories
{
    public interface IOrdersRepository
    {
        int CreateOrUpdate(OrderBllModel order);
    }
}