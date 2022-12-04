namespace LanguageFeatures.Models.Interfaces
{
    public interface IShoppingCartWithImplementation
    {
        IEnumerable<Product>? Products { get; }

        IEnumerable<string>? Names => Products?.Select(p => p.Name);
    }
}
