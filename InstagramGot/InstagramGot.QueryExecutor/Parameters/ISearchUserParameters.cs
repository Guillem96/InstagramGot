namespace InstagramGot.Parameters
{
    public interface ISearchUserParameters
    {
        int? Count { get; set; }
        string Query { get; set; }
    }
}