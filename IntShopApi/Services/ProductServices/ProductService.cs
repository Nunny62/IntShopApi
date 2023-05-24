using IntShopApi.Models;

namespace IntShopApi.Services.ProductServices
{
    public class ProductService : IProductService
    {

        private readonly DataContext _context;

        public ProductService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Product>> AddProduct(Product oneProduct)
        {
            _context.Product.Add(oneProduct);

            await _context.SaveChangesAsync();

            return await _context.Product.ToListAsync();
        }

        public async Task<List<Product>?> DeleteProduct(int id)
        {
            var oneProduct = await _context.Product.FindAsync(id);
            if (oneProduct is null)
                return null;

            _context.Product.Remove(oneProduct);

            await _context.SaveChangesAsync();


            return await _context.Product.ToListAsync();
        }

        public async Task<List<Product>> GetAllProduct()
        {
            var products = await _context.Product.ToListAsync();
            return products;
        }

        public async Task<Product?> GetSingleProduct(int id)
        {
            var oneProduct = await _context.Product.FindAsync(id);
            if (oneProduct is null)
                return null;
            return oneProduct;
        }

        public async Task<List<Product>?> UpdateProduct(int id, Product request)
        {
            var oneProduct = await _context.Product.FindAsync(id);
            if (oneProduct is null)
                return null;

            oneProduct.Product_name = request.Product_name;
            oneProduct.Product_description = request.Product_description;
            oneProduct.Price = request.Price;
            oneProduct.Assessment = request.Assessment;
            oneProduct.TestID = request.TestID;

            await _context.SaveChangesAsync();

            return await _context.Product.ToListAsync();
        }
    }
}
