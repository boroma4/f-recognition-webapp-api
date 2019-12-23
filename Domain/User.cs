using System;

namespace Domain
{
    public class User
    {
        public int UserId { get; set; }

        public string? Name { get; set; }

        public string Email { get; set; } = default!;

        public string Password { get; set; } = default!;

        public int Score { get; set; } = default!;
    }
}