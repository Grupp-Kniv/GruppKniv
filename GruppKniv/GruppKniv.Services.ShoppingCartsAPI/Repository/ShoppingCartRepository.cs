using AutoMapper;
using GruppKniv.Services.ShoppingCartsAPI.DataAccess;
using GruppKniv.Services.ShoppingCartsAPI.Models;
using GruppKniv.Services.ShoppingCartsAPI.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace GruppKniv.Services.ShoppingCartsAPI.Repository;

public class ShoppingCartRepository : IShoppingCartRepository
{
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;

    public ShoppingCartRepository(ApplicationDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }


    public async Task<ShoppingCartDto> GetCartByUserIdAsync(string userId)
    {
        ShoppingCart shoppingCart = await _db.ShoppingCarts.Where(e => e.UserId == userId).FirstOrDefaultAsync();
        return _mapper.Map<ShoppingCartDto>(shoppingCart);
    }

    public async Task<ShoppingCartDto> CreateUpdateCartAsync(ShoppingCartDto cartDto)
    {
        ShoppingCart shoppingCart = _mapper.Map<ShoppingCart>(cartDto);

        //check if product exists in Db
        Product productDb = await _db.Products.AsNoTracking()
            .FirstOrDefaultAsync(p => p.ProductId == cartDto.ProductId);
        if (productDb is null)
        {
            _db.Products.Add(shoppingCart.Product);
            await _db.SaveChangesAsync();
        }

        //check if shoppingCart is null
        ShoppingCart shoppingCartDb = await _db.ShoppingCarts.AsNoTracking()
            .FirstOrDefaultAsync(e => e.UserId == shoppingCart.UserId);
        if (shoppingCartDb is null)
        {
            //Create shoppingCart
            _db.ShoppingCarts.Add(shoppingCart);
            await _db.SaveChangesAsync();
        }
        else
        {
            //Update shoppingCart
            ShoppingCart CartDb = await _db.ShoppingCarts.AsNoTracking()
                .FirstOrDefaultAsync(e => e.ProductId == shoppingCart.ProductId);
            shoppingCart.Count += shoppingCartDb.Count;
            _db.ShoppingCarts.Update(shoppingCart);
            await _db.SaveChangesAsync();
        }

        return _mapper.Map<ShoppingCartDto>(shoppingCart);
    }

    //public async Task<bool> RemoveFromCart(int cartId)
    //{
    //    try
    //    {
    //        ShoppingCart cart = await _db.ShoppingCarts.FirstOrDefaultAsync(e => e.ShoppingCartId == cartId);
    //        await _db.SaveChangesAsync();
    //        return true;
    //    }
    //    catch (Exception e)
    //    {
    //        return false;
    //    }
    //}

    //public async Task<bool> ClearCartAsync(string userId)
    //{
    //    ShoppingCart shoppingCart = await _db.ShoppingCarts.FirstOrDefaultAsync(e => e.UserId == userId);
    //    if (shoppingCart is not null)
    //    {
    //        _db.ShoppingCarts.Remove(shoppingCart);
    //        await _db.SaveChangesAsync();
    //        return true;
    //    }
    //    return false;
    //}
}
