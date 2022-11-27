using System.Reflection.Metadata.Ecma335;

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
            //    ["Kayak"] = new Product { Name ="Kayak", Price = 275M },
            //    ["Lifejacket"] = new Product { Name="Lifejacket", Price = 48.95M } 

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

            #endregion
        }
    }
}
