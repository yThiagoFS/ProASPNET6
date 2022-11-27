using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageFeatures.Models
{
    public class Product
    {
        // Definindo um valor padrão, para não ser um valor nulo
        public string Name { get; set; } = string.Empty;
        public decimal? Price { get; set; }

        public static Product?[] GetProducts()
        {
            Product kayak = new Product { Name = "kayak", Price = 275M };
            Product lifejacket = new Product { Name = "Lifejacket", Price = 48.95M };

            return new Product?[] { kayak, lifejacket, null };
        }
    }
}
#region Cuidados com o nullable type
/*
----> Product?[] -> Um array que contem Produtos ou valores nulos, mas o ARRAY NÃO É NULO
Product?[] arr1 =  new Product?[] { kayak, lifejacket, null }; -> CERTO
Product?[] arr2 = null; -> ERRADO (está especificando que o array é nulo, e não um item.)

--------------------------------------

----> Product[]? -> Um array que CONTEM SOMENTE PRODUTOS, mas o ARRAY em si PODE SER NULO
Product[]? arr1 = new Product[]? { kayak, lifejacket, null }; -> ERRADO, pois o array pode conter somente PRODUTOS e não valores nulos
Product[]? arr2 = null; -> Certo (O array pode ser nulo)

--------------------------------------

----> Product?[]? -> Um array que PODE SER NULO ou PODE CONTER VALORES NULOS
Product?[]? arr1 = new Product?[]? { null, null, kayak }; -> Certo, pois pode conter valores nulos
Product?[]? arr2 = nul; -> Certo, pois o array em si pode ser nulo


 
 
 */
#endregion