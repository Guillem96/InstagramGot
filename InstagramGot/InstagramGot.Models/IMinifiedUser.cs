namespace InstagramGot.Models
{
    public interface IMinifiedUser : System.IEquatable<IMinifiedUser>
    {
        long Id { get; set; }
        string ProfileImageUrl { get; set; }
        string Username { get; set; }
        string FullName { get; set; }
    }
}