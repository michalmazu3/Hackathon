using Hackathon.Garbage.Dal.Models;

namespace Hackathon.Garbage.Dal.Repositories
{
    public interface IAlertsRepository
    {
        int CreateOrUpdate(AlertBllModel alert);
    }
}