namespace Qujck.Data.Model
{
    public sealed class DataType
    {
        public string Name { get; set; }
        public string MSSQL { get; set; }
        public string dotNET { get; set; }
        public string XSD { get; set; }
        public int? Length { get; set; }
        public int? Precision { get; set; }
        public int? Scale { get; set; }
        public string Pattern { get; set; }
        public string MinInclusive { get; set; }
        public string MaxInclusive { get; set; }
    }
}
