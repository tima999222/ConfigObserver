using System;
using System.IO;
using Common;
using GenericJsonSerializer;

namespace ProducerApp
{
    public class Producer
    {
        public void WriteInConfig()
        {
            StreamReader sr = new StreamReader(Config.GetConfig().FilePath);
            Information prevInformation = new Information();
            prevInformation = sr.ReadLine().Deserialize<Information>();
            sr.Close();

            Information information = new Information();
            Console.Write("Введите имя: ");
            information.Name = Console.ReadLine();
            information.LastTime = DateTime.Now;

            var sw = new StreamWriter(Config.GetConfig().FilePath, false);
            sw.WriteLine(information.Serialize());
            sw.WriteLine(prevInformation.Serialize());
            sw.Close();
        }
    }
}
