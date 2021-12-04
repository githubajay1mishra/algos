using Xunit;
using System;
using System.Collections.Generic;
using algos.Strings;

public class PhoneNumberTests{

    [Theory]
    [InlineData("2", new string[]{"a", "b", "c"})]
    public void Validate(string digits, string[] expected){
        var comb = new PhoneNumberCombination();
        var result = comb.ListCombination(digits);
        Assert.Equal(new List<string>(expected), result);

    }




}