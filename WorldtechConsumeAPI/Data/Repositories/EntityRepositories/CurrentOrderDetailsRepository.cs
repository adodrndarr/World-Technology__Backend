using Domain;
using System.Collections.Generic;
using System.Linq;


namespace Data.Repositories.EntityRepositories
{
    public class CurrentOrderDetailsRepository : IRepository<CurrentOrderDetail>
    {
        private WorldtechDbContext _worldtechContext;
        public CurrentOrderDetailsRepository(WorldtechDbContext worldtechContext)
        {
            this._worldtechContext = worldtechContext;
        }
                

        public List<CurrentOrderDetail> GetAll() => this._worldtechContext.CurrentOrderDetails.ToList();
    
        public CurrentOrderDetail GetById(int id)
                        => _worldtechContext.CurrentOrderDetails.SingleOrDefault(orderDetail => orderDetail.Id == id);

    
        public void Insert(CurrentOrderDetail entity)
        {
            _worldtechContext.CurrentOrderDetails.Add(entity);
            _worldtechContext.SaveChanges();
        }

        public void Update(CurrentOrderDetail entity)
        {
            CurrentOrderDetail orderToUpdate = GetById(entity.Id);
            orderToUpdate.Order = entity.Order;
            orderToUpdate.Amount = entity.Amount;
            orderToUpdate.Price = entity.Price;
            orderToUpdate.Product = entity.Product;

            if (OrderDetailExists(orderToUpdate))
            {
                _worldtechContext.CurrentOrderDetails.Update(orderToUpdate);
                _worldtechContext.SaveChanges();
            }
        }

        public void DeleteById(int id)
        {
            var orderToDelete = GetById(id);

            if (OrderDetailExists(orderToDelete)) _worldtechContext.CurrentOrderDetails.Remove(orderToDelete);
            _worldtechContext.SaveChanges();
        }

        public bool OrderDetailExists(CurrentOrderDetail orderDetail)
        {
            if (orderDetail != null) return true;

            return false;
        }
    }
}
