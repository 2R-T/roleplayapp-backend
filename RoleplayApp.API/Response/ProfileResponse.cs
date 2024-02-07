namespace RoleplayApp.API.Response
{
    public class ProfileResponse
    {
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string Username { get; set; }
        public DateOnly Birth_date { get; set; }
        public DateOnly Created_at { get; set; }
        public string Profile_picture { get; set; }
        public BiographyResponse Biography { get; set; }
    }
}
