using Domain.Enums;

namespace Domain.Entities
{
    public class User : Entity
    {
        public User(string name, string password, EUserRole role, bool enabled)
        {
            Name = name;
            Password = password;
            Role = role;
            Enabled = enabled;
        }

        public string Name { get; private set; }
        public string Password { get; private set; }
        public EUserRole Role { get; private set; }
        public bool Enabled { get; private set; }

        public void Enable()
        {
            this.Enabled = true;
        }
        public void Disable()
        {
            this.Enabled = false;
        }
    }
}
