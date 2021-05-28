using System.Collections.Generic;

namespace HappyPocket.Authorization
{
    enum Role // Maybe better to implement via Role table?
    {
        FamilyOwner,
        Parent,
        Trustee,
        Child,
        FinancialConsultant
    }

    class User
    {
        public string username { get; private set; }

        public string password { get; private set; }

        public Role[] roles { get; private set; }

        public User(string username, string password, Role[] roles)
        {
            this.username = username;
            this.password = password;
            this.roles = roles;
        }
    }

    static class GlobalData
    {
        // Dictionary stores key-value paired data: 
        // { username, User(username, password, roles[]) }
        static public Dictionary<string, User> usersCredentials = new Dictionary<string, User>()
        {
            { "FamilyOwner", new User("FamilyOwner", "FamilyOwner123", new Role[] {Role.FamilyOwner}) },
            { "Parent", new User("Parent", "Parent123", new Role[] {Role.Parent}) },
            { "Trustee", new User("Trustee", "Trustee123", new Role[] { Role.Trustee }) },
            { "Child",  new User("Child", "Child123", new Role[] { Role.Child }) },
            { "FinancialConsultant", new User("FinancialConsultant", "FinancialConsultant123", new Role[] { Role.FinancialConsultant }) }
        };
    }
}
