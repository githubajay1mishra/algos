using System.IO;
using Xunit;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

public class StringTestDriver
{

    [Fact]
    public void TestForSubArrayMatchesSum()
    {
        var lines = File.ReadLines(@"C:\playground\algos\algos.test\Strings\morganinput.txt")
        .ToList();
        var result = File.ReadLines(@"C:\playground\algos\algos.test\Strings\morganresult.txt")
        .ToList();
        
        var actual = MorganStringAlgo.morganAndString(lines[1].Trim(), lines[2].Trim());
       // Debug.WriteLine(actual);

        Assert.Equal(result[0].Trim(),actual.Trim());



    }




}