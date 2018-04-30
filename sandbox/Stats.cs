using System;
using System.Collections.Generic;
using System.IO;

namespace sandbox
{
    public static class Stats
    {
        //https://www.hackerrank.com/challenges/s10-basic-statistics/problem
        public static void Solution0a()
        {
            
            //string input0 = "10";
            //string input1 = "64630 11735 14216 99233 14470 4978 73429 38120 51135 67060";
            //long count = System.Convert.ToInt64(input0);
            //long[] ar = Array.ConvertAll(input1.Split(' '), arTemp => Convert.ToInt64(arTemp));

            long count = System.Convert.ToInt64(Console.ReadLine());
            long[] ar = Array.ConvertAll(Console.ReadLine().Split(' '), arTemp => Convert.ToInt64(arTemp));

            Array.Sort(ar);
            long mean = 0;
            
            Dictionary<long, int> modeCounts = new Dictionary<long, int>();
            long modeMax = 1;
            long mode = ar[0];
            foreach (long a in ar)
            {
                Console.WriteLine(a);

                mean += a;
                if (modeCounts.ContainsKey(a))
                {
                    modeCounts[a] += 1;
                    if(modeCounts[a] > modeMax)
                    {
                        modeMax = modeCounts[a];
                        mode = a;
                    } 
                }
                else { modeCounts.Add(a, 1); }
            }

            long median = 0;
            if (count % 2 == 0)
            {
                median = ar[count / 2] + ar[(count / 2) - 1];
            }
            else
            {
                median = ar[(count - 1) / 2];
            }

            Console.WriteLine(System.Convert.ToDouble(mean) / System.Convert.ToDouble(count));
            Console.WriteLine(System.Convert.ToDouble(median) / 2);
            Console.WriteLine(mode);
        }

        public static void Solution0b()
        {
            //string input0 = "5";
            //string input1 = "10 40 30 50 20";
            //string input2 = "1 2 3 4 5";
            //double count = System.Convert.ToDouble(input0);
            //double[] ar1 = Array.ConvertAll(input1.Split(' '), arTemp => Convert.ToDouble(arTemp));
            //double[] ar2 = Array.ConvertAll(input2.Split(' '), arTemp => Convert.ToDouble(arTemp));

            double count = System.Convert.ToDouble(Console.ReadLine());
            double[] ar1 = Array.ConvertAll(Console.ReadLine().Split(' '), arTemp => Convert.ToDouble(arTemp));
            double[] ar2 = Array.ConvertAll(Console.ReadLine().Split(' '), arTemp => Convert.ToDouble(arTemp));

            double result = 0;
            double denominator = 0; 
            for(int i = 0; i < count; i++)
            {
                result += ar1[i] * ar2[i];
                denominator += ar2[i];
            }

            if(denominator != 0)
            {
                Console.WriteLine(String.Format("{0:0.0}", result / denominator));
            }

        }

        public static void Solution1a()
        {
            string input0 = "9";
            string input1 = "3 7 8 5 12 14 21 13 18";
            int count = System.Convert.ToInt32(input0);
            int[] ar = Array.ConvertAll(input1.Split(' '), arTemp => Convert.ToInt32(arTemp));

            //int count = System.Convert.ToInt32(Console.ReadLine());
            //int[] ar = Array.ConvertAll(Console.ReadLine().Split(' '), arTemp => Convert.ToInt32(arTemp));

            Array.Sort(ar);
            int iCountMid = 0;
            if (count % 2 == 0) { iCountMid = count / 2;   }
            else { iCountMid = (count - 1) / 2; }

            int[] left = new int[iCountMid];
            int[] right = new int[iCountMid];

            Array.Copy(ar, 0, left, 0, iCountMid);
            Array.Copy(ar, (ar.Length - iCountMid), right, 0, iCountMid);

            int q1 = GetMedian(left);
            int q2 = GetMedian(ar);
            int q3 = GetMedian(right);

            Console.WriteLine(q1);
            Console.WriteLine(q2);
            Console.WriteLine(q3);
        }

