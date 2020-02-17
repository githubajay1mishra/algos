using System;
using System.Collections.Generic;
using System.Linq;

namespace algos.Arrays
{
    class SolutionMergeIntervals
    {
        public int[][] Merge(int[][] intervals)
        {

            Array.Sort(intervals, SortInterval);

            List<int[]> output = new List<int[]>();

            if (intervals.Length > 0)
            {

                output.Add(intervals[0]);

                for (int index = 1; index < intervals.Length; index++)
                {
                    var areOverlapping = overlap(output.Last(), intervals[index]);

                    if (areOverlapping)
                    {
                        var merged = merge(output.Last(), intervals[index]);
                        output.RemoveAt(output.Count - 1);
                        output.Add(merged);

                    }
                    else
                    {

                        output.Add(intervals[index]);
                    }

                }
            }

            return output.ToArray();

        }

        public bool overlap(int[] x, int[] y)
        {

            return y[0] >= x[0] && y[0] <= x[1];

        }

        public int[] merge(int[] x, int[] y)
        {
            var start = Math.Min(x[0], y[0]);
            var end = Math.Max(x[1], y[1]);
            return new int[] { start, end };
        }



        public static int SortInterval(int[] x, int[] y)
        {
            if (x[0] < y[0])
            {
                return -1;
            }

            if (x[0] > y[0])
            {
                return 1;
            }

            return x[1].CompareTo(y[1]);

        }

        public int MinMeetingRooms(int[][] intervals)
        {
            Array.Sort(intervals, SortInterval);

            List<int[]> output = new List<int[]>();

            if (intervals.Length < 1)
            {
                return 0;
            }

            output.Add(intervals[0]);

            for (int index = 1; index < intervals.Length; index++)
            {
                bool usedExisting = false;
                var currentMeeting = intervals[index];
                for (int roomIndex = 0; roomIndex < output.Count; roomIndex++)
                {
                    if (output[roomIndex][1] < currentMeeting[0])
                    {
                        usedExisting = true;
                        output[roomIndex] = currentMeeting;
                        break;
                    }

                }

                if (!usedExisting)
                {
                    output.Add(currentMeeting);
                }

            }




            return output.Count;




        }
    }
}