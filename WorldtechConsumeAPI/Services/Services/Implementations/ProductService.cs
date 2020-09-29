using AutoMapper;
using Data;
using Data.Repositories;
using Domain;
using Newtonsoft.Json;

using Presentation.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;


namespace Services
{
    public class ProductService : IProductService
    {
        private IRepository<Product> _productRepository;
        private WorldtechDbContext _worldtechDbContext;
        private readonly IMapper _mapper;
        private List<Product> _currentProducts;
        public ProductService(IRepository<Product> productRepository, WorldtechDbContext worldtechDbContext,
                              IMapper mapper)
        {
            this._productRepository = productRepository;
            this._worldtechDbContext = worldtechDbContext;
            this._mapper = mapper;
        }


        public List<ProductViewModel> GetAllProducts()
        {
            var products = _productRepository.GetAll();
            var productsVMs = _mapper.Map<List<ProductViewModel>>(products);

            return productsVMs;
        }
        public List<ProductViewModel> GetProductsByName(string name)
        {
            var products = _productRepository.GetAll().FindAll(product => product.Name == name);
            return _mapper.Map<List<ProductViewModel>>(products);
        }
        public ProductViewModel GetProductById(int id)
        {
            var product = _productRepository.GetById(id);
            return _mapper.Map<ProductViewModel>(product);
        }
        public int GetNumberOfProducts() => _productRepository.GetAll().Count;

        public void AddNewProduct(ProductViewModel productVM)
        {
            var product = _mapper.Map<Product>(productVM);
            _productRepository.Insert(product);
        }
        public void RemoveProductById(int id) => _productRepository.DeleteById(id);

        public ProductViewModel GetMostExpensiveProduct()
        {
            double highestPrice = _productRepository.GetAll().Max(product => product.Price);
            var mostExpensiveProduct = _productRepository.GetAll().FirstOrDefault(product => product.Price == highestPrice);

            return _mapper.Map<ProductViewModel>(mostExpensiveProduct);
        }
        public ProductViewModel GetCheapestProduct()
        {
            double lowestPrice = _productRepository.GetAll().Min(product => product.Price);
            var cheapestProduct = _productRepository.GetAll().FirstOrDefault(product => product.Price == lowestPrice);

            return _mapper.Map<ProductViewModel>(cheapestProduct);
        }



        public List<ProductViewModel> GetComputers() 
        {
            return _mapper.Map<List<ProductViewModel>>(_worldtechDbContext.Computers) // Why aren't the pcs from line 127 filtered?
                .Where(product => product.Category == ProductCategory.Computer).ToList();            
        }
        public List<ProductViewModel> GetGadgets()
        {
            return _mapper.Map<List<ProductViewModel>>(_worldtechDbContext.Gadgets) 
                .Where(product => product.Category == ProductCategory.Gadget).ToList();
        }
        public List<ProductViewModel> GetLaptops()
        {
            return _mapper.Map<List<ProductViewModel>>(_worldtechDbContext.Laptops)
                .Where(product => product.Category == ProductCategory.Laptop).ToList();
        }

        public List<ProductViewModel> GetProductsFromApi(string apiUrl)
        {
            var client = new HttpClient();
            string uri = "https://localhost:44354/";
            string url = apiUrl;

            string response = client.GetAsync(uri + url).Result.Content.ReadAsStringAsync().Result;
            var products = JsonConvert.DeserializeObject<List<Product>>(response);
            _currentProducts = products;

            return _mapper.Map<List<ProductViewModel>>(products);
        }

        public void PopulateDbWithProducts()
        {
            var computers = new List<Product>();
            var gadgets = new List<Product>();
            var laptops = new List<Product>();

            foreach (var product in _currentProducts)
            {
                switch (product.Category)
                {
                    case ProductCategory.Computer:
                        computers.Add(product);
                        break;
                    case ProductCategory.Gadget:
                        gadgets.Add(product);
                        break;
                    case ProductCategory.Laptop:
                        laptops.Add(product);
                        break;
                    default:
                        break;
                }
            }

            _worldtechDbContext.Products.AddRange(_currentProducts);
            _worldtechDbContext.Computers.AddRange(computers); // Why aren't the pcs filtered?(here they are but at line 75 they aren't...)
            _worldtechDbContext.Gadgets.AddRange(gadgets);
            _worldtechDbContext.Laptops.AddRange(laptops);

            _worldtechDbContext.SaveChanges();
        }

        public List<string> DivideDescription(string description)
        {
            string space = " ";
            List<string> words = description.Split(space).ToList();
            int firstHalf = words.Count / 2;

            string description1 = string.Empty;
            for (int i = 0; i < firstHalf; i++) description1 += words[i] + space;

            string description2 = string.Empty;
            var secondHalf = words.Skip(firstHalf);
            foreach (string word in secondHalf) description2 += word + space;

            return new List<string>() { description1, description2 };
        }

        public List<CommentVM> GetComments() => _mapper.Map<List<CommentVM>>(_worldtechDbContext.Comments.ToList());
        public void SaveComment(CommentVM commentVM)
        {
            var comment = _mapper.Map<Comment>(commentVM);
            _worldtechDbContext.Comments.Add(comment);
            _worldtechDbContext.SaveChanges();
        }
        public void DeleteAllComents()
        {
            _worldtechDbContext.Comments.RemoveRange(_worldtechDbContext.Comments);
            _worldtechDbContext.SaveChanges();
        }
    }
}