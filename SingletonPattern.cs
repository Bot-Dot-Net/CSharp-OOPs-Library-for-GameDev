using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public class SingletonPattern1
    {
        public class GameSettings
        {
            private static GameSettings _instance;

            private GameSettings()
            {
                // Private constructor to prevent instantiation
            }

            public static GameSettings Instance
            {
                get
                {
                    if (_instance == null)
                    {
                        _instance = new GameSettings();
                    }
                    return _instance;
                }
            }

            public string Difficulty { get; set; }
            public int Volume { get; set; }
        }
        public static void Run()
        {
            GameSettings settings = GameSettings.Instance;
            settings.Difficulty = "Hard";
            settings.Volume = 50;

            GameSettings anotherSettings = GameSettings.Instance;
            Console.WriteLine($"Difficulty: {anotherSettings.Difficulty}, Volume: {anotherSettings.Volume}");
        }
    }

    public class SingletonPattern2
    {
        public class Logger
        {
            private static readonly Logger _instance = new Logger();

            private Logger()
            {
                // Private constructor to prevent instantiation
            }

            public static Logger Instance
            {
                get
                {
                    return _instance;
                }
            }

            public void Log(string message)
            {
                Console.WriteLine($"Log: {message}");
            }
        }
        public static void Run()
        {
            Logger logger1 = Logger.Instance;
            logger1.Log("This is a log message.");

            Logger logger2 = Logger.Instance;
            logger2.Log("This is another log message.");

            Console.WriteLine($"Are both loggers the same instance? {ReferenceEquals(logger1, logger2)}");
        }
    }

    public class SingletonPattern3
    {
        public class GameSettings
        {
            private static GameSettings _instance;
            public static GameSettings Instance
            {
                get
                {
                    if (_instance == null)
                    {
                        _instance = new GameSettings();
                    }
                    return _instance;
                }
            }
            public string Difficulty { get; set; }
            public int Volume { get; set; }

            private GameSettings(){}
        }
        public static void Run()
        {            
            GameSettings settings = GameSettings.Instance;
            settings.Difficulty = "Medium";
            settings.Volume = 75;

            GameSettings anotherSettings = GameSettings.Instance;
            Console.WriteLine($"Difficulty: {anotherSettings.Difficulty}, Volume: {anotherSettings.Volume}");
        }
    }
}