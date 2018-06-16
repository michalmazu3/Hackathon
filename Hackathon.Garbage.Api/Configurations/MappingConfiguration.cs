using AutoMapper;
using Hackathon.Garbage.Dal.Models;
using Hackathon.Garbage.Dal.Entities;

namespace Hackathon.Garbage.Dal.Configurations
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            CreateMap<CordinatesEntity, CordinatesBllModel>().ReverseMap();
            CreateMap<ExecutiveBllModel, ExecutiveEntity>().ReverseMap();
            CreateMap<FieldBllModel, FieldEntity>().ReverseMap();
            CreateMap<OrderBllModel, OrderEntity>().ReverseMap();
            CreateMap<RatingBllModel, RatingEntity>().ReverseMap();
            CreateMap<AlertBllModel, AlertsEntity>().ReverseMap();
        }
    }
}