        private static int GetMedian(int[] ar)
        {
            int median = 0;
            if (ar.Length % 2 == 0) { median = ( ar[ar.Length / 2] + ar[(ar.Length / 2) - 1] ) / 2; }
            else  { median = ar[(ar.Length - 1) / 2]; }
            return median;
        }

        public static void Solution1b()
        {
            string input0 = "5";
            string input1 = "10 40 30 50 20";
            int count = System.Convert.ToInt32(input0);
            int[] ar = Array.ConvertAll(input1.Split(' '), arTemp => Convert.ToInt32(arTemp));

            //int count = System.Convert.ToInt32(Console.ReadLine());
            //int[] ar = Array.ConvertAll(Console.ReadLine().Split(' '), arTemp => Convert.ToInt32(arTemp));

            int mean = 0;
            foreach(int i in ar) { mean += i; }
            mean = mean / count;

            double std = 0;
            foreach (int i in ar)
            {
                std += Math.Pow((System.Convert.ToDouble(i) - System.Convert.ToDouble(mean)), 2);
            }
            std = Math.Sqrt((std / System.Convert.ToDouble(count)));
            std = Math.Round(std, 1);
            Console.WriteLine(std);
        }

        public static void Solution1c()
        {
            string input0 = "6";
            string input1 = "6 12 8 10 20 16";
            string input2 = "5 4 3 2 1 5";
            int count = System.Convert.ToInt32(input0);
            int[] ar1 = Array.ConvertAll(input1.Split(' '), arTemp => Convert.ToInt32(arTemp));
            int[] ar2 = Array.ConvertAll(input2.Split(' '), arTemp => Convert.ToInt32(arTemp));

            //int count = System.Convert.ToInt32(Console.ReadLine());
            //int[] ar1 = Array.ConvertAll(Console.ReadLine().Split(' '), arTemp => Convert.ToInt32(arTemp));
            //int[] ar2 = Array.ConvertAll(Console.ReadLine().Split(' '), arTemp => Convert.ToInt32(arTemp));

            int iFrequency = 0;
            foreach(int i in ar2) { iFrequency += i; }

            string sFrequency = String.Empty;
            for(int i = 0; i < ar1.Length; i++)
            {
                for(int j = 0; j < ar2[i]; j++)
                {
                    if(sFrequency != String.Empty) { sFrequency += " "; }
                    sFrequency += ar1[i].ToString();
                }
            }
            double[] ar = Array.ConvertAll(sFrequency.Split(' '), arTemp => Convert.ToDouble(arTemp));

            Array.Sort(ar);
            int iCountMid = 0;
            if (iFrequency % 2 == 0) { iCountMid = iFrequency / 2; }
            else { iCountMid = (iFrequency - 1) / 2; }

            double[] left = new double[iCountMid];
            double[] right = new double[iCountMid];

            Array.Copy(ar, 0, left, 0, iCountMid);
            Array.Copy(ar, (ar.Length - iCountMid), right, 0, iCountMid);

            double q1 = GetMedian(left);
            double q3 = GetMedian(right);
            double iqr = Math.Round(q3 - q1, 1);
            Console.WriteLine(String.Format("{0:0.0}", iqr));
        }

        private static double GetMedian(double[] ar)
        {
            double median = 0;
            if (ar.Length % 2 == 0) { median = (ar[ar.Length / 2] + ar[(ar.Length / 2) - 1]) / 2; }
            else { median = ar[(ar.Length - 1) / 2]; }
            return median;
        }

        public static void Solution2c()
        {
            string[] urnX = new string[] { "R", "R", "R", "R", "B", "B", "B" };
            string[] urnY = new string[] { "R", "R", "R", "R", "R", "B", "B", "B", "B" };
            string[] urnZ = new string[] { "R", "R", "R", "R", "B", "B", "B", "B" };

            int sucsess = 0;
            int totalCount = 0;
            foreach(string x in urnX)
            {
                foreach(string y in urnY)
                {
                    foreach(string z in urnZ)
                    {
                        string xyz = x + y + z; 
                        if(xyz == "RRB" || xyz == "RBR" || xyz == "BRR")
                        {
                            sucsess++;
                        }
                        totalCount++;
                    }
                }
            }
            Console.WriteLine(sucsess.ToString() + " / " + totalCount.ToString());
        }

    }
}
