using AutoMapper;
using teste_comadre.Models;
using teste_comadre.ViewModels;

namespace teste_comadre.Mappers
{
    public class Mapping : Profile
    { 
        public Mapping()
        {
            CreateMap<AccountPostViewModel, Account>();
            CreateMap<TransactionPostViewModel, Transaction>();
        }
    }
}