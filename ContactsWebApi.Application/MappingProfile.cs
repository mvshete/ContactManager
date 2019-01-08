using AutoMapper;
using ContactsWebApi.Application.Model;
using ContactsWebApi.Domain.Model;

namespace ContactsWebApi.Application
{
    public class MappingProfile:Profile
    {
        protected void Configure()
        {
            CreateMap<Contact, ContactDto>();
        }
    }
}
