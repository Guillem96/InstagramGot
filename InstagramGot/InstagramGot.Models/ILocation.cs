namespace InstagramGot.Models
{
    public interface ILocation : System.IEquatable<ILocation>
    {
        long Id { get; set; }
        double Latitude { get; set; }
        double Longitude { get; set; }
        string Name { get; set; }
    }
}