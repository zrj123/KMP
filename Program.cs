using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string S = "aaabaaaaab", T = "aaaaab";
            var a = S[0];

            int[] next= new int[10];
            int[] nextVal = new int[10];

            KMP.Get_Next(ref next, "aaaaaaaab");
            KMP.Get_NextVal(ref nextVal, "aaaaaaaab");

            var result = Program.Index(S, T);
            var result2 = KMP.KMP_Index(S, T);
            foreach (var item in next) {
                Console.Write(item);
            }
            Console.ReadLine();
        }

        /// <summary>
        /// 简单模式匹配算法
        /// </summary>
        /// <param name="S"></param>
        /// <param name="T"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        public static int Index(string S, string T, int pos=1)
        {
            int i = pos-1, j = 0;
            while (i < S.Length && j < T.Length)
            {
                if (S[i] == T[j])
                {
                    i++;
                    j++;
                }
                else
                {
                    i=i-j+1;
                    j = 0;
                }
            }
            if (j >= T.Length)
                return i - T.Length;
            else
                return 0;

        }
        



    }

    

}
