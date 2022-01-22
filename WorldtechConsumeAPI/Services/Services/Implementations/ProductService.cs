using AutoMapper;
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
        private IRepository<Comment> _commentRepository;
        private readonly IMapper _mapper;
        private List<Product> _currentProducts;

        public ProductService(IRepository<Product> productRepository, IMapper mapper, 
                              IRepository<Comment> commentRepository)
        {
            this._productRepository = productRepository;
            this._mapper = mapper;
            this._commentRepository = commentRepository;
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
            _productRepository.Save();
        }

        public void RemoveProductById(int id)
        {
            _productRepository.DeleteById(id);
            _productRepository.Save();
        }

        public ProductViewModel GetMostExpensiveProduct()
        {
            var products = _productRepository.GetAll();

            double highestPrice = products?.Max(product => product.Price) ?? default;
            var mostExpensiveProduct = products?.FirstOrDefault(product => product.Price == highestPrice);

            return _mapper.Map<ProductViewModel>(mostExpensiveProduct);
        }

        public ProductViewModel GetCheapestProduct()
        {
            var products = _productRepository.GetAll();

            double lowestPrice = products?.Min(product => product.Price) ?? default;
            var cheapestProduct = products?.FirstOrDefault(product => product.Price == lowestPrice);

            return _mapper.Map<ProductViewModel>(cheapestProduct);
        }


        public List<ProductViewModel> GetComputers() 
        {
            return _mapper.Map<List<ProductViewModel>>(_productRepository.GetAll())
                .Where(product => product.Category == ProductCategory.Computer).ToList();            
        }
        public List<ProductViewModel> GetGadgets()
        {
            return _mapper.Map<List<ProductViewModel>>(_productRepository.GetAll()) 
                .Where(product => product.Category == ProductCategory.Gadget).ToList();
        }
        public List<ProductViewModel> GetLaptops()
        {
            return _mapper.Map<List<ProductViewModel>>(_productRepository.GetAll())
                .Where(product => product.Category == ProductCategory.Laptop).ToList();
        }

        public List<ProductViewModel> GetProductsFromApi(string apiUrl)
        {
            var client = new HttpClient();
            string uri = "https://localhost:44354/"; // ******************** MIGHT NEED TO BE CHANGED ********************
            string url = apiUrl;

            string response = client.GetAsync(uri + url).Result.Content.ReadAsStringAsync().Result;
            var products = JsonConvert.DeserializeObject<List<Product>>(response);
            _currentProducts = products;

            return _mapper.Map<List<ProductViewModel>>(products);
        }

        public void PopulateDbWithProducts()
        {            
            _productRepository.Insert(_currentProducts);            
            _productRepository.Save();
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

        public List<CommentVM> GetComments() => _mapper.Map<List<CommentVM>>(_commentRepository.GetAll());
        public void SaveComment(CommentVM commentVM)
        {
            var comment = _mapper.Map<Comment>(commentVM);

            _commentRepository.Insert(comment);
            _commentRepository.Save();
        }
        public void DeleteAllComents()
        {
            _commentRepository.DeleteEntities(_commentRepository.GetAll());
            _commentRepository.Save();
        }
    }
}