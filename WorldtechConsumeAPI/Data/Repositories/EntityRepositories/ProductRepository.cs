using Domain;
using System.Collections.Generic;
using System.Linq;


namespace Data.Repositories.EntityRepositories
{
    public class ProductRepository : IRepository<Product>
    {
        private WorldtechDbContext _worldtechContext;
        public ProductRepository(WorldtechDbContext worldtechContext)
        {
            this._worldtechContext = worldtechContext;
        }


        public List<Product> GetAll() => _worldtechContext.Products.ToList();

        public Product GetById(int id) => _worldtechContext.Products.SingleOrDefault(product => product.Id == id);

        public void Insert(Product product) => _worldtechContext.Products.Add(product);        
        public void Insert(List<Product> product) => _worldtechContext.Products.AddRange(product);

        public void Update(Product product)
        {
            Product productToUpdate = GetById(product.Id);
            
            if (ProductExists(productToUpdate))
                _worldtechContext.Products.Update(productToUpdate);
        }

        public void DeleteById(int id)
        {
            var productToDelete = GetById(id);

            if (ProductExists(productToDelete)) 
                _worldtechContext.Products.Remove(productToDelete);
        }
        public void DeleteEntities(List<Product> entities) => _worldtechContext.Products.RemoveRange(entities);


        public bool ProductExists(Product product)
        {
            if (product != null) return true;

            return false;
        }

        public void Save() => _worldtechContext.SaveChanges();
    }
}
