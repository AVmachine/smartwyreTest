using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Data;

public class ProductDataStore
{
    public Product GetProduct(string productIdentifier)
    {
        // Access database to retrieve account, code removed for brevity 
        //Had to insert something so I could debug
        return new Product()
        {
            Id = 123,
            Identifier = "1234",
            Price = 5,
            Uom = "units",
            SupportedIncentives = SupportedIncentiveType.FixedCashAmount
        };
    }
}
