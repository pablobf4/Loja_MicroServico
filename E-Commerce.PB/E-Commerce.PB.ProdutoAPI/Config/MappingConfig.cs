using AutoMapper;
using E_Commerce.PB.ProdutoAPI.Data.DTO;
using E_Commerce.PB.ProdutoAPI.Model.Base;


namespace E_Commerce.PB.ProdutoAPI.Config
{
    public class MappingConfig
    {
        public static  MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config=> { 
                config.CreateMap<ProdutoDTO, Produto>();
                config.CreateMap<Produto, ProdutoDTO>();
            });

            return mappingConfig;
        }
    }
}
