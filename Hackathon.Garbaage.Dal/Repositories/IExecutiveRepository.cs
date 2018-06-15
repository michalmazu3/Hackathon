using Hackathon.Garbage.Dal.Models;

namespace Hackathon.Garbage.Dal.Repositories
{
    public interface IExecutiveRepository
    {
        int CreateOrUpdate(ExecutiveBllModel executive);
    }
}