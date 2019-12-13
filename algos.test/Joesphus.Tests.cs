using System;
using Xunit;

namespace algos.test
{
    public class JospehusTests
    {
        
        //[Fact]
        
        public void TestForKnowInput1()
        {
            string[] input= {"3 2"};
            Assert.Equal(3, Josephus.parseInputAndGetOutput(input)[0]);

            string[] input2= {"5 3"};
            Assert.Equal(4, Josephus.parseInputAndGetOutput(input2)[0]);
        
        }

        
    }
}
