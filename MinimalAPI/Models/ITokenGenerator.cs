namespace MinimalAPI.Models
{
    public interface ITokenGenerator
    {

        public string GenerateToken(string username, string password);

        public bool ValidateToken(string token);
    }
}
