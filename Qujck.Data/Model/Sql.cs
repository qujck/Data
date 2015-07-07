namespace Qujck.Data.Model
{
    public sealed class Sql
    {
        public string Entity { get; set; }
        public string Query { get; set; }
        public string Type { get; set; }
        public string Statement { get; set; }
        public string Parameters { get; set; }
        public string Result { get; set; }
        public string ResultType { get; set; }
    }
}
