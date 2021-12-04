using System.Collections.Generic;
public class StringPathBuilder
{
    private const string root = "/";


    public StringPathBuilder()
    {
    }

    public class DirectoryInfo{

        public string Path {get;set;}
        public string Name {get;set;}
        public string Parent{get;set;} 
    }

    public string ToCanonicalPath(string unixPath){
        var directoryOrOperations = unixPath.Split(new char[]{'/'}, System.StringSplitOptions.RemoveEmptyEntries);

        var directoryToPathMap = new Dictionary<string, DirectoryInfo>();
        directoryToPathMap[root] = new DirectoryInfo(){
            Path = root,
            Name = root,
            Parent = root
        };

        var currentCompletePath = root;
        
        foreach(var directoryOrOperation in directoryOrOperations){
            if(directoryOrOperation == "."){
                continue;
            }

            if(directoryOrOperation == ".."){
                currentCompletePath = directoryToPathMap[currentCompletePath].Parent;
                continue;
            }

            var completePath = currentCompletePath == root
             ? "/"  + directoryOrOperation 
             : currentCompletePath + "/" + directoryOrOperation;


            if(!directoryToPathMap.ContainsKey(completePath)){
                directoryToPathMap[completePath] = new DirectoryInfo(){
                    Path = completePath,
                    Name = directoryOrOperation,
                    Parent = currentCompletePath,
                };
                
            }

            currentCompletePath = completePath;

        }

       return currentCompletePath;
    }
}