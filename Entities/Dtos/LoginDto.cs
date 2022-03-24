using Core.Entities;

namespace Entities.Dtos
{
    public class LoginDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
