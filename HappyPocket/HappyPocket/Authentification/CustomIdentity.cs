using System.Security.Principal;

namespace HappyPocket.Authentication
{
    // The IIdentity interface encapsulates a user’s identity.
    public class CustomIdentity : IIdentity
    {
        public CustomIdentity(string name, string email, string[] roles)
        {
            Name = name;
            Email = email;
            Roles = roles;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string[] Roles { get; private set; }

        #region IIdentity Members
        public string AuthenticationType { get { return "Custom authentication"; } }

        public bool IsAuthenticated { get { return !string.IsNullOrEmpty(Name); } } // The user is authenticated onnce the name has been set.
        #endregion
    }
}