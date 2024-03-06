using AutoMapper;
using E_Commerce.PB.CarrinhoAPI.Data.DTO;
using E_Commerce.PB.CarrinhoAPI.Model;
using GeekShooping.CartAPI.Data.DTO;

namespace E_Commerce.PB.CarrinhoAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config => {
                config.CreateMap<ProdutoDTO, Produto>().ReverseMap();
                config.CreateMap<CarrinhoDetalheDTO, CarrinhoDetalhe>().ReverseMap();
                config.CreateMap<CarrinhoDTO, Carrinho>().ReverseMap();
                config.CreateMap<CarrinhoCabecalhoDTO, CarrinhoCabecalho>().ReverseMap();


            });

            return mappingConfig;
        }
    }
}

