using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_1
{
    public class KMP
    {
        /// <summary>
        /// 计算kmp算法next 数组
        /// </summary>
        /// <param name="next"></param>
        /// <param name="T"></param>
        public static void Get_Next(ref int[] next,string T) {
            int j = 1, k = 0;
            while (j < T.Length)
            {
                if (k == 0 || T[j - 1] == T[k - 1])
                {
                    j++;
                    k++;
                    next[j] = k;
                }
                else {
                    k = next[k];
                }
            }
        }
        /// <summary>
        /// 计算kmp算法NextVal 数组
        /// </summary>
        /// <param name="next"></param>
        /// <param name="T"></param>
        public static void Get_NextVal(ref int[] nextval, string T)
        {
            int j = 1, k = 0;
            while (j < T.Length)
            {
                if (k == 0 || T[j - 1] == T[k - 1])
                {
                    j++;
                    k++;
                    if (T[j - 1] == T[k - 1])
                    {
                        nextval[j] = nextval[k];
                    }
                    else {
                        nextval[j] = k;
                    }
                }
                else
                {
                    k = nextval[k];
                }
            }
        }

        /// <summary>
        /// KMP模式匹配算法
        /// </summary>
        /// <param name="S">主串</param>
        /// <param name="T">模式串</param>
        /// <param name="pos"></param>
        /// <returns></returns>
        public static int KMP_Index(string S, string T, int pos = 1)
        {
            int i = pos, j = 1;//因为next里0表示下一位 所以不能从零开始， i ,j 表示第几位字符串
            int[] next = new int[255];
            Get_NextVal(ref next, T);
            while (i-1 < S.Length && j-1 < T.Length)
            {
                if (j==0||S[i-1] == T[j-1]) 
                {
                    i++;
                    j++;
                }
                else {
                    j = next[j];
                }
            }
            if (j > T.Length)
                return i - T.Length-1;
            else
                return 0;
        }

    }
}
