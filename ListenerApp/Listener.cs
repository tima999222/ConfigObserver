using System;
using System.IO;
using GenericJsonSerializer;
using Common;

namespace ListenerApp
{
    public class Listener
    {
        public void isUpdated()
        {
            string[] readText = File.ReadAllLines(Config.GetConfig().FilePath);

            StreamReader sr = new StreamReader(Config.GetConfig().FilePath);
            string information = sr.ReadLine();
            string prevInformation = sr.ReadLine();
            sr.Close();

            if (!string.Equals(readText[0], readText[1]))
            {
                ReadConfig();
                readText[1] = readText[0];
                File.WriteAllLines(Config.GetConfig().FilePath, readText);
            }
            else
            {
                Console.WriteLine("Ничего не изменилось");
            }
        }

        private void ReadConfig()
        {
            Console.WriteLine("Данные изменились");
            var sr = new StreamReader(Config.GetConfig().FilePath);
            var readed = sr.ReadLine().Deserialize<Information>();
            Console.WriteLine($"Name: {readed.Name}, Last Time: {readed.LastTime}");
            sr.Close();
        }
    }
}
