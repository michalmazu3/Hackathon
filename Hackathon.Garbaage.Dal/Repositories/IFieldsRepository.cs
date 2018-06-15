using Hackathon.Garbage.Dal.Entities;
using Hackathon.Garbage.Dal.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackathon.Garbage.Dal.Repositories
{
    public interface IFieldsRepository
    {
        List<FieldBllModel> GetAll();
        int CreateOrUpdate(FieldEntity fieldEntity);
    }
}