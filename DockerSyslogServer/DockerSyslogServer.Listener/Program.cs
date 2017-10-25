using System;

namespace DockerSyslogServer.Listener
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ServerEngine engine = new ServerEngine("192.168.50.225","cisco_vg");
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
