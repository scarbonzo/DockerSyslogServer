using System;

namespace DockerSyslogServer.Listener
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string dbserver = "localhost";
                string database = "syslogs";

                try
                {
                    if (args[0] != null)
                    {
                        dbserver = args[0];
                    }
                }
                catch { }

                try
                {
                    if (args[1] != null)
                    {
                        database = args[1];
                    }
                }
                catch { }

                SyslogServerEngine engine = new SyslogServerEngine(dbserver, database);
                engine.Listener();

                Console.WriteLine("Server is starting up...");
            }
            catch
            {
                Console.WriteLine("Error starting engine...");
            }

            Console.WriteLine("Syslog server is shutting down...");
        }
    }
}
