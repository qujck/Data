namespace Qujck.Data.Model
{
    public sealed class RelationshipDetail
    {
        public string PKEntity { get; set; }
        public string PKAttribute { get; set; }
        public string FKEntity { get; set; }
        public string FKAttribute { get; set; }
        public int Sequence { get; set; }
    }
}
