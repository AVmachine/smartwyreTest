using System;
using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Services;

public class RebateService : IRebateService
{
    public CalculateRebateResult Calculate(CalculateRebateRequest request)
    {
        var rebateDataStore = new RebateDataStore();
        var productDataStore = new ProductDataStore();

        Rebate rebate = rebateDataStore.GetRebate(request.RebateIdentifier);
        Product product = productDataStore.GetProduct(request.ProductIdentifier);

        var result = new CalculateRebateResult();

        var rebateAmount = 0m;

        switch (rebate.Incentive)
        {
            case IncentiveType.FixedCashAmount:
                result.Success = AssessFixedCashAmount(rebate, product, ref rebateAmount);
                break;
            case IncentiveType.FixedRateRebate:
                result.Success = AssessFixedRateRebate(rebate, product, request, ref rebateAmount);
                break;
            case IncentiveType.AmountPerUom:
                result.Success = AssessAmountPerUom(rebate, product, request, ref rebateAmount);
                break;
        }

        if (result.Success)
        {
            var storeRebateDataStore = new RebateDataStore();
            storeRebateDataStore.StoreCalculationResult(rebate, rebateAmount);
        }

        return result;
    }

    public bool AssessFixedCashAmount(Rebate rebate, Product product, ref Decimal rebateAmount)
    {
        bool result = false;
        if (rebate == null)
        {
            result = false;
        }
        else if (!product.SupportedIncentives.HasFlag(SupportedIncentiveType.FixedCashAmount))
        {
            result = false;
        }
        else if (rebate.Amount == 0)
        {
            result = false;
        }
        else
        {
            rebateAmount = rebate.Amount;
            result = true;
        }
        return result;
    }

    public bool AssessFixedRateRebate(Rebate rebate, Product product, CalculateRebateRequest request, ref Decimal rebateAmount)
    {
        bool result = false;
        if (rebate == null)
        {
            result = false;
        }
        else if (product == null)
        {
            result = false;
        }
        else if (!product.SupportedIncentives.HasFlag(SupportedIncentiveType.FixedRateRebate))
        {
            result = false;
        }
        else if (rebate.Percentage == 0 || product.Price == 0 || request.Volume == 0)
        {
            result = false;
        }
        else
        {
            rebateAmount += product.Price * rebate.Percentage * request.Volume;
            result = true;
        }
        return result;
    }

    public bool AssessAmountPerUom(Rebate rebate, Product product, CalculateRebateRequest request, ref Decimal rebateAmount)
    {
        bool result = false;
        if (rebate == null)
        {
            result = false;
        }
        else if (product == null)
        {
            result = false;
        }
        else if (!product.SupportedIncentives.HasFlag(SupportedIncentiveType.AmountPerUom))
        {
            result = false;
        }
        else if (rebate.Amount == 0 || request.Volume == 0)
        {
            result = false;
        }
        else
        {
            rebateAmount += rebate.Amount * request.Volume;
            result = true;
        }
        
        return result;
    }
    
    
}
