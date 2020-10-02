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


        public List<OrderDetail> GetAll() => _worldtechContext.OrderDetails.ToList();
    
        public OrderDetail GetById(int id) 
            => _worldtechContext.OrderDetails.SingleOrDefault(orderDetail => orderDetail.Id == id);
    
        public void Insert(OrderDetail entity) => _worldtechContext.OrderDetails.Add(entity);
        public void Insert(List<OrderDetail> entities) => _worldtechContext.OrderDetails.AddRange(entities);


        public void Update(OrderDetail entity)
        {
            OrderDetail orderToUpdate = GetById(entity.Id);            

            if (OrderDetailExists(orderToUpdate))
               _worldtechContext.OrderDetails.Update(orderToUpdate);             
        }

        public void DeleteById(int id)
        {
            var orderToDelete = GetById(id);

            if (OrderDetailExists(orderToDelete)) 
                _worldtechContext.OrderDetails.Remove(orderToDelete);            
        }
        public void DeleteEntities(List<OrderDetail> entities) => _worldtechContext.OrderDetails.RemoveRange(entities);


        public void Save() => _worldtechContext.SaveChanges();

        public bool OrderDetailExists(OrderDetail orderDetail)
        {
            if (orderDetail != null) return true;

            return false;
        }
    }
}
