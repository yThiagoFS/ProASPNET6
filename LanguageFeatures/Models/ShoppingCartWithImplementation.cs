using LanguageFeatures.Models.Interfaces;

namespace LanguageFeatures.Models
{
    public class ShoppingCartWithImplementation : IShoppingCartWithImplementation
    {
        private List<Product> products = new();

        public ShoppingCartWithImplementation(params Product[] prods)
        {
            products.AddRange(prods);
        }

        public IEnumerable<Product>? Products { get => products; }
    }
}
