using AutoMapper;
using E_Commerce.PB.CuponAPI.Data.DTO;
using E_Commerce.PB.CuponAPI.Model.Base;

namespace E_Commerce.PB.CuponAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config => {
                config.CreateMap<CuponDTO, Coupon>().ReverseMap();

            });

            return mappingConfig;
        }
    }
}
