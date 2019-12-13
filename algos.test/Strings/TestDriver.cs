using System.IO;
using Xunit;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using algos.test;
using Xunit.Abstractions;

public class StringTestDriver
{
     private readonly ITestOutputHelper output;
    public StringTestDriver(ITestOutputHelper output)
    {
         this.output = output;
    }

    [Fact]
    public void TestForSubArrayMatchesSum()
    {
        var testDirectoryPath = TestUtils.GetTestDirectory();
        this.output.WriteLine(Path.Join(testDirectoryPath, $"Strings\\morganinput.txt"));       
        var lines = File.ReadLines(Path.Join(testDirectoryPath, $"Strings\\morganinput.txt"))
        .ToList();
        var result = File.ReadLines(Path.Join(testDirectoryPath, $"Strings\\morganresult.txt"))
        .ToList();
        
        var actual = MorganStringAlgo.morganAndString(lines[1].Trim(), lines[2].Trim());
       // Debug.WriteLine(actual);

        Assert.Equal(result[0].Trim(),actual.Trim());

    }




}