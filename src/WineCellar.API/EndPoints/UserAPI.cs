using Microsoft.AspNetCore.Http.HttpResults;
using WineCellar.API.Repository;
using WineCellar.API.Models.Users;
using WineCellar.API.Models.Wines;

namespace WineCellar.API.EndPoints
{
    public static class UserAPI
    {
        public static void ConfigureUserAPI(this WebApplication application)
        {
            application.MapGet("/user", GetAllUsers);
            application.MapGet("/user/{id}", GetUser);
            application.MapPost("/user", CreateUser);
        }

        private static IResult GetAllUsers(ICellarRepository context)
        {
            try
            {
                var users = context.GetAllUsers();
                return Results.Ok(users);
            }
            catch(Exception ex)
            {
                return Results.Problem(ex.Message);
            }
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
        private static IResult CreateUser(CreateUser user, ICellarRepository context)
        {
            try
            {
                var NewUser = context.CreateUser(user);
                return NewUser != null ? Results.Created("https://localhost:7293/user", NewUser) : Results.NotFound();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}
