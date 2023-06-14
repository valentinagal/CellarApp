using WineCellar.API.Models;
using WineCellar.API.Repository;

namespace WineCellar.API.EndPoints
{
    public static class WineTagAPI
    {
        public static void ConfigureWineTagAPI(this WebApplication application)
        {
            application.MapGet("/winetag", GetAllWineTags);
            application.MapGet("/winetag/{id}", GetWineTag);
            application.MapPost("/winetag", CreateWineTag);
            application.MapPut("/winetag", EditWineTag);
            application.MapDelete("/winetag/{id}", DeleteWineTag);
        }

        private static IResult DeleteWineTag(Guid id, ICellarRepository context)
        {
            var wineTag = context.DeleteWineTag(id);
            if (wineTag == null) return Results.NotFound();
            return Results.Ok(wineTag);
        }

        private static IResult EditWineTag(WineTag wineTag, ICellarRepository context)
        {
            var updatedWineTag = context.EditWineTag(wineTag);
            if (updatedWineTag == null) return Results.NotFound();
            return Results.Ok(updatedWineTag);
        }

        private static IResult CreateWineTag(WineTag wineTag, ICellarRepository context)
        {
            var newWineTag = context.CreateWineTag(wineTag);
            return Results.Created($"/winetag/{newWineTag.Id}", newWineTag);
        }

        private static IResult GetWineTag(Guid id, ICellarRepository context)
        {
            var wineTag = context.GetWineTag(id);
            if (wineTag == null) return Results.NotFound();
            return Results.Ok(wineTag);
        }

        private static IResult GetAllWineTags(ICellarRepository context)
        {
            var wineTags = context.GetAllWineTags();
            return Results.Ok(wineTags);
        }
    }
}
