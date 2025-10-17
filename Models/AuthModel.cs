using Microsoft.AspNetCore.Mvc;

namespace Inspinia.Models
{
    public class LoginViewModel
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool RememberMe { get; set; }
    }

    public class DummyUser
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
    }
}