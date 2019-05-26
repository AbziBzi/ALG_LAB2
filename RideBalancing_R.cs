using System;
using System.Collections;
using System.Collections.Generic;


namespace ALG_LAB2
{
    class RideBalancing_R
    {
        public RideBalancing_R() { }

        public int Alghorithm(int M, int[] groups, int i, int j)
        {
            if(j == 0)
                j = i;
            int[] values = new int[groups.Length];
            int value = 0;
            if (i > groups.Length - 1)
                return 0;
            else if (i == groups.Length - 1)
            {
                return value = (int)Math.Pow((M - groups[i]), 2);
            }
            else
            {
                int firstPart = (int)Math.Pow((M-Sum(groups, i, ref j)),2);
                return (firstPart + (Alghorithm(M, groups, j+1, 0)));
            }
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