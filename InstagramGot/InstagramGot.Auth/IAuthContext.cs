namespace InstagramGot.Auth
{
    public interface IAuthContext
    {
        string AccessToken { get; set; }
        string AuthorizationURL { get; set; }
    }
}