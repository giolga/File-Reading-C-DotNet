using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reading_file
{
    class Program
    {
        static void Main(string[] args)
        {
            string textFile = "C:\\Users\\GioLGA\\Desktop\\MyProjects\\reading_file\\students.txt";
            string textFile2 = "C:\\Users\\GioLGA\\Desktop\\MyProjects\\reading_file\\topics.txt";

            if (File.Exists(textFile))
            {
                string[] students = File.ReadAllLines(textFile);
                string[] topics = File.ReadAllLines(textFile2);
                List <string> all = students.ToList();
                List <string> themes = topics.ToList();
                List <string>[] groupIth = new List<string>[50];
                List <string> topicIth = new List<string>();


                //foreach (string student in students)
                //{
                //    Console.WriteLine(student);
                //}

                Random random = new Random();

                int numberOfGroups = 0;
                while (all.Count > 0 && themes.Count > 0)
                {
                    int groupMembers = random.Next(1, 4);
                    numberOfGroups++;

                    groupIth[numberOfGroups] = new List<string>();

                    int randomTheme = random.Next(themes.Count);
                    topicIth.Add(themes[randomTheme]);
                    themes.RemoveAt(randomTheme);

                    while (groupMembers > 0 && all.Count > 0 && themes.Count > 0)
                    {
                        int randomStudent = random.Next(all.Count);
                        groupIth[numberOfGroups].Add(all[randomStudent]);
                        all.RemoveAt(randomStudent);

                        groupMembers--;
                    }

                }

                int cnt = 1;
                Console.WriteLine("Number of group is {0} \n", numberOfGroups);
                for (int i = 0; i < topicIth.Count; i++)
                {
                    Console.WriteLine("\t" + "" + topicIth[i] + ":");
                    for (int j = 0; j < groupIth[cnt].Count; j++)
                    {
                        Console.WriteLine("\t\t" + groupIth[cnt][j]);
                    }
                    cnt++;
                }

            }

            Console.ReadKey();
        }
    }
}
