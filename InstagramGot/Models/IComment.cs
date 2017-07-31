namespace InstagramGot.Models
{
    public interface IComment
    {
        long CreatedTimeUnixMiliseconds { get; set; }
        IMinifiedUser From { get; set; }
        long Id { get; set; }
        string Text { get; set; }
    }
}