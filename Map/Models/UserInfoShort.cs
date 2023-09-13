namespace Map.Models
{
    public class UserInfoShort
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Latitute { get; set; }
        public double Longitude { get; set; }
        public DateTime LastModified { get; set; }
    }
}
