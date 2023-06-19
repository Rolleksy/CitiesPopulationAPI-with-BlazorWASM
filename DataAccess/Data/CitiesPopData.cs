using DataAccess.DbAccess;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data;

public class CitiesPopData : ICitiesPopData
{
    private readonly ISqlDataAccess _db;

    public CitiesPopData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<CitiesPopulationModel>> GetCities() =>
        _db.LoadData<CitiesPopulationModel, dynamic>("dbo.CitiesPopulation_GetAll", new { });

    public async Task<CitiesPopulationModel?> GetCity(int id)
    {
        var results = await _db.LoadData<CitiesPopulationModel, dynamic>(
            "dbo.CitiesPopulation_Get",
            new { Id = id });
        return results.FirstOrDefault();
    }

    public Task InsertCity(CitiesPopulationModel city) =>
        _db.SaveData("dbo.CitiesPopulation_Insert", new { city.CityName, city.Population });

    public Task UpdateCity(CitiesPopulationModel city) =>
        _db.SaveData("dbo.CitiesPopulation_Update", city);

    public Task DeleteCity(int id) =>
        _db.SaveData("dbo.CitiesPopulation_Delete", new { Id = id });
}
