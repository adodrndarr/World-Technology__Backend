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


        public List<Order> GetAll() => _worldtechContext.Orders.ToList();
       
        public Order GetById(int id) => _worldtechContext.Orders.SingleOrDefault(order => order.Id == id);
    
        public void Insert(Order entity) => _worldtechContext.Orders.Add(entity);
        public void Insert(List<Order> entities) => _worldtechContext.Orders.AddRange(entities);


        public void Update(Order entity)
        {
            Order orderToUpdate = GetById(entity.Id);
            
            if (OrderExists(orderToUpdate))
                _worldtechContext.Orders.Update(orderToUpdate);
        }

        public void DeleteById(int id)
        {
            var orderToDelete = GetById(id);

            if (OrderExists(orderToDelete)) 
                _worldtechContext.Orders.Remove(orderToDelete);
        }
        public void DeleteEntities(List<Order> entities) => _worldtechContext.Orders.RemoveRange(entities);


        public bool OrderExists(Order order)
        {
            if (order != null) return true;

            return false;
        }

        public void Save() => _worldtechContext.SaveChanges();
    }
}