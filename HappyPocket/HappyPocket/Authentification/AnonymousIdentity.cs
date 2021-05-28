namespace HappyPocket.Authentication
{
    // Represents an unauthenticated user.
    public class AnonymousIdentity : CustomIdentity
    {
        public AnonymousIdentity()
            : base(string.Empty, string.Empty, new string[] { })
        { }
    }
}