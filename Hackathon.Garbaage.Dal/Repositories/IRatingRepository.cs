using Hackathon.Garbage.Dal.Models;

namespace Hackathon.Garbage.Dal.Repositories
{
    public interface IRatingRepository
    {
        int CreateOrUpdate(RatingBllModel rating);
    }
}