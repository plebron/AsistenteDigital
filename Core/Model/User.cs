using System;

namespace Core.Model
{
    public class User
    {
        private string _username;

        public string Username
        {
            get => _username;
            set => _username = value.Trim();
        }
        public string Password { get; set; }

        public override bool Equals (object obj)
        {            
            string otherName = (obj as User)?.Username;
            return Username.Equals(otherName, StringComparison.OrdinalIgnoreCase);
        }
    }
}