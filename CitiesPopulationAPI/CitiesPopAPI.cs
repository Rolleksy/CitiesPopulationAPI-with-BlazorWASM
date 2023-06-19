namespace CitiesPopulationAPI;

public static class CitiesPopAPI
{
    public static void ConfigureApi(this WebApplication app)
    {
        app.MapGet("/api/cities", GetCities);
        app.MapGet("/api/cities/{id}", GetCity);
        app.MapPost("/api/cities", InsertCity);
        app.MapPut("/api/cities", UpdateCity);
        app.MapDelete("/api/cities", DeleteCity);
    }

    private static async Task<IResult> GetCities(ICitiesPopData popData)
    {
		try
		{
            return Results.Ok(await popData.GetCities());
		}
		catch (Exception ex)
		{
            return Results.Problem(ex.Message);
		}
    }

    private static async Task<IResult> GetCity(int id, ICitiesPopData popData)
    {
        try
        {
            var results = await popData.GetCity(id);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> InsertCity(CitiesPopulationModel city, ICitiesPopData popData)
    {
        try
        {
            await popData.InsertCity(city);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> UpdateCity(CitiesPopulationModel city, ICitiesPopData popData)
    {
        try
        {
            await popData.UpdateCity(city);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> DeleteCity(int id, ICitiesPopData popData)
    {
        try
        {
            await popData.DeleteCity(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}
