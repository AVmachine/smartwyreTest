using System;
using Smartwyre.DeveloperTest.Services;
using Xunit;
using  Smartwyre.DeveloperTest.Types;
using Smartwyre.DeveloperTest.Data;

namespace Smartwyre.DeveloperTest.Tests;

public class PaymentServiceTests
{
    private RebateService rebateService = new RebateService();
    
    //Would test if data stores could grab values
    // [Fact]
    // public void TestCalculateWithNull()
    // {
    //     Decimal rebateAmount = 0m;
    //     Assert.True(rebateService.Calculate(null).Success);
    // } 
    // //Would create objects with specified values to test against
    // [Fact]
    // public void TestCalculateWithValue()
    // {
    //     Decimal rebateAmount = 0m;
    //     //object
    //     Assert.False(rebateService.Calculate(null).Success);
    // }
    
    [Fact]
    public void TestAssessFixedCashAmountWithNull()
    {
        Decimal rebateAmount = 0m;
        Assert.False(rebateService.AssessFixedCashAmount(null, null, ref rebateAmount));
    }
    // //Would create objects with specified values to test against
    // [Fact]
    // public void TestAssessFixedCashAmountWithValue()
    // {
    //     Decimal rebateAmount = 0m;
    //     //object
    //     Assert.False(rebateService.AssessFixedCashAmount(null, null, ref rebateAmount));
    // }
    
    [Fact]
    public void TestAssessFixedRateRebateWithNull()
    {
        Decimal rebateAmount = 0m;
        Assert.False(rebateService.AssessFixedRateRebate(null, null, null, ref rebateAmount));
    }
    // //Would create objects with specified values to test against
    // [Fact]
    // public void TestAssessFixedRateRebateWithValue()
    // {
    //     Decimal rebateAmount = 0m;
    //     //object
    //     Assert.False(rebateService.AssessFixedRateRebate(null, null, null, ref rebateAmount));
    // }
    
    [Fact]
    public void TestAssessAmountPerUomWithNull()
    {
        Decimal rebateAmount = 0m;
        Assert.False(rebateService.AssessAmountPerUom(null, null, null, ref rebateAmount));
    }
    ////Would create objects with specified values to test against
    // [Fact]
    // public void TestAssessAmountPerUomWithValue()
    // {
    //     Decimal rebateAmount = 0m;
    //     //object
    //     Assert.False(rebateService.AssessAmountPerUom(null, null, null, ref rebateAmount));
    // }
    
    
    
    
}
