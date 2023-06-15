using WineCellar.API.Models;
using WineCellar.API.Models.Tags;
using WineCellar.API.Repository;

namespace WineCellar.API.EndPoints
{
    public static class TagAPI
    {
        public static void ConfigureTagAPI(this WebApplication application)
        {
            application.MapGet("/tag", GetAllTags);
            application.MapGet("/tag/{id}", GetTag);
            application.MapPost("/tag", CreateTag);
            application.MapPut("/tag", EditTag);
            application.MapDelete("tag/{id}", DeleteTag);
        }

        private static IResult DeleteTag(Guid id, ICellarRepository context)
        {
            try
            {
                var tag = context.DeleteTag(id);
                return tag != null ? Results.Ok(tag) : Results.NotFound();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static IResult EditTag(CreateTag tag, ICellarRepository context)
        {
            try
            {
                var NewTag = context.EditTag(tag);
                return NewTag != null ? Results.Ok(NewTag) : Results.NotFound();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static IResult CreateTag(CreateTag tag, ICellarRepository context)
        {
            try
            {
                var NewTag = context.CreateTag(tag);
                return NewTag != null ? Results.Created("https://localhost:7293/tag", NewTag) :  Results.NotFound();
            }
            catch (Exception ex) 
            {
                return Results.Problem(ex.Message);
            }
        }

        private static IResult GetTag(Guid id, ICellarRepository context)
        {
            try
            {
                var tag = context.GetTag(id);
                if (tag == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(tag);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static IResult GetAllTags(ICellarRepository context)
        {
            try
            {
                var tags = context.GetAllTags();
                return Results.Ok(tags);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}
