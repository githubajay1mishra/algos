using System;
using System.Collections.Generic;
using System.Linq;

namespace algos.Trees
{

    public class SolutionDistanceFromAll
    {
        public class DistanceForAllBuilding
        {
            private int[] BuildingDistances;
            public DistanceForAllBuilding(int buildingCount)
            {
                BuildingDistances = new int[buildingCount];
                for (int index = 0; index < buildingCount; index++)
                {
                    BuildingDistances[index] = int.MaxValue;
                }
            }

            public int GetDistance(int building)
            {
                return BuildingDistances[building];
            }

            public void AssignDistance(int building, int distance)
            {
                BuildingDistances[building] = distance;
            }

            public bool HasPathFromAllBuildings()
            {
                foreach (int distance in BuildingDistances)
                {
                    if (distance == int.MaxValue)
                    {
                        return false;
                    }
                }

                return true;
            }

            public int Total()
            {
                if (HasPathFromAllBuildings())
                {
                    var sum = 0;

                    foreach (int distance in BuildingDistances)
                    {
                        sum += distance;
                    }

                    return sum;
                }

                return -1;
            }
        }

        public class CellDistance
        {
            public int Row { get; private set; }
            public int Col { get; private set; }
            public int Distance { get; private set; }
            public int Building { get; private set; }

            public CellDistance(int row, int col, int distance, int building)
            {
                Row = row;
                Col = col;
                Distance = distance;
                Building = building;
            }

        }


        public int ShortestDistance(int[][] grid)
        {

            var buildings = FindOtherBuildings(grid);
            var result = InitResult(buildings.Count, grid);

            int buildingPos = 0;
            foreach (var building in buildings)
            {
                List<CellDistance> queue = new List<CellDistance>();
                queue.Add(new CellDistance(building.Item1, building.Item2, 0, buildingPos));

                while (queue.Count > 0)
                {
                    AddNeighbours(queue[0],
                                  queue,
                                  grid,
                                  result);
                    queue.RemoveAt(0);
                }


                buildingPos++;
            }

            var answer = int.MaxValue;

            foreach (var row in result)
            {
                foreach (var distanceFromAll in row)
                {

                    if (distanceFromAll.HasPathFromAllBuildings())
                    {
                        var total = distanceFromAll.Total();

                        if (total < answer)
                        {
                            answer = total;
                        }

                    }


                }
            }


            return answer == int.MaxValue ? -1 : answer;

        }

        public void AddNeighbours(CellDistance cellDistance, List<CellDistance> queue,
                          int[][] grid,
                          DistanceForAllBuilding[][] result)
        {
            Visit(cellDistance.Building,
                  cellDistance.Row + 1,
                  cellDistance.Col, cellDistance.Distance + 1,
                  queue,
                  grid,
                  result);

            Visit(cellDistance.Building,
                  cellDistance.Row - 1,
                  cellDistance.Col, cellDistance.Distance + 1,
                  queue,
                  grid,
                  result);

            Visit(cellDistance.Building,
                  cellDistance.Row,
                  cellDistance.Col + 1, cellDistance.Distance + 1,
                  queue,
                  grid,
                  result);

            Visit(cellDistance.Building,
                  cellDistance.Row,
                  cellDistance.Col - 1, cellDistance.Distance + 1,
                  queue,
                  grid,
                  result);

        }

        public void Visit(int building,
                                  int row,
                                  int col,
                                  int distance,
                                  List<CellDistance> queue,
                                  int[][] grid,
                                  DistanceForAllBuilding[][] result)
        {
            if (row < 0
               || row >= grid.Length
               || col < 0
               || col >= grid[0].Length
               || grid[row][col] != 0)
            {
                return;
            }

            var currentDistanceFromAllBuildings = result[row][col];
            currentDistanceFromAllBuildings.GetDistance(building);

            if (distance < currentDistanceFromAllBuildings.GetDistance(building))
            {
                currentDistanceFromAllBuildings.AssignDistance(building, distance);
                var cellDistance = new CellDistance(row, col, distance, building);
                queue.Add(cellDistance);
            }

        }


        public DistanceForAllBuilding[][] InitResult(int buildingCount, int[][] grid)
        {
            var computation = new DistanceForAllBuilding[grid.Length][];

            for (int rowIndex = 0; rowIndex < grid.Length; rowIndex++)
            {
                computation[rowIndex] = new DistanceForAllBuilding[grid[0].Length];
                for (int index = 0; index < grid[0].Length; index++)
                {
                    computation[rowIndex][index] = new DistanceForAllBuilding(buildingCount);
                }
            }


            return computation;
        }

        private List<Tuple<int, int>> FindOtherBuildings(int[][] grid)
        {
            var otherBuildings = new List<Tuple<int, int>>();

            var rowIndex = 0;
            foreach (var row in grid)
            {
                var colIndex = 0;
                foreach (var val in row)
                {
                    if (val == 1)
                    {
                        var building = Tuple.Create(rowIndex, colIndex);
                        otherBuildings.Add(building);
                    }

                    colIndex++;
                }

                rowIndex++;
            }

            return otherBuildings;
        }

    }



}