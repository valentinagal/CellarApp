﻿using System;
using WineCellar.API.Models;
using WineCellar.API.Models.Wines;
using WineCellar.API.Repository;

namespace WineCellar.API.EndPoints
{
    public static class WineAPI
    {
        public static void ConfigureWineAPI(this WebApplication application)
        {
            application.MapGet("/wine", GetAllWines);
            application.MapGet("/wine/{id}", GetWine);
            application.MapPost("/wine", CreateWine);
            application.MapPut("wine/{id}", EditWine);
            application.MapDelete("/wine/{id}", DeleteWine);
        }

        private static IResult DeleteWine(Guid id, ICellarRepository context)
        {
            try
            {
                var wine = context.DeleteWine(id);
                return wine != null ? Results.Ok(wine) : Results.NotFound();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static IResult EditWine(Guid id, CreateWine wine, ICellarRepository context)
        {
            try
            {
                var NewWine = context.EditWine(id, wine);
                return NewWine != null ? Results.Ok(NewWine) : Results.NotFound();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static IResult CreateWine(CreateWine wine, ICellarRepository context)
        {
            try
            {
                var NewWine = context.CreateWine(wine);
                return NewWine != null ? Results.Created("https://localhost:7293/wine", NewWine) : Results.NotFound();            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static IResult GetWine(Guid id, ICellarRepository context)
        {
            try
            {
                var wine = context.GetWine(id);
                if (wine == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(wine);
            }
            catch (Exception ex)
            {
                return Results.NotFound();
            }
        }

        private static IResult GetAllWines(ICellarRepository context)
        {
            try
            {
                var wines = context.GetAllWines();
                return Results.Ok(wines);
            }
            catch(Exception ex)
            { 
                return Results.Problem(ex.Message);
            }
        }
    }
}
