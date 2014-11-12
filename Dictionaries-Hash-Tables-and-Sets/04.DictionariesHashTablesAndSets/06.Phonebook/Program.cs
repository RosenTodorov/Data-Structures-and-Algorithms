/*A text file phones.txt holds information about people, their town and phone number.
   Duplicates can occur in people names, towns and phone numbers. Write a program to read 
 * the phones file and execute a sequence of commands given in the file commands.txt:
    find(name) – display all matching records by given name (first, middle, last or nickname)
    find(name, town) – display all matching records by given name and town
*/

namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Wintellect.PowerCollections;

    public class Phonebook
    {
        private const string PhonesFilePath = "../../phones.txt";
        private static MultiDictionary<string, KeyValuePair<string, string>> townToNameAndPhone =
                    new MultiDictionary<string, KeyValuePair<string, string>>(true);

        private static MultiDictionary<string, KeyValuePair<string, string>> nameToTownAndPhone =
                    new MultiDictionary<string, KeyValuePair<string, string>>(true);

        public static void Main()
        {
            ProcessTextFile(PhonesFilePath);

            Find("Mimi");
            Find("Smurfa", "Plovdiv");
            Find("Mimi", "Razgrad");
            Find("Bat Gancho");
            Find("Bat Gancho", "vIDIn");
        }

        private static void ProcessTextFile(string path)
        {
            var entryList = new List<string>();
            var reader = new StreamReader(path);

            using (reader)
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    entryList.Add(line);
                    line = reader.ReadLine();
                }
            }

            FillDataStructures(entryList);
        }

        private static void FillDataStructures(List<string> entryList)
        {
            for (int i = 0; i < entryList.Count; i++)
            {
                var elements = entryList[i].Split('|');
                var name = elements[0].ToLower().Trim();
                var town = elements[1].ToLower().Trim();
                var phone = elements[2].Trim();

                townToNameAndPhone.Add(town, new KeyValuePair<string, string>(name, phone));
                nameToTownAndPhone.Add(name, new KeyValuePair<string, string>(town, phone));
            }
        }

        public static void Find(string name)
        {
            bool success = false;
            foreach (var key in nameToTownAndPhone)
            {
                if (key.Key.IndexOf(name.ToLower()) >= 0)
                {
                    success = true;
                    Console.WriteLine(" ------------{0}------------- ", name);
                    foreach (var item in key.Value)
                    {
                        Console.WriteLine("Town: {0}", item.Key);
                        Console.WriteLine("Phone: {0}", item.Value);
                    }

                    Console.WriteLine(" --------------------------------- ", name);
                    break;
                }
            }

            if (!success)
            {
                Console.WriteLine("Contact does not exist");
            }
        }

        public static void Find(string name, string town)
        {
            bool successName = false;
            bool successTown = false;

            foreach (var key in townToNameAndPhone)
            {
                if (key.Key == town.ToLower())
                {
                    successTown = true;
                    Console.WriteLine(" ------------{0}------------- ", name);
                    Console.WriteLine("Town: {0}", town);
                    foreach (var item in key.Value)
                    {
                        if (item.Key.IndexOf(name.ToLower()) >= 0)
                        {
                            successName = true;
                            Console.WriteLine("Phone: {0}", item.Value);
                        }
                    }

                    Console.WriteLine(" --------------------------------- ", name);
                    break;
                }
            }

            if (!successName || !successTown)
            {
                Console.WriteLine("Contact does not exist");
            }
        }
    }
}