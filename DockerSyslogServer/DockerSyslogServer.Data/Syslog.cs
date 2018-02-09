using System;

namespace DockerSyslogServer.Data
{
    public class Syslog
    {
        public Guid Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string Source { get; set; }
        public string Data { get; set; }

        public Syslog()
        {
        }

        public Syslog(DateTime Timestamp, string Source, string Data)
        {
            this.Timestamp = Timestamp;
            this.Source = Source;
            this.Data = Data;
        }
    }
}
