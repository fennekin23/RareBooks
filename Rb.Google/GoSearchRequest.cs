namespace Rb.Google
{
    public class GoSearchRequest
    {
        public GoSearchRequest(string query)
        {
            Query = query;
        }

        public string Query { get; set; }
    }
}