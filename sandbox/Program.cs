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
            string s = "";
        }

        static void FixFile(string input, string output)
        {
            string[] readText = File.ReadAllLines(input);
            for (int i = 0; i < readText.Length - 1; i++)
            {
                if (readText[i].Substring(56, 1) == " ")
                {
                    readText[i] = readText[i].Substring(0, 56) + "-" + readText[i].Substring(57);
                }
                else if (readText[i].Substring(56, 1) == "*")
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

        static void InstagramCampaign(string input, string input2)
        {
            string newLineText = "Delete Comment";
            string currentUser = "";
            Dictionary<string, int> tracker = new Dictionary<string, int>();

            List<string> excludeUserList = new List<string>();
            excludeUserList.Add("itsybitzycreations");

            string[] readText = File.ReadAllLines(input);
            foreach (string newLine in readText)
            {
                if (newLine.StartsWith(newLineText))
                {
                    currentUser = String.Empty;
                    
                    if (newLine.Contains('@'))
                    {
                        currentUser = newLine.Substring(newLineText.Length, newLine.IndexOf('@') - newLineText.Length);
                        if (!excludeUserList.Contains(currentUser))
                        {
                            int count = newLine.Count(f => f == '@');
                            
                            if (tracker.ContainsKey(currentUser))
                            {
                                tracker[currentUser] += count;
                            }
                            else
                            {
                                tracker.Add(currentUser, count);
                            }
                        }
                    }
                }
                else
                {
                    if (currentUser != String.Empty)
                    {
                        int count = newLine.Count(f => f == '@');
                        tracker[currentUser] += count;
                    }
                }
            }

            Dictionary<string, int> entries = new Dictionary<string, int>();
            int totalEntries = 0;
            List<string> readBonus = new List<string>(File.ReadAllLines(input2));
            foreach (KeyValuePair<string, int> user in tracker)
            {
                int entryCount = System.Convert.ToInt32(Math.Floor(System.Convert.ToDouble(user.Value) / 3));
                if (readBonus.Contains(user.Key))
                {
                    entryCount += 5;
                }
                totalEntries += entryCount;

                if(entryCount > 0)
                {
                    entries.Add(user.Key, entryCount);
                }
            }

            Random rnd = new Random();
            System.Threading.Thread.Sleep(5000);

            string[] randomDrawing = new string[totalEntries];
            HashSet<int> exclude = new HashSet<int>();
            foreach (KeyValuePair<string, int> user in entries)
            {
                for(int insertEntry = 0; insertEntry < user.Value; insertEntry++)
                {
                    IEnumerable<int> range = Enumerable.Range(0, totalEntries).Where(i => !exclude.Contains(i));
                    int randomNumber = rnd.Next(0, totalEntries - exclude.Count);
                    int randomNumberExclude = range.ElementAt(randomNumber);
                    if (randomDrawing[randomNumberExclude] == null || randomDrawing[randomNumberExclude] == "")
                    {
                        randomDrawing[randomNumberExclude] = user.Key;
                        exclude.Add(randomNumberExclude);
                    }
                }
            }

            int randomSeed = rnd.Next(0, int.MaxValue);
            int j = randomSeed % totalEntries;
            Console.WriteLine("Winner: " + randomDrawing[j]);
        }

        static double CountLines(string fileExt, string filePath)
        {
            double count = 0;
            FileInfo[] fileList = new DirectoryInfo(filePath).GetFiles("*." + fileExt, SearchOption.AllDirectories);
            foreach(FileInfo file in fileList)
            {
                count += File.ReadAllLines(file.Directory + "\\" + file.Name).Count();
            }
            return count;
        }
    }
}
