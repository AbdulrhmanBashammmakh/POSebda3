using AutoMapper;
using POSebda3.Dtos;
using POSebda3.Models.ProductModels;
using POSebda3.Models.PurchaseModels;
using POSebda3.Models.SalesModels;

namespace POSebda3.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BillDto, Bill>().ReverseMap();
            CreateMap<Bill_ItemsDto, Bill_Items>().ReverseMap();
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<InvoiceDto, Invoice>().ReverseMap();
            CreateMap<Invoice_ItemsDto, Invoice_Items>().ReverseMap();
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<VendorDto, Vendor>().ReverseMap();
            CreateMap<LineOrderDto, LineOrder>().ReverseMap();
            CreateMap<InventoryDto, Inventory>().ReverseMap();
        }
    }
}