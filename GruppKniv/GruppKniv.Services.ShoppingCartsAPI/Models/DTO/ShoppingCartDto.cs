﻿namespace GruppKniv.Services.ShoppingCartsAPI.Models.DTO;

public class ShoppingCartDto
{
    public CartHeaderDto CartHeader { get; set; }
    public IEnumerable<CartDetailsDto> CartDetails { get; set; }
}
