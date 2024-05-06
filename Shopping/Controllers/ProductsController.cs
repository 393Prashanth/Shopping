using Microsoft.AspNetCore.Mvc;
using Shopping.DbContextFolder;
using Shopping.Models;

namespace Shopping.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext context;

        public ProductsController(ApplicationDbContext context) 
        {
        this.context = context;
        
       
        }
        public IActionResult Index()
        {
            var products = context.Products.ToList();
            return View(products);
        }
        public IActionResult Create() 
        {
        return View();
        
        }
        [HttpPost]
        public IActionResult Create(ProductDto prodcutDto)
        {
            if (!ModelState.IsValid) 
            {
                return View(prodcutDto);
            }
            Product product = new Product()
            {
                ProductName=prodcutDto.ProductName,
                ProductBrand=prodcutDto.ProductBrand,
                ProductCategory=prodcutDto.ProductCategory,
                ProductPrice=prodcutDto.ProductPrice,
                ProductDescription=prodcutDto.ProductDescription,


            };
            context.Products.Add(product);
            context.SaveChanges();
            return RedirectToAction("Index","Products");
        }

        public IActionResult Edit(int id) 
        {
         var product=context.Products.Find(id);

            if(product == null) 
            {
                return RedirectToAction("Index", "Products");
            }

            var productDto = new ProductDto()
            {
                ProductName = product.ProductName,
                ProductBrand = product.ProductBrand,
                ProductCategory = product.ProductCategory,
                ProductPrice = product.ProductPrice,
                ProductDescription = product.ProductDescription,

            };

            ViewData["id"] = product.Id;    
            return View(productDto);    

        }
        [HttpPost]
        public IActionResult Edit(int id, ProductDto productDto)
        {
            var product=context.Products.Find(id);

            if (product == null)
            {
                return RedirectToAction("Index", "Products");
            }
            
            if(!ModelState.IsValid) 
            {
                ViewData["id"]= product.Id;
                return View(productDto);
            }

           
           product.ProductName = productDto.ProductName;
            product.ProductBrand = productDto.ProductBrand;
            product.ProductCategory = productDto.ProductCategory;
            product.ProductPrice = productDto.ProductPrice;
            product.ProductDescription = productDto.ProductDescription;

            context.SaveChanges();
            return RedirectToAction("Index", "Products");
        

        }

        public IActionResult Delete(int id) 
        {
        
        var prodcut=context.Products.Find(id);

            if(prodcut == null)
            {
                return RedirectToAction("Index", "Products");
            }

            context.Products.Remove(prodcut);
            context.SaveChanges(true);

            return RedirectToAction("Index", "Products");
        }
    }
}
