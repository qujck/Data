namespace Qujck.Data.Model
{
    public sealed class Relationship
    {
        public string PKEntity { get; set; }
        public bool PKMultiplicity { get; set; }
        public string FKEntity { get; set; }
        public bool FKMultiplicity { get; set; }
        public string type { get; set; }
        public bool? cascadeDelete { get; set; }
        public int sequence { get; set; }
    }
}
