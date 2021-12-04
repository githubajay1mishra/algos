using System.Collections.Generic;
using System.Linq;

public class AllPaths
{

    public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
    {
         return AllPathsSourceTarget(graph, 0, new Dictionary<int, IList<IList<int>>>());
    }

    public IList<IList<int>> AllPathsSourceTarget(int[][] graph, int index, Dictionary<int, IList<IList<int>>> memo)
    {

        // index == desitination
        if (index == GetDestination(graph))
        {
            return new List<IList<int>>(){
             new List<int>{index}
         };

        }

        var outputs = GetOutputs(graph, index);
        var results = new List<IList<int>>();

        if(outputs.Length == 0){
            return results;
        }

        if(memo.ContainsKey(index)){
            return memo[index];
        }

        foreach(var output in outputs)
        {
            var paths = AllPathsSourceTarget(graph, output, memo);
            var pathsToAdd = paths.Where(x => x.Count > 0)
                                  .Select(x => {
                                      var list = new List<int>(){
                                          index
                                      };
                                      list.AddRange(x);
                                      return list;
                                  });
            results.AddRange(pathsToAdd);

        }

        memo[index] = results;

       return memo[index]; 

    }

    private int GetDestination(int[][] graph)
    {
        return graph.Length - 1;
    }

    private int[] GetOutputs(int[][] graph, int index)
    {
        return graph[index];
    }


}