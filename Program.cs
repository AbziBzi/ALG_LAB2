using System;

namespace ALG_LAB2
{
    class Program
    {
        static void Main(string[] args)
        {
            RideBalancingRun();
        }

        public static void RideBalancingRun()
        {
            int M = 10;
            int[] groups = { 1,1,1,1,1,1,1,1,1,1,1,1,};
            int result = 0;
            RideBalancing_R RideBalancing = new RideBalancing_R();

            for(int i = 0; i < groups.Length; i++){
                result = RideBalancing.Alghorithm(M, groups, i, 0);
                Console.WriteLine("p({0}) = {1}", i, result);
            }
        }
    }
}