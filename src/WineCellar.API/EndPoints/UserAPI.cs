using Microsoft.AspNetCore.Http.HttpResults;
using WineCellar.API.Repository;
using WineCellar.API.Models.Users;

namespace WineCellar.API.EndPoints
{
    public static class UserAPI
    {
        public static void ConfigureUserAPI(this WebApplication application)
        {
            application.MapGet("/user/{id}", GetUser);
        }

        private static IResult GetUser(Guid id, ICellarRepository context)
        {
            try
            {
                var user = context.GetUser(id);
                if (user == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(user);
            }
            catch(Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}
