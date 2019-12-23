namespace algos.Arrays
{
    class MoveZeroesSolution
    {
        public void MoveZeroes(int[] nums) {
        int lastnonzeroat = 0;
        for(int current = 0; current < nums.Length; ++current)
        {
            
            if(nums[current] != 0)
            {
                var temp = nums[lastnonzeroat];
                nums[lastnonzeroat] = nums[current];
                nums[current] = temp;
                lastnonzeroat++;            
            }
        
        }
    }

    }
    
}