using System;
using Trees;
using System.Linq;
using Xunit;

public class TreesTestDriver
{

    private int[] GetData(string data){

        return data.Trim()
                           .Split(' ',  StringSplitOptions.RemoveEmptyEntries)                                   
                           .Select( x => int.Parse(x))
                           .ToArray();

    }

    [Theory]
    [InlineData("100 40 60 50 70 30 20", "100 20 30 40 50 60 70", "60 70 50 40 30 20 100")]
    public void TestGenerateTree(string inOrderData, string preOrderData, string postOrderData)
    {
        int[] inOrder = GetData(inOrderData);
        int[] preOrder = GetData(preOrderData);       

        int[] postOrder = GetData(postOrderData);

        var generator = new GenerateTree();
        var root = generator.BuildTreeV2(inOrder, preOrder, 0, inOrder.Length - 1);
        var actual = generator.PrintPostOrder(root);

        Assert.Equal(postOrder, actual);

    }



}