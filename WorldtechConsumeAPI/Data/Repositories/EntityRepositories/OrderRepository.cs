using Domain;
using System.Collections.Generic;
using System.Linq;


namespace Data.Repositories.EntityRepositories
{
    public class OrderRepository : IRepository<Order>
    {
        private WorldtechDbContext _worldtechContext;
        public OrderRepository(WorldtechDbContext worldtechContext)
        {
            this._worldtechContext = worldtechContext;
        }


        public List<Order> GetAll() => this._worldtechContext.Orders.ToList();
       
        public Order GetById(int id) => _worldtechContext.Orders.SingleOrDefault(order => order.Id == id);
    
        public void Insert(Order entity)
        {
            _worldtechContext.Orders.Add(entity);
            _worldtechContext.SaveChanges();
        }        

        public void Update(Order entity)
        {
            Order orderToUpdate = GetById(entity.Id);
            orderToUpdate.FirstName = entity.FirstName;
            orderToUpdate.LastName = entity.LastName;
            orderToUpdate.Email = entity.Email;
            orderToUpdate.Country = entity.Country;
            orderToUpdate.OrderTotal = entity.OrderTotal;

            if (OrderExists(orderToUpdate))
            {
                _worldtechContext.Orders.Update(orderToUpdate);
                _worldtechContext.SaveChanges();
            }
        }
        public void DeleteById(int id)
        {
            var orderToDelete = GetById(id);

            if (OrderExists(orderToDelete)) _worldtechContext.Orders.Remove(orderToDelete);
            _worldtechContext.SaveChanges();
        }
        
        public bool OrderExists(Order order)
        {
            if (order != null) return true;

            return false;
        }
    }
}
