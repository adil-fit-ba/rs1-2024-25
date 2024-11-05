using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Data.Models.Auth;

namespace RS1_2024_25.API.Services
{
    public class MyAuthService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        // Constructor with dependency injection
        public MyAuthService(ApplicationDbContext applicationDbContext, IHttpContextAccessor httpContextAccessor)
        {
            _applicationDbContext = applicationDbContext;
            _httpContextAccessor = httpContextAccessor;
        }

        // Method to retrieve authentication information based on a token from Request header
        public MyAuthInfo GetAuthInfo()
        {
            // Step 1: Retrieve the token from the request headers
            string? authToken = _httpContextAccessor.HttpContext?.Request.Headers["my-auth-token"];

            // Step 2: Check if the token is present
            if (string.IsNullOrEmpty(authToken))
            {
                return GetAuthInfo(null);
            }

            // Step 3: Look up the token in the database
            var myAuthToken = _applicationDbContext.MyAuthenticationTokens
                .Include(x => x.MyAppUser)
                .SingleOrDefault(x => x.Value == authToken);

            return GetAuthInfo(myAuthToken);
        }

        public MyAuthInfo GetAuthInfo(MyAuthenticationToken? myAuthToken)
        {
            // Step 1: Check if the token was found and valid
            if (myAuthToken == null)
            {
                // Token is invalid, return null or handle as unauthorized
                return new MyAuthInfo
                {
                    IsAdmin = false,
                    IsManager = false,
                    IsLoggedIn = false,
                };
            }

            // Step 2: Return authentication information
            return new MyAuthInfo
            {
                UserId = myAuthToken.MyAppUserId,
                Username = myAuthToken.MyAppUser!.Username,
                FirstName = myAuthToken.MyAppUser.FirstName,
                LastName = myAuthToken.MyAppUser.LastName,
                IsAdmin = myAuthToken.MyAppUser.IsAdmin,
                IsManager = myAuthToken.MyAppUser.IsManager,
                IsLoggedIn = true
            };
        }
    }

    // DTO to hold authentication information
    public class MyAuthInfo
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsManager { get; set; }
        public bool IsLoggedIn { get; internal set; }
    }
}
