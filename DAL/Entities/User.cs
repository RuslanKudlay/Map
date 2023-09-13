namespace DAL.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? FatherName { get; set; }
        public string? Position { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public DateTime LastLocationUpdate { get; set; }
        public ICollection<UserLocation>? UserLocations { get; set; }
    }
}
