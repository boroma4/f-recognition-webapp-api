namespace WebApp.Model
{
    public class UserDTO
    {
        public int UserId { get; set; } 
        
        public string? Name { get; set; }

        public int Score { get; set; } 


        public UserDTO(int id, string name, int score)
        {
            UserId = id;
            Name = name;
            Score = score;
        }
    }
}