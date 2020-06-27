using System;
using _ShopiXamarin.Data.Network;

namespace _ShopiXamarin.Data.Responses
{
    public class UserResponse : ServiceExceptionModel
    {
        public User User { get; set; }
    }
}
