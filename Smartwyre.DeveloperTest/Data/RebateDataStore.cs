using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Data;

public class RebateDataStore
{
    public Rebate GetRebate(string rebateIdentifier)
    {
        // Access database to retrieve account, code removed for brevity
        //Had to insert something so I could debug
        return new Rebate()
        {
            Identifier = "234",
            Incentive = IncentiveType.FixedCashAmount,
            Amount = 5,
            Percentage = 5
        };
    }

    public void StoreCalculationResult(Rebate account, decimal rebateAmount)
    {
        // Update account in database, code removed for brevity
    }
}
