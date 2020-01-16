using FlatMD.Core.Identity;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace FlatMD.Web.Identity
{
    public class Auth : IAuth
    {
        #region Props

        protected readonly IHttpContextAccessor _httpContextAccessor;
        
        private ClaimsPrincipal _currentUserClaims;

        private ClaimsPrincipal Claims
        {
            get
            {
                if (_currentUserClaims == null)
                {
                    _currentUserClaims = _httpContextAccessor.HttpContext.User;
                }
                return _currentUserClaims;
            }
        }

        #endregion

        #region Ctor

        public Auth(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        
        #endregion

        #region IAuth implementation

        public bool IsAuthenticated => Claims.Identity.IsAuthenticated;
        public string Username
        {
            get =>
                !string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName) ?
                $"{FirstName} {LastName}" :
                Login;
        }
        
        #endregion

        #region Utils
        
        protected string Login => Claims.FindFirst(ClaimTypes.Name)?.Value;
        protected string FirstName => Claims.FindFirst(ClaimTypes.GivenName)?.Value;
        protected string LastName => Claims.FindFirst(ClaimTypes.Surname)?.Value;

        #endregion
        
    }
}