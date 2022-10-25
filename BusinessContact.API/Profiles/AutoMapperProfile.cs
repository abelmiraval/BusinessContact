using AutoMapper;
using BusinessContact.Dto.Response;
using BusinessContact.Entities;
using BusinessLogic.Dto.Request;

namespace BusinessContact.API.Profiles
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile()
        {
            CreateMap<Contact, ContactResponse>()
                .ForMember(dto => dto.Name, ent => ent.MapFrom(x => x.Name))
                .ForMember(dto => dto.Phone, ent => ent.MapFrom(x => x.Phone))
                .ForMember(dto => dto.Business, ent => ent.MapFrom(x => x.Business.Name))
                .ForMember(dto => dto.Date, ent => ent.MapFrom(x => x.CreatedAt.ToString("yyyy-MM-dd HH:mm")));

            CreateMap<ContactRequest, Contact>();

            CreateMap<Contact, ContactRequest>();


        }
    }
}