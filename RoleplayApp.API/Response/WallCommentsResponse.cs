namespace RoleplayApp.API.Response
{
    public class WallCommentsResponse
    {
        public string Comment { get; set; }
        public string Created_at { get; set; }
        public int Sender_id { get; set; }
        public int Receiver_id { get; set; }


    }
}
