using DockerSyslogServer.Data;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DockerSyslogServer.Listener
{
    public class ServerEngine
    {
        string Server;
        string Database;
        int ListeningPort;

        public ServerEngine(string Server = "localhost", string Database = "syslogs", int ListeningPort = 514)
        {
            this.Server = Server;
            this.Database = Database;
            this.ListeningPort = ListeningPort;
        }

        public void Listener()
        {
            UdpClient c = new UdpClient(ListeningPort); // Create a new UDP client
            Console.WriteLine("Syslog server is now listening on port " + ListeningPort + "...");

            while (true)
            {
                try
                {
                    var bytesData = c.ReceiveAsync(); // Receive data from the client
                    string clientData = Encoding.ASCII.GetString(bytesData.Result.Buffer); // Convert the byte array to a readable string
                    string clientIP = bytesData.Result.RemoteEndPoint.Address.ToString(); // Get the sending device IP

                    Syslog syslog = new Syslog(DateTime.Now, clientIP, clientData); // Create a new Syslog object from the data

                    Thread t = new Thread(() => WriteSyslogToMongoDB(syslog)); // Create a new thread to launch the method that writes the syslog object to the database
                    t.Start(); // Run the new thread
                }
                catch
                {
                    Console.WriteLine("Error...");
                }
            }
        }

        public void WriteSyslogToMongoDB(Syslog Syslog)
        {
            string ConnectionString = @"mongodb://" + Server;
            MongoClient client = new MongoClient(ConnectionString);

            var database = client.GetDatabase(Database);
            var collection = database.GetCollection<BsonDocument>(Syslog.Source);
            var document = new BsonDocument
            {
                { "Timestamp", Syslog.Timestamp },
                { "Data", Syslog.Data }
            };

            try
            {
                collection.InsertOne(document);
                Console.WriteLine(Syslog.Timestamp + " - Syslog from " + Syslog.Source + " saved to database");
            }
            catch
            {
                Console.WriteLine("Failed to save syslog from " + Syslog.Source);
            }
        }
    }
}
