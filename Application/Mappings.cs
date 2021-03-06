using Application.Helpers;
using Contract.DTOs;

using DomainCountry = Domain.Models.Country;
using DomainData = Domain.Models.Data;
using DomainPlayer = Domain.Models.Player;

namespace Application
{
    public class Mappings : AutoMapper.Profile
    {
        public Mappings()
        {
            CreateMap<DomainPlayer, Player>().ForMember(des => des.Sex, option => option.MapFrom(sources => sources.Sex.GetDescription()));
            CreateMap<Player, DomainPlayer>();
            CreateMap<DomainCountry, Country>().ReverseMap();
            CreateMap<DomainData, Data>().ReverseMap();
        }
    }
}