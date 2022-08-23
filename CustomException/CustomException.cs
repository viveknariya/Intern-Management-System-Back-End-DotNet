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

    public class UserNameAlradyExists : Exception
    {
        public UserNameAlradyExists(string message) : base(message) { }
    }

    public class DesignationAlreadyExists : Exception
    {
        public DesignationAlreadyExists(string message) : base(message) { }
    }
    public class DesignationNotFound : Exception
    {
        public DesignationNotFound(string message) : base(message) { }
    }

    public class LeaveAlradyExists : Exception
    {
        public LeaveAlradyExists(string message) : base(message) { }
    }

    public class LeaveNotFound : Exception
    {
        public LeaveNotFound(string message) : base(message) { }
    }
}
