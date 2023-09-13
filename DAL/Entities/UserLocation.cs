namespace DAL.Entities
{
    public class UserLocation
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
