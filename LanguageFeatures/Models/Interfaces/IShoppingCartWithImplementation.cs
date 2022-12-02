namespace LanguageFeatures.Models.Interfaces
{
    public interface IShoppingCartWithImplementation
    {
        IEnumerable<Product>? Products { get; }
    }
}
