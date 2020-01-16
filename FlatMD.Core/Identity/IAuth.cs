using System;

namespace FlatMD.Core.Identity
{
    public interface IAuth
    {
        string Username { get; }
        bool IsAuthenticated { get; }
    }
}