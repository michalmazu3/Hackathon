using Hackathon.Garbage.Dal.Entities;
using System.Collections.Generic;

namespace Hackathon.Garbage.Dal.Repositories
{
    public interface IFieldsRepository
    {
        List<FieldEntity> GetAll();
    }
}