using AutoMapper;
using E_Commerce.PB.CarrinhoAPI.Data.DTO;
using E_Commerce.PB.CarrinhoAPI.Model;
using E_Commerce.PB.CarrinhoAPI.Model.Context;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace E_Commerce.PB.CarrinhoAPI.Repository
{
    public class CarrinhoRepository : ICarrinhoRepository
    {
        private readonly Context _context;
        private IMapper _mapper;

        public CarrinhoRepository(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public async Task<bool> ApplyCoupon(string userId, string couponCode)
        {
            var Header = await _context.CarrinhoCabecalhos
                       .FirstOrDefaultAsync(c => c.UserId == userId);
            if (Header != null)
            {
                Header.CuponCode = couponCode;
                _context.CarrinhoCabecalhos.Update(Header);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> ClearCart(string userId)
        {
            var cartHeader = await _context.CarrinhoCabecalhos
                        .FirstOrDefaultAsync(c => c.UserId == userId);
            if (cartHeader != null)
            {
                _context.CarrinhoDetalhes
                    .RemoveRange(
                    _context.CarrinhoDetalhes.Where(c => c.CarrinhoCabecalhoId == cartHeader.Id));
                _context.CarrinhoCabecalhos.Remove(cartHeader);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<CarrinhoDTO> FindCartByUserId(string userId)
        {
            Carrinho cart = new()
            {
                CarrinhoCabecalho = await _context.CarrinhoCabecalhos
                    .FirstOrDefaultAsync(c => c.UserId == userId) == null ? new CarrinhoCabecalho() : await _context.CarrinhoCabecalhos
                    .FirstOrDefaultAsync(c => c.UserId == userId),
            };
            cart.CarrinhoDetalhe = _context.CarrinhoDetalhes
                .Where(c => c.CarrinhoCabecalhoId == cart.CarrinhoCabecalho.Id)
                    .Include(c => c.Produto);


            return _mapper.Map<CarrinhoDTO>(cart);
        }

        public async Task<bool> RemoveCoupon(string userId)
        {
            var Header = await _context.CarrinhoCabecalhos
                      .FirstOrDefaultAsync(c => c.UserId == userId);
            if (Header != null)
            {
                Header.CuponCode = "";
                _context.CarrinhoCabecalhos.Update(Header);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> RemoveFromCart(long cartDetailsId)
        {
            try
            {
                CarrinhoDetalhe carrinhoDetalhe = await _context.CarrinhoDetalhes
                    .FirstOrDefaultAsync(c => c.Id == cartDetailsId);

                int total = _context.CarrinhoDetalhes
                    .Where(c => c.CarrinhoCabecalhoId == carrinhoDetalhe.CarrinhoCabecalhoId).Count();

                _context.CarrinhoDetalhes.Remove(carrinhoDetalhe);

                if (total == 1)
                {
                    var cartHeaderToRemove = await _context.CarrinhoCabecalhos
                        .FirstOrDefaultAsync(c => c.Id == carrinhoDetalhe.CarrinhoCabecalhoId);
                    _context.CarrinhoCabecalhos.Remove(cartHeaderToRemove);
                }
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<CarrinhoDTO> SaveOrUpdateCart(CarrinhoDTO vo)
        {
            Carrinho cart = _mapper.Map<Carrinho>(vo);
            //Checks if the produto is already saved in the database if it does not exist then save
            var produto = await _context.Produtos.FirstOrDefaultAsync(
                p => p.Id == vo.CarrinhoDetalhe.FirstOrDefault().ProdutotId);

            if (produto == null)
            {
                try {
                    _context.Produtos.Add(cart.CarrinhoDetalhe.FirstOrDefault().Produto);
                    await _context.SaveChangesAsync();
                } 
                catch (Exception e) {
                    var mensage = e.Message.ToString();

                }
               
            }

            //Check if CartHeader is null

            var cartHeader = await _context.CarrinhoCabecalhos.AsNoTracking().FirstOrDefaultAsync(
                c => c.UserId == cart.CarrinhoCabecalho.UserId);

            if (cartHeader == null)
            {
                //Create CartHeader and CartDetails
                _context.CarrinhoCabecalhos.Add(cart.CarrinhoCabecalho);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    var teste = e.Message;
                }

                cart.CarrinhoDetalhe.FirstOrDefault().CarrinhoCabecalhoId = cart.CarrinhoCabecalho.Id;
                cart.CarrinhoDetalhe.FirstOrDefault().Produto = null;
                _context.CarrinhoDetalhes.Add(cart.CarrinhoDetalhe.FirstOrDefault());
                await _context.SaveChangesAsync();
            }
            else
            {
                //If CartHeader is not null
                //Check if CartDetails has same produto
                var carrinhoDetalhe = await _context.CarrinhoDetalhes.AsNoTracking().FirstOrDefaultAsync(
                    p => p.ProdutoId == cart.CarrinhoDetalhe.FirstOrDefault().ProdutoId &&
                    p.CarrinhoCabecalhoId == cartHeader.Id);

                if (carrinhoDetalhe == null)
                {
                    //Create CartDetails
                    cart.CarrinhoDetalhe.FirstOrDefault().CarrinhoCabecalhoId = cartHeader.Id;
                    cart.CarrinhoDetalhe.FirstOrDefault().Produto = null;
                    _context.CarrinhoDetalhes.Add(cart.CarrinhoDetalhe.FirstOrDefault());
                    await _context.SaveChangesAsync();
                }
                else
                {
                    //Update produto count and CartDetails
                    cart.CarrinhoDetalhe.FirstOrDefault().Produto = null;
                    cart.CarrinhoDetalhe.FirstOrDefault().Contar += carrinhoDetalhe.Contar;
                    cart.CarrinhoDetalhe.FirstOrDefault().Id = carrinhoDetalhe.Id;
                    cart.CarrinhoDetalhe.FirstOrDefault().CarrinhoCabecalhoId = carrinhoDetalhe.CarrinhoCabecalhoId;
                    _context.CarrinhoDetalhes.Update(cart.CarrinhoDetalhe.FirstOrDefault());
                    await _context.SaveChangesAsync();
                }
            }
            return _mapper.Map<CarrinhoDTO>(cart);
        }
    }
}
