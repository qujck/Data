namespace Qujck.Data.Model
{
    public sealed class ViewJoin
    {
        public string View { get; set; }
        public string LeftEntity { get; set; }
        public string LeftAlias { get; set; }
        public string RightEntity { get; set; }
        public string RightAlias { get; set; }
        public string Filter { get; set; }
        public int Sequence { get; set; }
    }
}
