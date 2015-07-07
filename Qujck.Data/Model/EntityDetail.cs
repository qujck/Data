namespace Qujck.Data.Model
{
    public sealed class EntityDetail
    {
        public string Entity { get; set; }
        public string Attribute { get; set; }
        public int Sequence { get; set; }
        public string DataType { get; set; }
        public bool? Nullable { get; set; }
        public bool? IsIdentity { get; set; }
        public int? PKSequence { get; set; }
        public string Enum { get; set; }
        public string Description { get; set; }
        public string Annotation { get; set; }
    }
}
 
