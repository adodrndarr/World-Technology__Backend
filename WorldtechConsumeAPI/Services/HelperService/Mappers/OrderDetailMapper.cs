using Domain;


namespace Services
{
    public static class OrderDetailMapper
    {        
        public static OrderDetail ToOrderDetail(Order order, ShoppingCartItem cartItem)
        {
            return new OrderDetail()
            {
                Amount = cartItem.Amount,
                ProductId = cartItem.Product.Id,
                OrderId = order.Id,
                Price = cartItem.Product.Price,
                Product = cartItem.Product
            };            
        }        
    }
}