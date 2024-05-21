using eShop.WebAppComponents.Services;

namespace eShop.MetallFactorUI.Services;

public class ProductImageUrlProvider : IProductImageUrlProvider
{
    public string GetProductImageUrl(int productId)
        => $"product-images/{productId}";
}
