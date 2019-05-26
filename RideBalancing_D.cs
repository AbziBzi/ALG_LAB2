using System;
using System.Collections;
using System.Collections.Generic;


namespace ALG_LAB2
{
    class RideBalancing_D
    {
        public RideBalancing_D() { }

        public int Alghorithm(int M, int[] groups, int i, int j)
        {
            return 0;
        }
        private int Sum(int[] groups, int i, ref int j)
        {
            int result = 0;
            for(int k = i; k < groups.Length; k++){
                if(result < 10 && k < groups.Length && (result + groups[k] < 10)){
                    result += groups[k];
                    j=k;
                }
            }
            return result;
        }
    }
}