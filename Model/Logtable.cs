namespace Task5_webapiCrudoperationsdbfirstservicelayer_.Model
{
    public class Logtable
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; } 
        public string LogLevel { get; set; }
        public string sources { get; set; } 
        public string message { get; set; }
        public string Exception { get; set; }
    }
}
