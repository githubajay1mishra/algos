using System.IO;
using Xunit;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using algos.test;
using Xunit.Abstractions;
using algos.Strings;

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

    [Fact]
    public void LargestNonRepeatingSubstring(){
        Assert.Equal(3, 
        LongestSubstringWithNoRepeats.FindLongestSubstringWithNonRepeatingCharacters("dvdf"));

        Assert.Equal(4, 
        LongestSubstringWithNoRepeats.FindLongestSubstringWithNonRepeatingCharacters("abcd"));

        Assert.Equal(3, 
        LongestSubstringWithNoRepeats.FindLongestSubstringWithNonRepeatingCharacters("abcbccd"));

        Assert.Equal(2, 
        LongestSubstringWithNoRepeats.FindLongestSubstringWithNonRepeatingCharacters("abba"));
    }

    [Fact]
    public void RomanToInt(){
        var converter = new RomanNumeralStringToAlgo();

        Assert.Equal(10, 
        converter.RomanToInt("X"));

        Assert.Equal(58, 
        converter.RomanToInt("LVIII"));

        Assert.Equal(4, 
        converter.RomanToInt("IV"));

    }




}