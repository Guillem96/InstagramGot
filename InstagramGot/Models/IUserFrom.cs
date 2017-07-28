namespace InstagramGot.Models
{
    public interface IUserFrom
    {
        long Id { get; set; }
        string ProfileImageUrl { get; set; }
        string Username { get; set; }
    }
}