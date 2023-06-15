using System;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Services;

public interface IRebateService
{
    CalculateRebateResult Calculate(CalculateRebateRequest request);
    bool AssessFixedCashAmount(Rebate rebate, Product product, ref Decimal rebateAmount);

    bool AssessFixedRateRebate(Rebate rebate, Product product, CalculateRebateRequest request,
        ref Decimal rebateAmount);

    bool AssessAmountPerUom(Rebate rebate, Product product, CalculateRebateRequest request,
        ref Decimal rebateAmount);
}
