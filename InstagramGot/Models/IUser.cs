namespace InstagramGot.Models
{
    public interface IUser
    {
        string Bio { get; set; }
        int FollowedBy { get; set; }
        int Follows { get; set; }
        string FullName { get; set; }
        long Id { get; set; }
        int Media { get; set; }
        string ProfilePictureUrl { get; set; }
        string Username { get; set; }
        string Website { get; set; }
    }
}