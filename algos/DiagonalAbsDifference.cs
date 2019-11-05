using System;
using System.Linq;

namespace algos
{
    public class DiagonalAbsDifference
    {
        public int CalculateDifference(int[,] dataArray, int n)
        {
           return difference(dataArray, n);
        }

        public static int difference(int[,] dataArray, int n)
        {
            var sum = 0;

            for (int step = 0; step <= n / 2 - 1; step++)
            {
                var leftDiagonalStepSum =  dataArray[step, step] + dataArray[n - 1 - step, n - 1 - step];
                var rightDiagonalStepSum =  dataArray[step, n - 1 - step] + dataArray[n - 1 - step, step];

                sum += leftDiagonalStepSum - rightDiagonalStepSum;

            }


            return Math.Abs(sum);
        }

        public static void main(string[] args){
            var numberOfTestCases = int.Parse(Console.ReadLine());
            int[] output = new int[numberOfTestCases];
            for(int i = 0; i < numberOfTestCases; i++){
                var dimension = int.Parse(Console.ReadLine());
                var dataArray = Console.ReadLine().Trim().Split(' ');
                var allNumbers = dataArray.Select(x => int.Parse(x)).ToList();
                var arrayData = new int[dimension,dimension];
                for(int row = 0; row < dimension; row++){
                    for (int column = 0; column < dimension; column++)
                    {
                        arrayData[row, column] = allNumbers[row*dimension + column];
                    }
                }
                output[i] =   difference(arrayData, dimension);      
            }

            for(int i = 0; i < numberOfTestCases; ++i){
                Console.WriteLine(output[i]);
            }
        }

    }
}
