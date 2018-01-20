using Microsoft.AspNet.Identity;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using TFMCooperativeSociety.Models;

namespace TFMCooperativeSociety.Extensions
{
    public static  class ClaimsExtensions
    {
            static string GetUserEmail(this ClaimsIdentity identity)
            {
                return identity.Claims?.FirstOrDefault(c => c.Type == "TFMCooperativeSociety.Models.RegisterMemberViewModel.Email")?.Value;
            }

            public static string GetUserEmail(this IIdentity identity)
            {
                var claimsIdentity = identity as ClaimsIdentity;
                return claimsIdentity != null ? GetUserEmail(claimsIdentity) : "";
            }

            static string GetUserNameIdentifier(this ClaimsIdentity identity)
            {
                return identity.Claims?.FirstOrDefault(c => c.Type == "TFMCooperativeSociety.Models.RegisterMemberViewModel.FirstName")?.Value;
            }

            public static string GetUserNameIdentifier(this IIdentity identity)
            {
                var claimsIdentity = identity as ClaimsIdentity;
                return claimsIdentity != null ? GetUserNameIdentifier(claimsIdentity) : "";
            }

            public static string GetAppUserFirstName( this IIdentity identity)
            {
                 TFMCooperativeDB db = new TFMCooperativeDB();

                var userId = identity.GetUserId();
                var person = db.Users.FirstOrDefault(u => u.Id == userId)?.FirstName;
                return person;
            }

        }
    }
