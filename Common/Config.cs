namespace Common
{
    public class Config
    {
        public Information CurrentInformation { get; set; }

        private static object syncRoot = new object();
        public string FilePath { get; private set; } = @"C:\Users\Тимофей\source\repos\Common\config.txt";

        private Config()
        {
        }

        private static Config _config;

        public static Config GetConfig()
        {
            if (_config == null)
            {
                lock (syncRoot)
                {
                    if (_config == null)
                    {
                        _config = new Config();
                    }
                }
            }
            return _config;
        }
    }
}
