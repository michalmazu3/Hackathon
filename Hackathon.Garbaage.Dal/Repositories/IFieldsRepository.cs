using Hackathon.Garbage.Dal.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackathon.Garbage.Dal.Repositories
{
    public interface IFieldsRepository
    {
         Task<List<FieldEntity>> GetAll();
        int CreateOrUpdate(FieldEntity fieldEntity);
    }
}