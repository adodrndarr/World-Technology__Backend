using Domain;
using System.Collections.Generic;
using System.Linq;


namespace Data.Repositories.EntityRepositories
{
    public class OrderDetailsRepository : IRepository<OrderDetail>
    {
        private WorldtechDbContext _worldtechContext;
        public OrderDetailsRepository(WorldtechDbContext worldtechContext)
        {
            this._worldtechContext = worldtechContext;
        }


        public List<OrderDetail> GetAll() => this._worldtechContext.OrderDetails.ToList();
    
        public OrderDetail GetById(int id) 
            => _worldtechContext.OrderDetails.SingleOrDefault(orderDetail => orderDetail.Id == id);
    
        public void Insert(OrderDetail entity)
        {
            _worldtechContext.OrderDetails.Add(entity);
            _worldtechContext.SaveChanges();
        }

        public void Update(OrderDetail entity)
        {
            OrderDetail orderToUpdate = GetById(entity.Id);
            orderToUpdate.Order = entity.Order;
            orderToUpdate.Amount = entity.Amount;
            orderToUpdate.Price = entity.Price;
            orderToUpdate.Product = entity.Product;

            if (OrderDetailExists(orderToUpdate))
            {
                _worldtechContext.OrderDetails.Update(orderToUpdate);
                _worldtechContext.SaveChanges();
            }
        }
        public void DeleteById(int id)
        {
            var orderToDelete = GetById(id);

            if (OrderDetailExists(orderToDelete)) _worldtechContext.OrderDetails.Remove(orderToDelete);
            _worldtechContext.SaveChanges();
        }

        public bool OrderDetailExists(OrderDetail orderDetail)
        {
            if (orderDetail != null) return true;

            return false;
        }
    }
}
