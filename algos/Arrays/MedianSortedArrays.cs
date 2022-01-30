using System.Collections.Generic;
namespace algos.Arrays
{
    public class MedianFinder{
        public float FindMedian(int[] nums1, int[] nums2){
            var leftIndex = 0;
            var rightIndex = 0;
            var merged = new List<int>();

            while(merged.Count < nums1.Length + nums2.Length){
                if(leftIndex < nums1.Length && rightIndex < nums2.Length){
                   var nextNumber = nums1[leftIndex] < nums2[rightIndex] ? nums1[leftIndex++] : nums2[rightIndex++]; 
                    merged.Add(nextNumber);                        
                }
                else{
                    var nextNumber = leftIndex < nums1.Length ? nums1[leftIndex++] : nums2[rightIndex++]; 
                    merged.Add(nextNumber);  
                }

            }
                          
            return this.FindMedian(merged.ToArray());
        }

        public float FindMedian(int[] numbers){
            if(numbers.Length < 1){
                return int.MinValue;
            }

            var mid = numbers.Length - 1/ 2;


            if(numbers.Length % 2 == 0){
                return (numbers[mid] + numbers[mid + 1]) / 2.0f;
            }

            return numbers[mid];
        }
    }
    
} 