using AutoMapper;
using FA.LegalHCM.Core.Entities;
using FA.LegalHCM.Core.Mapper.ViewModel;

namespace FA.LegalHCM.Core.Mapper
{
    public class MapperProfile
    {
        public class AutoMapperProfile : Profile
        {
            public AutoMapperProfile()
            {
                CreateMap<User, UserModel>().ReverseMap();
            }
        }
    }
}
