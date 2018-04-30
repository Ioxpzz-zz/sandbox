using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            //Stats.Solution2c();

            string s = "";
        }

        static void FixFile(string input, string output)
        {
            string[] readText = File.ReadAllLines(input);
            for(int i = 0; i < readText.Length-1; i++)
            {
                if (readText[i].Substring(56, 1) == " ")
                {
                    readText[i] = readText[i].Substring(0, 56) + "-" + readText[i].Substring(57);
                }
                else if(readText[i].Substring(56, 1) == "*")
                {
                    readText[i] = readText[i].Substring(0, 56) + " " + readText[i].Substring(57);
                }
                else
                {
                    //Unreachable code
                } 
            }
            File.WriteAllLines(output, readText);
        }
    }
}
