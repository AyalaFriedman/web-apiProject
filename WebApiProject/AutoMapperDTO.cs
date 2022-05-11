
using AutoMapper;
using DTO;
using Entities;


namespace WebApiProject
{
    public class AutoMapperDTO : Profile
    {
        public AutoMapperDTO()
        {
           CreateMap<Order, OrderDTO > ().ReverseMap();
           CreateMap<OrderItem, OrderItemDTO>().ReverseMap();
           CreateMap<Product, ProductDTO>().ReverseMap();
           CreateMap<Category, CategoeyDTO>().ReverseMap();
           CreateMap<User, UserDTO>().ReverseMap();
           CreateMap<Rating, RatingDTO>().ReverseMap();
        }


    }
}
