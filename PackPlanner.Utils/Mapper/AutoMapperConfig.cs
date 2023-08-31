using AutoMapper;

namespace PackPlanner.Utils.Mapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Models.Entities.Item, Models.Dtos.Item>()
                .ForMember(dest => dest.Pack, 
                    options => options.MapFrom(source => source.Pack == null ? null : new Models.Dtos.Pack { Id = source.Pack.Id }));
            CreateMap<Models.Dtos.Item, Models.Entities.Item>().ForMember(dest => dest.Id, options => options.Ignore());

            CreateMap<Models.Entities.Pack, Models.Dtos.Pack>();
            CreateMap<Models.Dtos.Pack, Models.Entities.Pack>();//.ForMember(dest => dest.Id, options => options.Ignore());
        }
    }
}
