using LanguageFeatures.Models.Interfaces;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Schema;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            Product?[] products = Product.GetProducts();
            Product? p = products[0];

            #region null conditional operator
            //string val;
            //if (p != null)
            //    val = p.Name;
            //else
            //    val = "No value";

            //return View(new string[] { val });
            #endregion

            #region null-coalescing operator
            //return View(new string[] { products[0]?.Name ?? "No value" });

            // ?? -> retorna o valor da esquerda se não for nulo e o da direita se for nulo
            #endregion

            #region deixando explicito que a variavel não será nula
            // return View(new string[] { products[0]!.name }); 
            #endregion

            #region usando string interpolation
            //return View(new string[]
            //{
            //    $"Name: {products[0]?.Name}, Price:{products[0]?.Price} "
            //});
            #endregion

            #region Object and collection initializer
            /* Object initializer:

             Product kayak = new Product {
            Name = "Kayak", Price = 275M
            } 


            // Collection Initializer:

            // SEM A COLLECTION INITIALIZER:
            string[] names = new string[3];
            names[0] = "Bob";
            names[1] = "Joe";
            names[2] = "Alice";
            return View("Index", names);
             

            // COM A COLLECTION INITIALIZER:
            return View("Index", new string[] { "Bob", "Joe", "Alice" });
             */
            #endregion

            #region Index initializer (dicionario)
            //Dictionary<string, Product> productsDictionary = new Dictionary<string, Product>
            //{
            //    ["Kayak"] = new Product { Name = "Kayak", Price = 275M },
            //    ["Lifejacket"] = new Product { Name = "Lifejacket", Price = 48.95M }

            //};
            //return View("Index", productsDictionary.Keys);


            #region target-type expression
            //Dictionary<string, Product> productsDictionary = new()
            //{
            //    ["Kayak"] = new Product { Name = "Kayak", Price = 200M },
            //    ["Lifejacket"] = new Product { Name = "Lifejacket", Price = 49M }
            //};
            //return View("Index", productsDictionary.Keys);
            #endregion

            #endregion

            #region Pattern Matching
            // Verifica se um objeto possui determinado tipo ou caracteristica

            //object[] data = new object[] { 275M, 29.95M,
            //    "apple", "orange", 100, 10
            //};
            //int total = 0;

            //for(int i = 0; i < data.Length; i++)
            //{
            //    if (data[i] is int d){
            //        total += d;
            //        // verifica se o valor é inteiro, se for, soma o valor na variavel total 
            //    }
            //}
            //return View("Index", new string[] { $"Total: {total:c2}" });

            #endregion

            #region Pattern Matching in switch Statements
            object[] data = new object[] { 275M, 29.5M, "apple", "orange", 100, 10 };
            decimal total = 0;
            for(int i = 0; i < data.Length; i++) 
            {
                switch (data[i])
                {
                    case decimal decimalValue:
                        total += decimalValue;
                        break;

                    case int intValue when intValue > 50:
                        total += intValue;
                        break;
                }
            }
            return View("Index", new string[] { $"Total: {total:C2}" });
            #endregion
        }
        [HttpGet("/method")]
        public ViewResult ExtensionMethod()
        {
            /* ------------- Método sem INTERFACE
            ShoppingCart cart
                = new ShoppingCart { Products = Product.GetProducts() };
            decimal cartTotal = cart.TotalPrices();
            return View("ExtensionMethod", new string[] { $"Total: {cartTotal:C2}" });
            */


            // Utilizando a interface
            ShoppingCart cart
                = new ShoppingCart { Products = Product.GetProducts() };
            Product[] productArray =
            {
                new Product { Name = "kayak", Price = 275M },
                new Product { Name = "jacket", Price = 48.95M }
            };
            decimal cartTotal = cart.TotalPrices();
            decimal arrayTotal = productArray.TotalPrices();

            return View("ExtensionMethod", new string[]
            {
                $"Cart Total: {cartTotal:C2}",
                $"Array Total: {arrayTotal:C2}"
            });
        }

        [HttpGet("/filter-method")]
        public ViewResult ExtensionMethodFilter()
        {

            Product[] productArray =
            {
                new Product { Name = "kayak", Price = 275M },
                new Product { Name = "jacket", Price = 49.5M },
                new Product { Name = "Soccer ball", Price = 19.50M },
                new Product { Name = "Corner flag", Price = 34.95M }
            };
            decimal arrayTotal = productArray.FilterByPrice(20).TotalPrices();

            return View("ExtensionMethod", new string[] { $"Array Total: {arrayTotal:C2}" });
        }
        [HttpGet("/filter-lambda")]
        public ViewResult FilterMethodLambda()
        {
            // Preciso utilizar somente caso não utilize a lambda expression
            //bool FilterByPrice(Product? p)
            //{
            //    return (p?.Price ?? 0) >= 30;
            //}

            Product[] productArray =
            {
                new Product { Name = "p1", Price = 275M },
                new Product { Name = "p2", Price = 48.95M },
                new Product { Name = "p3", Price = 19.50M },
                new Product { Name = "p4", Price = 34.95M }
            };

            // Função que a Lambda Expression substitui
            //Func<Product?, bool> nameFilter = delegate (Product? prod)
            //{
            //    return prod?.Name?[0] == 'S';
            //};

            decimal priceFilterTotal = productArray
                .Filter(p => (p?.Price ?? 0) >= 20)
                .TotalPrices();

            decimal nameFilterTotal = productArray
                .Filter(p => p?.Name?[0] == 'S')
                .TotalPrices();

            return View("ExtensionMethod", new string[]
            {
                $"Price Total: {priceFilterTotal:C2}",
                $"Name Total: {nameFilterTotal:C2}"
            });
        }
        [HttpGet("/anonymous-type")]
        public ViewResult AnonymousType()
        {
            var products = new[]
            {
                new { Name = "Kayak", Price = 275M },
                new { Name = "Lifejacket", Price = 48.95M },
                new { Name =  "Soccer ball", Price = 19.50M },
                new { Name = "Corner flag", Price = 34.95M }
            };
            return View("Index", products.Select(p => p.Name));
        }
        [HttpGet("/implementation-interfaces")]
        public ViewResult ImplementationInterfaces()
        {
            IShoppingCartWithImplementation cart = new ShoppingCartWithImplementation(
                new Product { Name = "Kayak", Price = 275M },
                new Product { Name = "Lifejacket", Price = 48.95M },
                new Product { Name = "Soccer ball", Price = 19.50M },
                new Product { Name = "Corner flag", Price = 34.95M  }
                );
            return View("Index", cart.Products?.Select(p => p.Name));
        }

    }
}
