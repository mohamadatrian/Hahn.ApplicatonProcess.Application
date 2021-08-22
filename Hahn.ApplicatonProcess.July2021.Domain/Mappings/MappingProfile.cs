using AutoMapper;
using Hahn.ApplicatonProcess.July2021.Domain.Entities;
using Hahn.ApplicatonProcess.July2021.Domain.Features.User.Command.Create;
using Hahn.ApplicatonProcess.July2021.Domain.Features.User.Command.Update;
using Hahn.ApplicatonProcess.July2021.Domain.Models;

namespace Hahn.ApplicatonProcess.July2021.Domain.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, CreateUserCommand>().ReverseMap();
            CreateMap<User, UpdateUserCommand>().ReverseMap();
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<Asset, AssetModel>().ReverseMap();
        }
    }
}
