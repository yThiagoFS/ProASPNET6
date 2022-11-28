using System.Runtime.CompilerServices;

namespace LanguageFeatures.Models
{
    public static class ExtensionMethod
    {
        // métodos de extensão servem para "modificar" uma classe a qual não tenho acesso, mas não quebrando as regras da classe (métodos privados por exemplo)
        // o this no parametro define a TotalPrices como um método de extensão (metodos de extensão são definidos em classes estaticas e também são estáticos)
        #region aplicando diretamente
        //public static decimal TotalPrices(this ShoppingCart cartParam)
        //{
        //    decimal total = 0;
        //    if (cartParam.Products != null)
        //    {
        //        foreach (Product? prod in cartParam.Products)
        //        {
        //            total += prod?.Price ?? 0;
        //        }
        //    }
        //    return total;
        //}
        #endregion

        #region utilizando como interface
        public static decimal TotalPrices(this IEnumerable<Product?> products)
        {
            decimal total = 0;
            foreach(Product? prod in products)
            {
                total += prod?.Price ?? 0;
            }
            return total;
        }
        #endregion

        #region Filtering extension method -> Método para filtrar coleções de objetos
        
        public static IEnumerable<Product?> FilterByPrice(
            this IEnumerable<Product?> productEnum, decimal minimumPrice)
        {
            foreach(Product? prod in productEnum)
            {
                if((prod?.Price ?? 0) >= minimumPrice)
                {
                    yield return prod;
                }
            }
        }
        #endregion

        #region Lambda Expression para método de filtragem
        public static IEnumerable<Product?> Filter(
            this IEnumerable<Product?> productEnum,
            Func<Product?, bool> selector)
        {
            foreach(Product? prod in productEnum)
            {
                if (selector(prod))
                {
                    yield return prod;
                }
            }
        }
        #endregion
    }
}
