namespace InstagramGot.Auth
{
    public interface IAuthContext
    {
        string AccesToken { get; set; }
        string AuthorizationURL { get; set; }
    }
}