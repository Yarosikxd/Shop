using AutoMapper;
using Core.Models;
using Infrastructure.Entities;

namespace Infrastructure
{
    public class DataBaseMappings : Profile
    {
        public DataBaseMappings()
        {
            CreateMap<ClientEntity, Client>();
            CreateMap<ProductEntity, Product>();
            CreateMap<PurchaseEntity, Purchase>();
            CreateMap<PurchaseItemEntity, PurchaseItem>();
        }
    }
}
