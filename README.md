# ProASPNET6
Activities from the book Pro Asp NET Core 6


# Essencial C# Features (LanguageFeature) -> Chapter V
 * Contents 
    * Top-Level Statements (Program.cs);
    
    * Understanding Global using Statements (creating a GlobalUsing.cs file, and adding some using, like "using LanguageFeatures.models", 
    that allows me to use it in any place that i want);
    
    * Implicit using Statements (System.IO, for example);
    
    * Understanding Null State Analysis (Using nullable types and learning to apply the question mark correctly);
    
    * Using the Null-Coalescing Operator (left-hand operand ?? right-hand operand) if left-hand operand is null, so it will return the value of the right-hand operand
    * Overriding Null State Analysis (tells the compiler that my operation isn't null using !, ex: (products[0]!.Name));
    
    * Using String Interpolation (allows me to use a c# variable value to create formatted strings, ex: ($"Hello {Name}, welcome to my ReadMe!"));
    
    * Using Object and Collection Initializers (a syntax sugar that allows the creation of a collection and its contents to be specified in a single step. 
    (return new string[] { "Name1", "Name2", "Name3"});
    
    * Using an Index Initializer:  <br/>
     <img alt="Index initializer example." src="https://github.com/yThiagoFS/ProAspNetImgs/blob/main/IndexInitializer.png?raw=true">;
    
    * Using Target-Typed New Expressions (the same as the last item, but a little less verbose.) <img alt="Target typed expressions." src="https://github.com/yThiagoFS/ProAspNetImgs/blob/main/TargetTypedExpressions.png?raw=true">;
    
    * Pattern Matching (Test if an object is of a specific type or has specific characteristics, ex: (when iterating over an object with a simple for loop, 
    i can do: if(data[i] is decimal d) => return of the condition));
    
    * Pattern Matching in switch Statements (while iterating over a loop, i can create a switch statement and create cases with pattern matching, ex: 
    (switch(data[i])
      case decimal decimalValue; => check if data[i] is a decimal
      case int intValue when intValue > 50; => check if is an int value and is bigger than 50.
    ));
    
    * Extension Methods (way of adding methods to classes that i cannot modify directly, maybe because they're provided by Microsoft or a thid-party package.
    Extension methods are defined in static classes and are also statics.); 
    Adding it directly:<img alt="Extension method directly." src="https://github.com/yThiagoFS/ProAspNetImgs/blob/main/ExtensionMethodDirectly.png?raw=true">
      
    *Applying Extension Methods to an Interface (it allows me to call the extension method on all the classes that implement the interface.);
    Here is the interface: <br/>
     <img alt="Apllying the extension methods to an interface - Interface" src="https://github.com/yThiagoFS/ProAspNetImgs/blob/main/ExtensionMethodInterface.png?raw=true"> 
     Updating the Extension Method in the Model's folder:  <br/>
     <img alt="Updating the Extension Method in the Model's folder." src="https://github.com/yThiagoFS/ProAspNetImgs/blob/main/UpdatingExtensionMethod.png?raw=true">
     Using the Extension Method with the interface on HomeController:  <br/>
     <img alt="Using the Extension Method with the interface" src="src="https://github.com/yThiagoFS/ProAspNetImgs/blob/main/UsingExtensionMethodWInterface.png?raw=true""> 
    
    
    
    
    
