using System;
using System.Collections.Generic;
using System.Text;

namespace algos.Trees
{
    public class AlienSolution{
        bool isCycle = false;

        public string AlienOrder(string[] words) {
            if(words == null || words.Length < 1){
                return string.Empty;
            }

            var graph = CreateGraphForAllWords(words);
            AddRelationsShips(words, graph);
            return TopologicallySortedWords(graph);        
        }

        private string TopologicallySortedWords(Dictionary<char, Node> graph){
            var sb = new StringBuilder();
            foreach(var key in graph.Keys){
                var node = graph[key];
                if(node.State == NodeState.NotVisited){
                    Visit(graph, node, sb);
                }
            }

            if(isCycle){
                return "";
            }

            return sb.ToString();
        }

        private void Visit(Dictionary<char, Node> graph, Node node, StringBuilder sb){

            node.State = NodeState.Visiting;

            foreach(var neighbour in node.Neighbours){
                var neighbourNode = graph[neighbour];
                if(neighbourNode.State == NodeState.NotVisited){
                    Visit(graph, neighbourNode, sb);
                }

                if(neighbourNode.State == NodeState.Visiting){
                    isCycle = true;
                    return;
                }
            }

            node.State = NodeState.Visited;
            sb.Insert(0, node.Character);

        }

        
        private Dictionary<char, Node> CreateGraphForAllWords(string[] words){
            var graph = new  Dictionary<char, Node>();
            foreach (var word in words)
            {
                foreach(char c in word){
                    if(!graph.ContainsKey(c)){
                        graph[c] = new Node(c);
                    }
                    
                }
            }

            return graph;
        }

        private void AddRelationsShips(string[] words, Dictionary<char, Node> graph){

            int prevIndex = 0; 
            for(int currentIndex  = 1; currentIndex < words.Length; ++currentIndex, ++prevIndex){
                var currentCharacterIndex = 0;
                var prevWord = words[prevIndex];
                var currentWord = words[currentIndex];
                while(currentCharacterIndex < currentWord.Length && currentCharacterIndex < prevWord.Length ){
                    if(prevWord[currentCharacterIndex] != currentWord[currentCharacterIndex]){
                        AddRelationsShips(prevWord[currentCharacterIndex], currentWord[currentCharacterIndex], graph);
                        break;
                    }

                    ++currentCharacterIndex;
                }
            }            
        }

        private void AddRelationsShips(char prevWordChar, char nextWordChar, Dictionary<char, Node> graph){
            var prevNode = graph[prevWordChar];
             prevNode.Neighbours.Insert(0, nextWordChar);
        }


        enum NodeState{
        NotVisited,
        Visiting,
        Visited
    }

    class Node{
        public NodeState State {get; set;} = NodeState.NotVisited;
        public List<char> Neighbours{get;} = new List<char>();
        public char Character{get; private set;}
        public Node(char c)
        {
            State = NodeState.NotVisited;
            Character = c;
        }
    }
    }   
    
}