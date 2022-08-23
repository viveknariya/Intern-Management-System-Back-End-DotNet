using System;

namespace CustomException
{
    public class CustomException
    {
    }

    public class UserNameNotFound : Exception
    {
        public UserNameNotFound(string message) : base(message) { }
    }

    public class IncorrectPassword : Exception
    {
        public IncorrectPassword(string message) : base(message) { }
    }
}
