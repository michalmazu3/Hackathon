using Hackathon.Garbage.Dal.Entities;
using Hackathon.Garbage.Dal.Models;

namespace Hackathon.Garbage.Dal.Repositories
{
    public interface IExecutiveRepository
    {
        int CreateOrUpdate(ExecutiveBllModel executive);
        int CreateOrUpdate(ExecutiveBllModel executive, out ExecutiveEntity executiveEntity);
    }
}