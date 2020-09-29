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

        public void Insert(Product product)
        {
            _worldtechContext.Products.Add(product);
            _worldtechContext.SaveChanges();
        }

        public void Update(Product product)
        {
            Product productToUpdate = GetById(product.Id);
            productToUpdate.Name = product.Name;
            productToUpdate.Description = product.Description;
            productToUpdate.Category = product.Category;
            productToUpdate.Image = product.Image;
            productToUpdate.Price = product.Price;

            if (ProductExists(productToUpdate))
            {
                _worldtechContext.Products.Update(productToUpdate);
                _worldtechContext.SaveChanges();
            }               
        }

        public void DeleteById(int id)
        {
            var productToDelete = GetById(id);

            if (ProductExists(productToDelete)) _worldtechContext.Products.Remove(productToDelete);
            _worldtechContext.SaveChanges();
        }

        public bool ProductExists(Product product)
        {
            if (product != null) return true;

            return false;
        }
    }
}