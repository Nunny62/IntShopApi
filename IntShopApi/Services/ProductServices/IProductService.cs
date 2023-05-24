namespace IntShopApi.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProduct();

        Task<Product?> GetSingleProduct(int id);

        Task<List<Product>> AddProduct(Product oneProduct);

        Task<List<Product>?> UpdateProduct(int id, Product request);

        Task<List<Product>?> DeleteProduct(int id);
    }
}
