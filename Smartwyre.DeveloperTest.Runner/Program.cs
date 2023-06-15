using System;
using Smartwyre.DeveloperTest.Types;
using Smartwyre.DeveloperTest.Services;

namespace Smartwyre.DeveloperTest.Runner;

class Program
{
    static void Main(string[] args)
    {
        CalculateRebateRequest request = new CalculateRebateRequest();
        Console.WriteLine("Enter the rebate identifier:");

        request.RebateIdentifier = Console.ReadLine();
        
        Console.WriteLine("Enter the product identifier:");

        request.ProductIdentifier = Console.ReadLine();
        
        Console.WriteLine("Enter the volume:");

        var input  = Console.ReadLine();
        Decimal.TryParse(input, out decimal decimalResult);
        request.Volume = decimalResult;

        Console.WriteLine($@"
Product Identifier: {request.ProductIdentifier},
Rebate Identifier: {request.RebateIdentifier},
Volume: {request.Volume}
");
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();

        RebateService rebateService = new RebateService();
        var result = rebateService.Calculate(request);
        Console.WriteLine(result);
    }
}
